using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HoaiEventManager.CoreBusiness.Models;
using HoaiEventManager.UseCases.Interfaces;
using System;
using System.Threading.Tasks;

namespace HoaiEventManager.UseCases.Registrations
{
    public class RegisterForEventUseCase
    {
        private readonly IRegistrationRepository _registrationRepository;
        private readonly IEventRepository _eventRepository;

        public RegisterForEventUseCase(
            IRegistrationRepository registrationRepository,
            IEventRepository eventRepository)
        {
            _registrationRepository = registrationRepository;
            _eventRepository = eventRepository;
        }

        public async Task ExecuteAsync(int eventId, string userId)
        {
            // Bước 1: Lấy thông tin sự kiện
            var eventDetails = await _eventRepository.GetEventByIdAsync(eventId);
            if (eventDetails == null)
            {
                // Nếu không tìm thấy sự kiện, báo lỗi.
                throw new ApplicationException("Không tìm thấy sự kiện.");
            }

            // Bước 2: Kiểm tra xem người dùng đã đăng ký sự kiện này chưa
            var isAlreadyRegistered = await _registrationRepository.IsUserRegisteredAsync(eventId, userId);
            if (isAlreadyRegistered)
            {
                // Nếu đã đăng ký, báo lỗi.
                throw new InvalidOperationException("Bạn đã đăng ký sự kiện này rồi.");
            }

            // Bước 3: Kiểm tra xem sự kiện còn vé không
            var currentRegistrations = await _registrationRepository.GetRegistrationCountForEventAsync(eventId);
            if (currentRegistrations >= eventDetails.TicketLimit)
            {
                // Nếu hết vé, báo lỗi.
                throw new InvalidOperationException("Sự kiện đã hết vé.");
            }

            // Bước 4: Nếu tất cả kiểm tra đều hợp lệ, tạo bản ghi đăng ký mới
            var newRegistration = new Registration
            {
                EventId = eventId,
                UserId = userId,
                RegistrationDate = DateTime.UtcNow // Luôn dùng UTC cho thời gian trên server
            };

            await _registrationRepository.RegisterAsync(newRegistration);
        }
    }
}


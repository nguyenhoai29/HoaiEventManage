using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HoaiEventManager.CoreBusiness.Models;
using HoaiEventManager.UseCases.DataTransferObjects;


namespace HoaiEventManager.UseCases.Interfaces
{
    public interface IRegistrationRepository
    {
        // Đếm số lượng đăng ký hiện tại của một sự kiện
        Task<int> GetRegistrationCountForEventAsync(int eventId);

        // Kiểm tra xem một người dùng đã đăng ký sự kiện này chưa
        Task<bool> IsUserRegisteredAsync(int eventId, string userId);

        // Thực hiện đăng ký
        Task RegisterAsync(Registration registration);

        // Sửa đổi phương thức này
        Task<IEnumerable<AttendeeDto>> GetAttendeesForEventAsync(int eventId);
        // Thêm phương thức mới
        Task UnregisterAsync(int eventId, string userId);

        Task<IEnumerable<Event>> GetRegisteredEventsForUserAsync(string userId);

    }
}


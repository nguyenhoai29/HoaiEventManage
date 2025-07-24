using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HoaiEventManager.UseCases.Interfaces;
using System.Threading.Tasks;

namespace HoaiEventManager.UseCases.Registrations
{
    public class UnregisterForEventUseCase
    {
        private readonly IRegistrationRepository _registrationRepository;

        public UnregisterForEventUseCase(IRegistrationRepository registrationRepository)
        {
            _registrationRepository = registrationRepository;
        }

        public async Task ExecuteAsync(int eventId, string userId)
        {
            // Kiểm tra các điều kiện nghiệp vụ nếu cần (ví dụ: không cho hủy khi sự kiện đang diễn ra)
            // Trong trường hợp này, chúng ta cho phép hủy trực tiếp.
            await _registrationRepository.UnregisterAsync(eventId, userId);
        }
    }
}

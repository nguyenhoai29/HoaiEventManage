using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HoaiEventManager.CoreBusiness.Models;
using HoaiEventManager.UseCases.DataTransferObjects; // Sửa using
using HoaiEventManager.UseCases.Interfaces;


namespace HoaiEventManager.UseCases.Registrations
{
    public class ViewAttendeesUseCase
    {
        private readonly IRegistrationRepository _registrationRepository;

        public ViewAttendeesUseCase(IRegistrationRepository registrationRepository)
        {
            _registrationRepository = registrationRepository;
        }

        public async Task<IEnumerable<AttendeeDto>> ExecuteAsync(int eventId)
        {
            return await _registrationRepository.GetAttendeesForEventAsync(eventId);
        }
    }
}

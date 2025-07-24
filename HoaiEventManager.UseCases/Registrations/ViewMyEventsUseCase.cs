using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HoaiEventManager.CoreBusiness.Models;
using HoaiEventManager.UseCases.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HoaiEventManager.UseCases.Registrations
{
    public class ViewMyEventsUseCase
    {
        private readonly IRegistrationRepository _registrationRepository;

        public ViewMyEventsUseCase(IRegistrationRepository registrationRepository)
        {
            _registrationRepository = registrationRepository;
        }

        public async Task<IEnumerable<Event>> ExecuteAsync(string userId)
        {
            return await _registrationRepository.GetRegisteredEventsForUserAsync(userId);
        }
    }
}
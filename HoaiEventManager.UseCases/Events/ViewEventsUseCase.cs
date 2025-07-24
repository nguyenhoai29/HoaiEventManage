using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HoaiEventManager.CoreBusiness.Models;
using HoaiEventManager.UseCases.Interfaces;

namespace HoaiEventManager.UseCases.Events
{
    public class ViewEventsUseCase
    {
        private readonly IEventRepository _eventRepository;

        public ViewEventsUseCase(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<IEnumerable<Event>> ExecuteAsync()
        {
            return await _eventRepository.GetAllEventsAsync();
        }
    }
}

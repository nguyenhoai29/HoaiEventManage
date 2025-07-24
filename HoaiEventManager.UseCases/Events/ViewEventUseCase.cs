using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HoaiEventManager.CoreBusiness.Models;
using HoaiEventManager.UseCases.Interfaces;

namespace HoaiEventManager.UseCases.Events
{
    public class ViewEventUseCase
    {
        private readonly IEventRepository _eventRepository;

        public ViewEventUseCase(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<Event?> ExecuteAsync(int eventId)
        {
            return await _eventRepository.GetEventByIdAsync(eventId);
        }
    }
}

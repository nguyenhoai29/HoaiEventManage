using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HoaiEventManager.CoreBusiness.Models;
using HoaiEventManager.UseCases.Interfaces;

namespace HoaiEventManager.UseCases.Events
{
    public class CreateEventUseCase
    {
        private readonly IEventRepository _eventRepository;

        public CreateEventUseCase(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task ExecuteAsync(Event newEvent)
        {
            await _eventRepository.CreateEventAsync(newEvent);
        }
    }
}

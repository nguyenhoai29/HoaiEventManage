using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HoaiEventManager.CoreBusiness.Models;
using HoaiEventManager.UseCases.Interfaces;

namespace HoaiEventManager.UseCases.Events
{
    public class UpdateEventUseCase
    {
        private readonly IEventRepository _eventRepository;

        public UpdateEventUseCase(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task ExecuteAsync(Event eventToUpdate)
        {
            await _eventRepository.UpdateEventAsync(eventToUpdate);
        }
    }
}
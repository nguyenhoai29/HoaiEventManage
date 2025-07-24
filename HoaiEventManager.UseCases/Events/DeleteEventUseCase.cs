using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HoaiEventManager.UseCases.Interfaces;

namespace HoaiEventManager.UseCases.Events
{
    public class DeleteEventUseCase
    {
        private readonly IEventRepository _eventRepository;

        public DeleteEventUseCase(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task ExecuteAsync(int eventId)
        {
            await _eventRepository.DeleteEventAsync(eventId);
        }
    }
}

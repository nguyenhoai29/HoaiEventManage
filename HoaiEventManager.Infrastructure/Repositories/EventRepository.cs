using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HoaiEventManager.CoreBusiness.Models;
using HoaiEventManager.Infrastructure.Data;
using HoaiEventManager.UseCases.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HoaiEventManager.Infrastructure.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly AppDbContext _context;

        public EventRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateEventAsync(Event newEvent)
        {
            _context.Events.Add(newEvent);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEventAsync(int eventId)
        {
            var eventToDelete = await _context.Events.FindAsync(eventId);
            if (eventToDelete != null)
            {
                _context.Events.Remove(eventToDelete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Event>> GetAllEventsAsync()
        {
            return await _context.Events.AsNoTracking().ToListAsync();
        }

        public async Task<Event?> GetEventByIdAsync(int eventId)
        {
            return await _context.Events.AsNoTracking().FirstOrDefaultAsync(e => e.Id == eventId);
        }

        public async Task UpdateEventAsync(Event eventToUpdate)
        {
            // Entity Framework sẽ tự động theo dõi sự thay đổi của đối tượng này
            // khi nó được lấy ra từ context. Tuy nhiên, nếu đối tượng được tạo mới
            // hoặc không được theo dõi, bạn cần phải đánh dấu nó là đã thay đổi.
            _context.Events.Update(eventToUpdate);
            await _context.SaveChangesAsync();
        }
    }
}
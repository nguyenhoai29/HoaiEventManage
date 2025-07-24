using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HoaiEventManager.CoreBusiness.Models;
using HoaiEventManager.Infrastructure.Data;
using HoaiEventManager.UseCases.Interfaces;
using Microsoft.EntityFrameworkCore;
using HoaiEventManager.UseCases.DataTransferObjects;

namespace HoaiEventManager.Infrastructure.Repositories
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly AppDbContext _context;

        public RegistrationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> GetRegistrationCountForEventAsync(int eventId)
        {
            return await _context.Registrations.CountAsync(r => r.EventId == eventId);
        }

        public async Task<bool> IsUserRegisteredAsync(int eventId, string userId)
        {
            return await _context.Registrations
                .AnyAsync(r => r.EventId == eventId && r.UserId == userId);
        }

        public async Task RegisterAsync(Registration registration)
        {
            _context.Registrations.Add(registration);
            await _context.SaveChangesAsync();
        }
        // Sửa đổi phương thức này
        public async Task<IEnumerable<AttendeeDto>> GetAttendeesForEventAsync(int eventId)
        {
            // Sử dụng LINQ để join 2 bảng và map kết quả sang DTO
            var query = from reg in _context.Registrations
                        join user in _context.Users on reg.UserId equals user.Id
                        where reg.EventId == eventId
                        orderby reg.RegistrationDate descending
                        select new AttendeeDto
                        {
                            FullName = user.FullName,
                            Email = user.Email ?? "N/A", // Xử lý trường hợp email có thể null
                            RegistrationDate = reg.RegistrationDate
                        };

            return await query.AsNoTracking().ToListAsync();
        }
        // Thêm phương thức mới
        public async Task UnregisterAsync(int eventId, string userId)
        {
            var registration = await _context.Registrations
                .FirstOrDefaultAsync(r => r.EventId == eventId && r.UserId == userId);

            if (registration != null)
            {
                _context.Registrations.Remove(registration);
                await _context.SaveChangesAsync();
            }
        }

        // Thêm phương thức mới
public async Task<IEnumerable<Event>> GetRegisteredEventsForUserAsync(string userId)
        {
            var query = from reg in _context.Registrations
                        join evt in _context.Events on reg.EventId equals evt.Id
                        where reg.UserId == userId
                        orderby evt.Date descending
                        select evt;

            return await query.AsNoTracking().ToListAsync();
        }
    }
}


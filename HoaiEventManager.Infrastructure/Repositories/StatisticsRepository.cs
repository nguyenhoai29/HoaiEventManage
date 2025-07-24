using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HoaiEventManager.Infrastructure.Data;
using HoaiEventManager.UseCases.Interfaces;
using HoaiEventManager.UseCases.Statistics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HoaiEventManager.Infrastructure.Repositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly AppDbContext _context;

        public StatisticsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<DashboardStatsDto> GetDashboardStatisticsAsync()
        {
            var today = DateTime.Today;

            var top5Events = await _context.Events
                .Select(e => new TopEventDto
                {
                    EventId = e.Id,
                    EventName = e.Name,
                    RegistrationCount = _context.Registrations.Count(r => r.EventId == e.Id)
                })
                .OrderByDescending(e => e.RegistrationCount)
                .Take(5)
                .ToListAsync();

            var stats = new DashboardStatsDto
            {
                TotalUsers = await _context.Users.CountAsync(),
                TotalEvents = await _context.Events.CountAsync(),
                UpcomingEvents = await _context.Events.CountAsync(e => e.Date >= today),
                PastEvents = await _context.Events.CountAsync(e => e.Date < today),
                Top5EventsByRegistration = top5Events
            };

            return stats;
        }
    }
}
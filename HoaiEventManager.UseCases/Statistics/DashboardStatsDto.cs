using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoaiEventManager.UseCases.Statistics
{
    public class DashboardStatsDto
    {
        public int TotalUsers { get; set; }
        public int TotalEvents { get; set; }
        public int UpcomingEvents { get; set; }
        public int PastEvents { get; set; }
        public List<TopEventDto> Top5EventsByRegistration { get; set; } = new List<TopEventDto>();
    }
}


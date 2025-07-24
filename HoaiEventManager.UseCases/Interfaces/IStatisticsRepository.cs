using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HoaiEventManager.UseCases.Statistics;
using System.Threading.Tasks;

namespace HoaiEventManager.UseCases.Interfaces
{
    public interface IStatisticsRepository
    {
        Task<DashboardStatsDto> GetDashboardStatisticsAsync();
    }
}


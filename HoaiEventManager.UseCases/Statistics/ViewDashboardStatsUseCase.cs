using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HoaiEventManager.UseCases.Interfaces;
using System.Threading.Tasks;

namespace HoaiEventManager.UseCases.Statistics
{
    public class ViewDashboardStatsUseCase
    {
        private readonly IStatisticsRepository _statisticsRepository;

        public ViewDashboardStatsUseCase(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        public async Task<DashboardStatsDto> ExecuteAsync()
        {
            return await _statisticsRepository.GetDashboardStatisticsAsync();
        }
    }
}


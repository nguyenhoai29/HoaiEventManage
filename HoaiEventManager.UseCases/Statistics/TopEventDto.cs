using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoaiEventManager.UseCases.Statistics
{
    public class TopEventDto
    {
        public int EventId { get; set; }
        public string EventName { get; set; } = string.Empty;
        public int RegistrationCount { get; set; }
    }
}
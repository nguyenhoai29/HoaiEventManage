using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoaiEventManager.CoreBusiness.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Location { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int TicketLimit { get; set; }
        public string? CreatedById { get; set; } // Khóa ngoại tới ApplicationUser
        public string? ImageUrl { get; set; }
    }

}

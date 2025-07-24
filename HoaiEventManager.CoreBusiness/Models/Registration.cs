using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoaiEventManager.CoreBusiness.Models
{
    public class Registration
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public DateTime RegistrationDate { get; set; }

        // Navigation properties
        public Event? Event { get; set; }
    }

}

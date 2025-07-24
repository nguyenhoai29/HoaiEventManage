using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoaiEventManager.Infrastructure.Data
{
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser
    {
        // Thêm các thuộc tính tùy chỉnh cho người dùng ở đây, ví dụ:
        // public string FullName { get; set; }
        public string FullName { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }
    }
}

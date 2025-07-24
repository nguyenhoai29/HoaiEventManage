#nullable disable

using System.Threading.Tasks;
using HoaiEventManager.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace HoaiEventManager.WebApp.Areas.Identity.Pages.Account
{
    // THÊM DÒNG NÀY ĐỂ BỎ QUA KIỂM TRA ANTI-FORGERY TOKEN
    // Đây là giải pháp trực tiếp cho lỗi HTTP 400 khi đăng xuất từ Blazor.
    [IgnoreAntiforgeryToken]
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LogoutModel> _logger;

        public LogoutModel(SignInManager<ApplicationUser> signInManager, ILogger<LogoutModel> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

        // Quay lại sử dụng OnPost vì đó là phương thức đúng cho form
        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                // Sau khi đăng xuất, chuyển hướng về trang chủ
                return Redirect("~/");
            }
        }
    }
}
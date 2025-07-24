// ===== Các using cần thiết cho toàn bộ ứng dụng =====
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using HoaiEventManager.Infrastructure.Data;
using HoaiEventManager.UseCases.Interfaces;
using HoaiEventManager.Infrastructure.Repositories;
using HoaiEventManager.UseCases.Events;
using HoaiEventManager.UseCases.Registrations;
using HoaiEventManager.WebApp.Areas.Identity;
using Blazored.Toast;
using HoaiEventManager.UseCases.Statistics;


var builder = WebApplication.CreateBuilder(args);

// ==========================================================
// ===== PHẦN 1: Cấu hình các dịch vụ (Services) ==========
// ==========================================================

// --- 1.1 Cấu hình Database và Identity ---
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// Đăng ký AppDbContext với chuỗi kết nối SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// Đăng ký dịch vụ Identity, sử dụng lớp ApplicationUser tùy chỉnh.
// Dòng này đã bao gồm cả AddAuthentication nên không cần gọi riêng.
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>() // Thêm hỗ trợ Roles
    .AddEntityFrameworkStores<AppDbContext>();

// Thêm bộ lọc ngoại lệ cho trang phát triển DB (hữu ích khi có lỗi migration)
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// --- 1.2 Đăng ký các dịch vụ của ứng dụng (Repositories và Use Cases) ---
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IRegistrationRepository, RegistrationRepository>();

builder.Services.AddTransient<ViewEventsUseCase>();
builder.Services.AddTransient<CreateEventUseCase>();
builder.Services.AddTransient<ViewEventUseCase>();
builder.Services.AddTransient<UpdateEventUseCase>();
builder.Services.AddTransient<DeleteEventUseCase>();
builder.Services.AddTransient<RegisterForEventUseCase>();
builder.Services.AddTransient<UnregisterForEventUseCase>();
builder.Services.AddTransient<ViewMyEventsUseCase>();
builder.Services.AddTransient<ViewAttendeesUseCase>();

builder.Services.AddScoped<IStatisticsRepository, StatisticsRepository>();
builder.Services.AddTransient<ViewDashboardStatsUseCase>();

// --- 1.3 Đăng ký dịch vụ cho Blazor và Xác thực ---
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<ApplicationUser>>();
builder.Services.AddBlazoredToast();

// =================================================================
// ===== PHẦN 2: Cấu hình pipeline xử lý HTTP request (Middleware) =====
// =================================================================
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Bật xác thực và phân quyền
// UseAuthentication phải được gọi trước UseAuthorization
app.UseAuthentication();
app.UseAuthorization();

// Map các endpoints
app.MapControllers(); // Cần thiết cho các trang Identity scaffolding
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

// ================================================
// ===== PHẦN 3: Khởi tạo dữ liệu (Seeding) =====
// ================================================
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        // Gọi DbInitializer để tạo dữ liệu mẫu
        await DbInitializer.Initialize(services);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}

// ========================================
// ===== PHẦN 4: Chạy ứng dụng =====
// ========================================
app.Run();

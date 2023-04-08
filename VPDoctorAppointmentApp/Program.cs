using Repository.Infrastructure;
using Repository.Infrastructure.User;
using Identity;
using Repository;
using Services;
using VPDoctorAppointmentApp.BotClientCommandHandlers;
using VPDoctorAppointmentApp.Cache;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IDatabaseNameProvider, DatabaseNameProvider>();
builder.Services.AddScoped<ICacheRegistrationService, CacheRegistrationService>();
builder.Services.AddScoped<IClientCommandHandler, ClientCommandHandler>();
builder.Services.AddScoped<IRegisterStartCommandHandler, RegisterStartCommandHandler>();

builder.Services.AddDiIdentity();
builder.Services.AddDiServices();
builder.Services.AddDiRepository();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");



app.Run();
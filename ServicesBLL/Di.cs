
using Microsoft.Extensions.DependencyInjection;
using Services.BotCommand;
using Services.BotCommand.Handlers;
using ServicesBLL.BotCommand;
using ServicesBLL.Doctor;

namespace Services
{
    public static class DiRegistry
    {
        public static IServiceCollection AddDiServices(this IServiceCollection services)
        {
            services.AddScoped<IRegisterCommandHandler, RegisterCommandHandler>();
            services.AddScoped<ICommandHandler, CommandHandler>();
            services.AddScoped<IDoctorService, DoctorService>();
        
            return services;
        }
    }

}
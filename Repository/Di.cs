using Microsoft.Extensions.DependencyInjection;
using Repository.Doctor;

namespace Repository
{
    public static class DiRegistry
    {
        public static IServiceCollection AddDiRepository(this IServiceCollection services)
        {
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            
            return services;
        }
    }

}
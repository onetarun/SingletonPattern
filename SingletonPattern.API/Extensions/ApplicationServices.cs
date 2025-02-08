using SingletonPattern.Domain.Interfaces;
using SingletonPattern.Infrastructure.Implementations;

namespace SingletonPattern.API.Extensions
{
    public static class ApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Register SqlHelper as Scoped (per request)
            services.AddScoped<ISqlHelper, SqlHelper>();
            services.AddScoped<IUtilityService, UtilityService>();
            // Register Repositories
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IStateRepository, StateRepository>();
           services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            return services;
        }

    }
}

using Clean.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Clean.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DemoDbContext>(options =>
                           options.UseSqlServer(configuration.GetConnectionString("DemoDbConnectionString")));

            services.AddScoped(typeof(Application.Contracts.IRepository<>), typeof(BaseRepository<>));

            services.AddScoped<Application.Contracts.IStudentRepository, StudentRepository>();

            return services;
        }
    }
}

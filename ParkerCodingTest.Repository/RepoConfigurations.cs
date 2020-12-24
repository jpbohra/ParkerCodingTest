using Microsoft.Extensions.DependencyInjection;
using ParkerCodingTest.Repository.Employee;

namespace ParkerCodingTest.Repository
{
    public static class RepoConfigurations
    {
        public static IServiceCollection AddRepoConfigurations(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepo, EmployeeRepo>();

            return services;
        }
    }
}

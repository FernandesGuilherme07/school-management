using Microsoft.Extensions.DependencyInjection;
using school_management.Application.repositories;
using school_management.infrastructure.repository;

namespace school_management.infrastructure
{
    public static class InfraestructureModule
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ISchoolSubjectRepository, SchoolSubjectRepository>();

            return services;
        }
    }
}

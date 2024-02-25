using Microsoft.Extensions.DependencyInjection;
using school_management.Application.use_cases;
using school_management.Application.use_cases.contracts;

namespace school_management.Application
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<ICreateSchoolSubjectUseCase, CreateSchoolSubjectUseCase>();
            services.AddScoped<IDeleteSchoolSubjectUseCase, DeleteSchoolSubjectUseCase>();
            services.AddScoped<IGetAllSchoolSubjectsUSeCase, GetAllSchoolSubjectsUSeCase>();
            services.AddScoped<IShowSchoolSubjectByIdUseCase, ShowSchoolSubjectByIdUseCase>();
            services.AddScoped<ICreatestudentUseCase, CreatestudentUseCase>();
            services.AddScoped<IDeletestudentUseCase, DeletestudentUseCase>();
            services.AddScoped<IGetAllstudentsUseCase, GetAllStudentsUseCase>();
            services.AddScoped<IEnrollStudentInSubjectUseCase, EnrollStudentInSubjectUseCase>();
            services.AddScoped<IShowStudentByIdUseCase, ShowStudentByIdUseCase>();
            services.AddScoped<IUpdatestudentDataUseCase, UpdatestudentDataUseCase>();

            return services;
        }
    }
}

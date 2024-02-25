using school_management.Application.repositories;
using school_management.Application.use_cases.contracts;
using school_management.shared.view_models;

namespace school_management.Application.use_cases
{
    public class GetAllStudentsUseCase(IStudentRepository studentRepository) : IGetAllstudentsUseCase
    {
        private readonly IStudentRepository _studentRepository = studentRepository;
        public async Task<ApplicationViewModel> Execute()
        {
            var result = await _studentRepository.GetAllstudentsAsync();

            return new ApplicationViewModel("consultation carried out successfully", true, result, null);
        }
    }
}

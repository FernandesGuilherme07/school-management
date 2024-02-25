using school_management.Application.repositories;
using school_management.Application.use_cases.contracts;
using school_management.shared.view_models;

namespace school_management.Application.use_cases
{
    public class ShowStudentByIdUseCase(IStudentRepository studentRepository) : IShowStudentByIdUseCase
    {
        private readonly IStudentRepository _studentRepository = studentRepository;
        public async Task<ApplicationViewModel> Execute(Guid studentId)
        {
            var studentIdExists = await _studentRepository.GetstudentByIdAsync(studentId);

            if (studentIdExists == null)
            {
                return new ApplicationViewModel("student id already exists", false, null, null);
            }

            return new ApplicationViewModel("consultation carried out successfully", true, studentIdExists, null);
        }
    }
}

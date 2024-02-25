using school_management.Application.repositories;
using school_management.Application.use_cases.contracts;
using school_management.shared.view_models;

namespace school_management.Application.use_cases
{
    public class DeletestudentUseCase(IStudentRepository studentRepository) : IDeletestudentUseCase
    {
        private readonly IStudentRepository _studentRepository = studentRepository;
        public async Task<ApplicationViewModel> Execute(Guid id)
        {
            var studentIdAlreadyExists = await _studentRepository.GetstudentByIdAsync(id);

            if (studentIdAlreadyExists == null)
            {
                return new ApplicationViewModel("studentid already exists", false, null, null);
            }

            await _studentRepository.DeletestudentAsync(id);

            return new ApplicationViewModel("student successfully deleted", true, null, null);
        }
    }
}

using school_management.Application.repositories;
using school_management.shared.input_models;
using school_management.shared.view_models;

namespace school_management.Application.use_cases
{
    public class UpdatestudentDataUseCase(IStudentRepository studentRepository) : IUpdatestudentDataUseCase
    {
        private readonly IStudentRepository _studentRepository = studentRepository;

        public async Task<ApplicationViewModel> Execute(UpdatestudentInputModel data)
        {
            var studentDataIsInvalid = data.ToEntity().Notifications.Count() > 0;

            if (studentDataIsInvalid)
            {
                return new ApplicationViewModel("Invalid data", false, null, data.ToEntity().Notifications);
            }

            var studentAlreadyExists = await _studentRepository.GetstudentByIdAsync(data.Id);

            if(studentAlreadyExists == null)
            {
                return new ApplicationViewModel("the id sent does not belong to any registered student", false, null, null);
            }

            await _studentRepository.UpdatestudentAsync(data);

            return new ApplicationViewModel("student data updated successfully", true, null, null);
        }
    }
}

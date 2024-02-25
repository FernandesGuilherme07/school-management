using school_management.Application.repositories;
using school_management.shared.input_models;
using school_management.shared.view_models;

namespace school_management.Application.use_cases
{
    public class CreatestudentUseCase(IStudentRepository studentRepository, ISchoolSubjectRepository schoolSubjectRepository) : ICreatestudentUseCase
    {
        private readonly ISchoolSubjectRepository _schoolSubjectRepository = schoolSubjectRepository;
        private readonly IStudentRepository _studentRepository = studentRepository;
        public async Task<ApplicationViewModel> Execute(AddstudentInputModel data)
        {
            var studentDataIsInvalid = data.ToEntity().Notifications.Count() > 0;

            if( studentDataIsInvalid )
            {
                return new ApplicationViewModel("Invalid data", false, null, data.ToEntity().Notifications);
            }

            var emailAlreadyExists = await _studentRepository.GetstudentEmailAsync(data.ToEntity().Email);

            if(emailAlreadyExists != null )
            {
                return new ApplicationViewModel("This email is already registered for another student", false, null, null);
            }

            if(data.SchoolSubjects != null && data.SchoolSubjects.Count() > 0 )
            {
                foreach (var item in data.SchoolSubjects)
                {
                    var SchoolSubjectExist = await _schoolSubjectRepository.GetASchoolSubjectByIdAsync(item.Id);

                    if( SchoolSubjectExist == null )
                    {
                        data.ToEntity().AddNotification("There is no material registered with this id " + item.Id.ToString());
                    }
                };

                if(data.ToEntity().Notifications.Count() > 0)
                {
                    return new ApplicationViewModel("Invalid data", false, null, data.ToEntity().Notifications);
                }

            }

            await _studentRepository.AddstudentAsync(data);

            return new ApplicationViewModel("Student successfully registered", true, null, null);

        }

    }
}

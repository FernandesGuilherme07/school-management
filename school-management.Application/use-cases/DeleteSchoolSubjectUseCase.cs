using school_management.Application.repositories;
using school_management.shared.view_models;

namespace school_management.Application.use_cases
{
    public class DeleteSchoolSubjectUseCase(ISchoolSubjectRepository schoolSubjectRepository) : IDeleteSchoolSubjectUseCase
    {
        private readonly ISchoolSubjectRepository _schoolSubjectRepository = schoolSubjectRepository;
        public async Task<ApplicationViewModel> Execute(Guid Id)
        {
            var schoolSubjectIdAlreadyExists = await _schoolSubjectRepository.GetASchoolSubjectByIdAsync(Id);

            if(schoolSubjectIdAlreadyExists == null)
            {
                return new ApplicationViewModel("school subject id already exists", false, null, null);
            }

            if(schoolSubjectIdAlreadyExists.Students.Count > 0)
            {
                return new ApplicationViewModel("It is not possible to delete a subject that contains enrolled students", false, null, null);
            }

            await _schoolSubjectRepository.DeletestudentAsync(Id);

            return new ApplicationViewModel("school subject successfully deleted", true, null, null);

        }
    }
}

using school_management.Application.repositories;
using school_management.shared.input_models;
using school_management.shared.view_models;

namespace school_management.Application.use_cases
{
    public class CreateSchoolSubjectUseCase(ISchoolSubjectRepository schoolSubjectRepository) : ICreateSchoolSubjectUseCase
    {
        private readonly ISchoolSubjectRepository _schoolSubjectRepository = schoolSubjectRepository;

        public async Task<ApplicationViewModel> Execute(AddSchoolSubjectInputModel data)
        {
            var isInvalidData = data.ToEntity().Notifications.Count() > 0;

            if(isInvalidData)
            {
                return new ApplicationViewModel("Invalid data", false, null, data.ToEntity().Notifications);
            }

            var schoolSubjectExists = await _schoolSubjectRepository.GetASchoolSubjectByNameAsync(data.Name);

            if(schoolSubjectExists != null)
            {
                return new ApplicationViewModel("There is already a school subject registered with this name", false, null, null);
            }

            await _schoolSubjectRepository.AddSchoolSubjectAsync(data);

            return new ApplicationViewModel("school subject created successfully", true, null, null);

        }
    }
}

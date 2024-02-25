using school_management.Application.repositories;
using school_management.Application.use_cases.contracts;
using school_management.shared.view_models;

namespace school_management.Application.use_cases
{
    public class ShowSchoolSubjectByIdUseCase(ISchoolSubjectRepository schoolSubjectRepository) : IShowSchoolSubjectByIdUseCase
    {
        private readonly ISchoolSubjectRepository _schoolSubjectRepository = schoolSubjectRepository;
        public async Task<ApplicationViewModel> Execute(Guid SchoolSubjectId)
        {
            var SchoolSubjectIdExists = await _schoolSubjectRepository.GetASchoolSubjectByIdAsync(SchoolSubjectId);

            if(SchoolSubjectIdExists == null)
            {
                return new ApplicationViewModel("school subject id already exists", false, null, null);
            }

            return new ApplicationViewModel("consultation carried out successfully", true, SchoolSubjectIdExists, null);
        }
    }
}

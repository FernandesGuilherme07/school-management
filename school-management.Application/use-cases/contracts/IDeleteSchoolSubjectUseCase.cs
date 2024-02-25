using school_management.shared.view_models;

namespace school_management.Application.use_cases
{
    public interface IDeleteSchoolSubjectUseCase
    {
       Task<ApplicationViewModel> Execute(Guid Id);
    }
}

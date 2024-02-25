using school_management.shared.input_models;
using school_management.shared.view_models;

namespace school_management.Application.use_cases
{
    public interface ICreateSchoolSubjectUseCase
    {
        Task<ApplicationViewModel> Execute(AddSchoolSubjectInputModel data);
    }
}

using school_management.shared.view_models;

namespace school_management.Application.use_cases.contracts
{
    public interface IDeletestudentUseCase
    {
        Task<ApplicationViewModel> Execute(Guid id);
    }
}

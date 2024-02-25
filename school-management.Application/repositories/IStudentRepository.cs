using school_management.shared.input_models;
using school_management.shared.view_models;

namespace school_management.Application.repositories
{
    public interface IStudentRepository
    {
        Task AddstudentAsync(AddstudentInputModel data);
        Task<IList<studentViewModel>> GetAllstudentsAsync();
        Task<studentViewModel> GetstudentByIdAsync(Guid id);
        Task<studentViewModel>? GetstudentEmailAsync(string email);
        Task RegisterMaterialForStudentAsync(RegisterMaterialForStudentInputModel data);
        Task UpdatestudentAsync(UpdatestudentInputModel data);
        Task DeletestudentAsync(Guid id);
    }
}

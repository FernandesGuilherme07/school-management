using school_management.shared.input_models;
using school_management.shared.view_models;

namespace school_management.Application.repositories
{
    public interface ISchoolSubjectRepository
    {
        Task AddSchoolSubjectAsync(AddSchoolSubjectInputModel data);
        Task<IList<SchoolSubjectViewModel>> GetAllSchoolSubjectsAsync();
        Task<SchoolSubjectViewModel> GetASchoolSubjectByIdAsync(Guid id);
        Task<SchoolSubjectViewModel> GetASchoolSubjectByNameAsync(string name);
        Task<SchoolSubjectWithStudentsViewModel> GetSchoolSubjectWithStudentsAsync(Guid schoolSubjectId);
        Task<bool> checkIfThereIsRelationship(RegisterMaterialForStudentInputModel inputModel);
        Task DeletestudentAsync(Guid id);
    }
}

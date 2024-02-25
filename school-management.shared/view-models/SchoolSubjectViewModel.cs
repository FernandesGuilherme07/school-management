using school_management.shared.models;

namespace school_management.shared.view_models
{
    public record SchoolSubjectViewModel(Guid Id, string Name, string? description, ICollection<StudentModel>? Students);
}

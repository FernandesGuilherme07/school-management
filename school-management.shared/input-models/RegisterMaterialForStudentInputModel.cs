namespace school_management.shared.input_models
{
    public class RegisterMaterialForStudentInputModel
    {
        public Guid StudentId { get; set; }
        public Guid SchoolSubjectId { get; set; }
    }
}

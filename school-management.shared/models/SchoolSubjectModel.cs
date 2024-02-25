namespace school_management.shared.models
{
    public class SchoolSubjectModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public ICollection<StudentModel>? Students { get; set; }
    }
}

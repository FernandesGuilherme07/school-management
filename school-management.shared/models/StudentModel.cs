namespace school_management.shared.models
{
    public class StudentModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public ICollection<SchoolSubjectModel>? SchoolSubjects { get; set; }
    }
}

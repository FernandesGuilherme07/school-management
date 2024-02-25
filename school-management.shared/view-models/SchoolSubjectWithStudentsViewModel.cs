using school_management.shared.models;

namespace school_management.shared.view_models
{
    public class SchoolSubjectWithStudentsViewModel
    {
        public SchoolSubjectModel SchoolSubject { get; set; }
        public List<StudentModel> Students { get; set; }
    }
}

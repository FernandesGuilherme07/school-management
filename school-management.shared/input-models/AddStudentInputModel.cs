using school_management.domain.entities;
using school_management.shared.models;

namespace school_management.shared.input_models
{
    public class AddstudentInputModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public ICollection<SchoolSubjectReferenceInputModel>? SchoolSubjects { get; set; }

        public AddstudentInputModel(string name, int age, string email)
        {
            Name = name;
            Age = age;
            Email = email;
        }

        public AddstudentInputModel() { }

        public Student ToEntity()
        {
            return new Student(Name, Age, Email);
        }
    }
}

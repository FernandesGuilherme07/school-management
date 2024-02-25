using school_management.domain.entities;

namespace school_management.shared.input_models
{
    public class UpdatestudentInputModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }

        public UpdatestudentInputModel(Guid id, string name, int age, string email)
        {
            Id = id;
            Name = name;
            Age = age;
            Email = email;
        }

        public UpdatestudentInputModel() {}

        public Student ToEntity()
        {
            return new Student(Name, Age, Email);
        }

    }
}

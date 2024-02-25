using school_management.domain.entities;

namespace school_management.shared.input_models
{
    public class AddSchoolSubjectInputModel
    {
        public string Name { get; set; }
        public string? Description { get; set; }

        public AddSchoolSubjectInputModel(string name, string? description)
        {
            Name = name;
            Description = description;
        }

        public AddSchoolSubjectInputModel() {}

        public Schoolsubject ToEntity()
        {
            return new Schoolsubject(Name, Description);
        }
    }
}

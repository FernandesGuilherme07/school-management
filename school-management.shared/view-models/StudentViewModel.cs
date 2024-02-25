using school_management.shared.models;

namespace school_management.shared.view_models
{
    public record studentViewModel

    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public ICollection<SchoolSubjectViewModel>? SchoolSubjects { get; set; }

        public studentViewModel(Guid id, string name, int age, string email, ICollection<SchoolSubjectModel>? schoolSubjects)
        {
            var schoolSubjectsList = new List<SchoolSubjectViewModel>();

            if (schoolSubjects.Count > 0)
            {
                schoolSubjects.ToList().ForEach(data => schoolSubjectsList.Add(new SchoolSubjectViewModel(data.Id, data.Name, data.Description, null)));
            }

             Id = id;
            Name = name;
            Age = age;
            Email = email;
            SchoolSubjects = schoolSubjectsList;
        }

        public ICollection<SchoolSubjectModel>? SchoolSubjects1 { get; }
    }
}

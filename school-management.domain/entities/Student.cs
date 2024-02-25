namespace school_management.domain.entities
{
    public class Student : Entity
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Email { get; private set; }



        public Student(string name, int age, string email) 
        {
            Name = name;
            Age = age;
            Email = email;

            IsRequired(name, "name is mandatory")
                .HasMaxLength(name, 70, "name can only have a maximum of 70 characters")
                .HasMinLength(name, 2, "the name must have at least 3 characters");
            IsRequired(Email, "name is mandatory")
                .IsValidEmail(email, "the email entered is not valid");
            IsRequired(Age, "age is mandatory");
        }

    }
}

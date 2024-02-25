namespace school_management.domain.entities
{
    public class Schoolsubject : Entity
    {
        public string Name { get; private set; }
        public string? Description { get; private set; }

        public Schoolsubject(string name, string? description)
        {
            Name = name;
            Description = description;
            IsRequired(name, "name is mandatory")
            .HasMaxLength(name, 55, "name can only have a maximum of 55 characters")
            .HasMinLength(name, 3, "the name must have at least 3 characters");
        }

    }
}

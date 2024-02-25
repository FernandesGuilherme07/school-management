using school_management.domain.fluent_validations;

namespace school_management.domain.entities
{
    public class Entity: Notifiable
    {
        public Guid Id { get; private set; }
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

    }
}

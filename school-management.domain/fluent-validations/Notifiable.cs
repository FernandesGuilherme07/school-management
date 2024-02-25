using System.Text.RegularExpressions;

namespace school_management.domain.fluent_validations
{
    public class Notifiable
    {
        public IList<string> Notifications { get; set; }

        protected Notifiable()
        {
            Notifications = new List<string>();
        }

        public Notifiable AddNotification(string notification)
        {
            Notifications.Add(notification);
            return this;
        }

        public Notifiable IsRequired(object name, string notidication)
        {
            if(name == null)
            {
                AddNotification(notidication);
            }
            return this;
        }

        public Notifiable HasMinLength(string data, int minLength, string notification)
        {
            if(data.Length < minLength)
            {
                AddNotification(notification);
            }
            return this;
        }

        public Notifiable HasMaxLength(string data, int maxLength, string notification)
        {
            if (data.Length > maxLength)
            {
                AddNotification(notification);
            }
            return this;
        }

        public Notifiable IsValidEmail(string email, string notification)
        {
            // Use regular expression to validate email
            string emailPattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            if (!Regex.IsMatch(email, emailPattern))
            {
                AddNotification(notification);
            }
            return this;
        }
    }
}


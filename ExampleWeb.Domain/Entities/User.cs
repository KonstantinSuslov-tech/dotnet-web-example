using ExampleWeb.Domain.Entities;

namespace ExampleWeb.Domain.Entities
{
    public class User 
    {
        public User(string firstName, string lastName, List<Contact> contacts, Passport passport)
        {
            FirstName = firstName;
            LastName = lastName;
            Contacts = contacts;
            Passport = passport;
        }

        public int Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public int PassportId { get; private set; } 

        public List<Contact> Contacts { get; private set; }

        public Passport Passport { get; private set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleWeb.Domain.Entities
{
    public class Contact
    {
        public Contact(string email, string phone)
        {
            Email = email;
            Phone = phone;
        }

        public int Id { get; private set; }

        public int UserId { get; private set; }

        public string Email { get; private set; }

        public string Phone { get; private set; }

        public User User { get; private set; }
    }
}

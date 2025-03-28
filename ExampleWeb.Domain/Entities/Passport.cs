using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleWeb.Domain.Entities
{
    public class Passport
    {
        public Passport(int number, int series, DateTimeOffset issueDate, DateTimeOffset birthday)
        {
            Number = number;
            Series = series;
            IssueDate = issueDate;
            Birthday = birthday;
        }


        public User User { get; set; }

        public int Id { get; private set; }

        public int Number { get; private set; }

        public int Series { get; private set; }

        public DateTimeOffset  IssueDate { get; private set; }

        public DateTimeOffset Birthday { get; private set; }

    }
}

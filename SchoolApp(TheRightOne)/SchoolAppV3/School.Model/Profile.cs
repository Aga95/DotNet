using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Model
{
    public class Profile
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public int Weight { get; set; }

        public virtual List<Day> Days { get; set; }

        public Profile(int Id, string FirstName, string LastName, int Age, int Weight)
        {
            this.Id = Id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Age = Age;
            this.Weight = Weight;
        }
    }
}

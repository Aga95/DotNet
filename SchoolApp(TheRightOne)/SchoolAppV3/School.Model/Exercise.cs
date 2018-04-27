using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Model
{
    public class Exercise
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Lifted { get; set; }

        public string Sets { get; set; }

        public Exercise(int id, string name, string lifted, string sets)
        {
            this.Id = id;
            this.Name = name;
            this.Lifted = lifted;
            this.Sets = Sets;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBuddy.Model
{
    public class Exercise
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Lifted { get; set; }

        public int Sets { get; set; }

        public Exercise(int id, string name, int lifted, int sets)
        {
            this.Id = id;
            this.Name = name;
            this.Lifted = lifted;
            this.Sets = Sets;
        }
        public Exercise()
        {

        }
    }
}

using GymBuddy.DataAccess;
using GymBuddy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBuddy.ConsoleTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (GymContext context = new GymContext())
            {
                var aga = new Profile(1, "Aga", "Hussein", 22, 110);

                context.Profiles.Add(aga);

                context.SaveChanges();

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}

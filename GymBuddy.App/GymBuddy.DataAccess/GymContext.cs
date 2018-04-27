using GymBuddy.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBuddy.DataAccess
{
    public class GymContext : DbContext
    {

        public virtual DbSet<Exercise> Exercises { get; set; }

        public virtual DbSet<Day> Days { get; set; }

        public virtual DbSet<Profile> Profiles { get; set; }

        public GymContext() :
            base(@"Data Source=donau.hiof.no;Initial Catalog=agahh;User ID=agahh;Password=AfQ3T1")
        {
            Configuration.ProxyCreationEnabled = false;

            Database.SetInitializer(new GymDBInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}

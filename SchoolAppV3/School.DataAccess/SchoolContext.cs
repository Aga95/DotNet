using School.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataAccess
{
    public partial class SchoolContext : DbContext
    {
        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<Course> Courses { get; set; }

        public SchoolContext() :
            base(@"Data Source=donau.hiof.no;Initial Catalog=agahh;User ID=agahh;Password=AfQ3T1")
        {
            Configuration.ProxyCreationEnabled = false;

            Database.SetInitializer(new SchoolDBInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Student>()
                .HasMany(a => a.Courses)
                .WithMany(b => b.Students)
                .Map(m =>
                {
                    m.ToTable("StudentCourse");
                    m.MapLeftKey("StudentId");
                    m.MapRightKey("CourseId");
                });

        }
    }
}

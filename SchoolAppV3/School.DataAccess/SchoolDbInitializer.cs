using School.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataAccess
{
    public class SchoolDBInitializer : DropCreateDatabaseIfModelChanges<SchoolContext>
    {

        protected override void Seed(SchoolContext context)
        {
            var aga = context.Students.Add(new Student() { FirstName = "Aga", LastName = "Hussein"});
            context.Students.Add(new Student() { FirstName = "This", LastName = "Sucks" });
            context.Students.Add(new Student() { FirstName = "Lee", LastName = "Child" });

            context.Courses.Add(new Course() { CourseName = "RIP", Students = new List<Student>() { aga } });
            base.Seed(context);
        }
    }

}

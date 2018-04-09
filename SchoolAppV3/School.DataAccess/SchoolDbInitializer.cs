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
            var agaHussein = context.Students.Add(new Student(1, "aga", "Hussein"));

            context.Courses.Add(new Course() { CourseName = ".net", Students = new List<Student>() { agaHussein } });
            base.Seed(context);
        }
    }
}

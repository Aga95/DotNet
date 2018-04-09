using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Model
{
    public class Student
    {
        public int StudentId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual List<Course> Courses { get; set; }

        public Student(int studentId, String firstName, String lastName)
        {
            this.StudentId = studentId;
            this.FirstName = firstName;
            this.LastName = lastName;

            Courses = new List<Course>();
        }

        public Student()
        {
            Courses = new List<Course>();
        }

    }
}

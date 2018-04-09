using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School.Model
{
    public class Course
    {
        public int CourseId { get; set; }

        public string CourseName { get; set; }

        public virtual List<Student> Students { get; set; }

        public Course(int courseId, String courseName)
        {
            this.CourseId = courseId;
            this.CourseName = courseName;
            Students = new List<Student>();
        }

        public Course()
        {
            Students = new List<Student>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class Course
    {
        /// <summary>
        /// Gets or sets the course identifier.
        /// </summary>
        /// <value>
        /// The course identifier.
        /// </value>
        public int CourseId { get; set; }

        /// <summary>
        /// Gets or sets the name of the course.
        /// </summary>
        /// <value>
        /// The name of the course.
        /// </value>
        public string CourseName { get; set; }

        /// <summary>
        /// Gets or sets the students.
        /// </summary>
        /// <value>
        /// The students.
        /// </value>
        public virtual List<Student> Students { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Course"/> class.
        /// </summary>
        /// <param name="courseId">The course identifier.</param>
        /// <param name="courseName">Name of the course.</param>
        public Course(int courseId, String courseName)
        {
            this.CourseId = courseId;
            this.CourseName = courseName;
            Students = new List<Student>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Course"/> class.
        /// </summary>
        public Course()
        {
            Students = new List<Student>();
        }
    }
}

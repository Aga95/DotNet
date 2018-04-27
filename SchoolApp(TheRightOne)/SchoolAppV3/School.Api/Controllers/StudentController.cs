using School.DataAccess;
using School.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace School.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class StudentController : ApiController
    {

        /// <summary>
        /// The database
        /// </summary>
        private SchoolContext db = new SchoolContext();

        // GET api/Students
        /// <summary>
        /// Gets the students.
        /// </summary>
        /// <returns></returns>
        public IQueryable<Student> GetStudents()
        {
            return db.Students;
        }

        // GET api/Students/5
        /// <summary>
        /// Gets the students.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [ResponseType(typeof(Student))]
        public async Task<IHttpActionResult> GetStudents(int id)
        {
            Student student = await db.Students.FindAsync(id);
            if(student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        // POST api/Students
        /// <summary>
        /// Posts the student.
        /// </summary>
        /// <param name="student">The student.</param>
        /// <returns></returns>
        [ResponseType(typeof(Student))]
        public async Task<IHttpActionResult> PostStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Students.Add(student);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = student.StudentId }, student);
        }

        /// <summary>
        /// Puts the student.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="student">The student.</param>
        /// <returns></returns>
        [ResponseType(typeof(void))]
        // PUT api/Students/5
        public async Task<IHttpActionResult> PutStudent(int id, Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(id != student.StudentId)
            {
                return BadRequest();
            }

            db.Entry(student).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE api/Students/5
        /// <summary>
        /// Deletes the student.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [ResponseType(typeof(Student))]
        public async Task<IHttpActionResult> DeleteStudent(int id)
        {
            Student student = await db.Students.FindAsync(id);
            if(student == null)
            {
                return NotFound();
            }

            db.Students.Remove(student);
            await db.SaveChangesAsync();

            return Ok(student);
        }


        /// <summary>
        /// Adds the course.
        /// </summary>
        /// <param name="studentId">The student identifier.</param>
        /// <param name="courseId">The course identifier.</param>
        /// <returns></returns>
        [HttpPost()]
        [Route("api/Student/{studentId}/Course/{courseId}")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> AddCourse(int studentId, int courseId)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(db.Database.Connection.ToString()))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO StudentCourse VALUES(StudentId=@StudentId, CourseId=@CourseId", conn);
                    cmd.Parameters.AddWithValue("@StudentId", studentId);
                    cmd.Parameters.AddWithValue("@CourseId", courseId);

                    conn.Open();

                    await cmd.ExecuteNonQueryAsync();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return InternalServerError();
            }


            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Releases the unmanaged resources that are used by the object and, optionally, releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }


        /// <summary>
        /// Students the exists.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        private bool StudentExists(int id)
        {
            return db.Students.Count(e => e.StudentId == id) > 0;
        }
    }
}

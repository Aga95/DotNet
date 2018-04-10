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
    public class StudentController : ApiController
    {

        private SchoolContext db = new SchoolContext();

        // GET api/Students
        public IQueryable<Student> GetStudents()
        {
            return db.Students;
        }

        // GET api/Students/5
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }


        private bool StudentExists(int id)
        {
            return db.Students.Count(e => e.StudentId == id) > 0;
        }
    }
}

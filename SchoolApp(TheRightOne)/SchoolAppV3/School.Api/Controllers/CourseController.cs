using School.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using School.Model;
using System.Web.Http.Description;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace School.Api
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class CourseController : ApiController
    {

        /// <summary>
        /// The database
        /// </summary>
        private SchoolContext db = new SchoolContext();

        // GET api/Course
        /// <summary>
        /// Gets the courses.
        /// </summary>
        /// <returns></returns>
        public IQueryable<Course> GetCourses()
        {
            return db.Courses;
        }

        // GET api/Course/5
        /// <summary>
        /// Gets the course.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [ResponseType(typeof(Course))]
        public async Task<IHttpActionResult> GetCourse(int id)
        {
            Course course = await db.Courses.FindAsync(id);
            if(course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        // POST api/Course
        /// <summary>
        /// Posts the course.
        /// </summary>
        /// <param name="course">The course.</param>
        /// <returns></returns>
        [ResponseType(typeof(Course))]
        public async Task<IHttpActionResult> PostCourse(Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Courses.Add(course);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = course.CourseId}, course);
        }

        // PUT api/Course/5
        /// <summary>
        /// Puts the course.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="course">The course.</param>
        /// <returns></returns>
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCourse(int id, Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(id != course.CourseId)
            {
                return BadRequest();
            }

            db.Entry(course).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
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

        // DELETE api/Course/5
        /// <summary>
        /// Deletes the course.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [ResponseType(typeof(Course))]
        public async Task<IHttpActionResult> DeleteCourse(int id)
        {
            Course course = await db.Courses.FindAsync(id);

            if(course == null)
            {
                return NotFound();
            }

            db.Courses.Remove(course);
            await db.SaveChangesAsync();

            return Ok(course);
        }

        /// <summary>
        /// Releases the unmanaged resources that are used by the object and, optionally, releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing){
                db.Dispose();
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// Courses the exists.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        private bool CourseExists(int id)
        {
            return db.Courses.Count(e => e.CourseId == id) > 0;
        }
    }
}
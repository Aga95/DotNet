using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using GymBuddy.DataAccess;
using GymBuddy.Model;

namespace GymBuddy.Api.Controllers
{
    public class DaysController : ApiController
    {
        private GymContext db = new GymContext();

        // GET: api/Days
        public IQueryable<Day> GetDays()
        {
            return db.Days;
        }

        // GET: api/Days/5
        [ResponseType(typeof(Day))]
        public async Task<IHttpActionResult> GetDay(int id)
        {
            Day day = await db.Days.FindAsync(id);
            if (day == null)
            {
                return NotFound();
            }

            return Ok(day);
        }

        // PUT: api/Days/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDay(int id, Day day)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != day.DayId)
            {
                return BadRequest();
            }

            db.Entry(day).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DayExists(id))
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

        // POST: api/Days
        [ResponseType(typeof(Day))]
        public async Task<IHttpActionResult> PostDay(Day day)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Days.Add(day);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = day.DayId }, day);
        }

        // DELETE: api/Days/5
        [ResponseType(typeof(Day))]
        public async Task<IHttpActionResult> DeleteDay(int id)
        {
            Day day = await db.Days.FindAsync(id);
            if (day == null)
            {
                return NotFound();
            }

            db.Days.Remove(day);
            await db.SaveChangesAsync();

            return Ok(day);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DayExists(int id)
        {
            return db.Days.Count(e => e.DayId == id) > 0;
        }
    }
}
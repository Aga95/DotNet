using School.DataAccess;
using School.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace School.Api.Controllers
{
    public class ProfileController : ApiController
    {

        private GymContext db = new GymContext();
        // GET api/Profile
        public IQueryable<Profile> Get()
        {
            return db.Profiles;
        }

        // GET api/Profile/5
        [ResponseType(typeof(Profile))]
        public async Task<IHttpActionResult> GetProfiles(int id)
        {
            Profile profile = await db.Profiles.FindAsync(id);
            if (profile == null)
            {
                return NotFound();
            }

            return Ok(profile);
        }

        // POST api/Profile
        [ResponseType(typeof(Profile))]
        public async Task<IHttpActionResult> PostProfile(Profile profile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Profiles.Add(profile);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = profile.Id }, profile);
        }

        // PUT api/Profile/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProfile(int id, Profile profile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != profile.Id)
            {
                return BadRequest();
            }

            db.Entry(profile).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfileExists(id))
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

        // DELETE api/Profile/5
        [ResponseType(typeof(Profile))]
        public async Task<IHttpActionResult> DeleteProfile(int id)
        {
            Profile profile = await db.Profiles.FindAsync(id);
            if (profile == null)
            {
                return NotFound();
            }

            db.Profiles.Remove(profile);
            await db.SaveChangesAsync();

            return Ok(profile);
        }


        private bool ProfileExists(int id)
        {
            return db.Profiles.Count(e => e.Id == id) > 0;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PryUserQuevedoChSD.Models;

namespace PryUserQuevedoChSD.Controllers
{
    public class InformationController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Information
        [Authorize]
        public IQueryable<Information> GetInformation()
        {
            return db.Information;
        }

        // GET: api/Information/5
        [Authorize]
        [ResponseType(typeof(Information))]
        public IHttpActionResult GetInformation(int id)
        {
            Information information = db.Information.Find(id);
            if (information == null)
            {
                return NotFound();
            }

            return Ok(information);
        }

        // PUT: api/Information/5
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInformation(int id, Information information)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != information.PersonId)
            {
                return BadRequest();
            }

            db.Entry(information).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InformationExists(id))
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

        // POST: api/Information
        [Authorize]
        [ResponseType(typeof(Information))]
        public IHttpActionResult PostInformation(Information information)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Information.Add(information);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = information.PersonId }, information);
        }

        // DELETE: api/Information/5
        [Authorize]
        [ResponseType(typeof(Information))]
        public IHttpActionResult DeleteInformation(int id)
        {
            Information information = db.Information.Find(id);
            if (information == null)
            {
                return NotFound();
            }

            db.Information.Remove(information);
            db.SaveChanges();

            return Ok(information);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InformationExists(int id)
        {
            return db.Information.Count(e => e.PersonId == id) > 0;
        }
    }
}
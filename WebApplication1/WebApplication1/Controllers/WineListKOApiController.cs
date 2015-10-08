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
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class WineListKOApiController : ApiController
    {
        private WinesKOEntities db = new WinesKOEntities();

        // GET: api/WineListKOApi
        public IQueryable<WineListKO> GetWineListKOes()
        {
            return db.WineListKOes;
        }

        // GET: api/WineListKOApi/5
        [ResponseType(typeof(WineListKO))]
        public IHttpActionResult GetWineListKO(int id)
        {
            WineListKO wineListKO = db.WineListKOes.Find(id);
            if (wineListKO == null)
            {
                return NotFound();
            }

            return Ok(wineListKO);
        }

        // PUT: api/WineListKOApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWineListKO(int id, WineListKO wineListKO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != wineListKO.ID)
            {
                return BadRequest();
            }

            db.Entry(wineListKO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WineListKOExists(id))
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

        // POST: api/WineListKOApi
        [ResponseType(typeof(WineListKO))]
        public IHttpActionResult PostWineListKO(WineListKO wineListKO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.WineListKOes.Add(wineListKO);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = wineListKO.ID }, wineListKO);
        }

        // DELETE: api/WineListKOApi/5
        [ResponseType(typeof(WineListKO))]
        public IHttpActionResult DeleteWineListKO(int id)
        {
            WineListKO wineListKO = db.WineListKOes.Find(id);
            if (wineListKO == null)
            {
                return NotFound();
            }

            db.WineListKOes.Remove(wineListKO);
            db.SaveChanges();

            return Ok(wineListKO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WineListKOExists(int id)
        {
            return db.WineListKOes.Count(e => e.ID == id) > 0;
        }
    }
}
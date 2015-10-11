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
using WineCatalog.Frontend.Models;

namespace WineCatalog.Frontend.Controllers
{
    public class WineCatalogKOApiController : ApiController
    {
        private WineCatalogDBContext db = new WineCatalogDBContext();

        // GET: api/WineCatalogKOApi
        public IQueryable<WineCatalogModel> GetWineCatalogs()
        {
            return db.WineCatalogs;
        }

        // GET: api/WineCatalogKOApi/5
        [ResponseType(typeof(WineCatalogModel))]
        public IHttpActionResult GetWineCatalogModel(int id)
        {
            WineCatalogModel wineCatalogModel = db.WineCatalogs.Find(id);
            if (wineCatalogModel == null)
            {
                return NotFound();
            }

            return Ok(wineCatalogModel);
        }

        // PUT: api/WineCatalogKOApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWineCatalogModel(int id, WineCatalogModel wineCatalogModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != wineCatalogModel.Id)
            {
                return BadRequest();
            }

            db.Entry(wineCatalogModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WineCatalogModelExists(id))
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

        // POST: api/WineCatalogKOApi
        [ResponseType(typeof(WineCatalogModel))]
        public IHttpActionResult PostWineCatalogModel(WineCatalogModel wineCatalogModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.WineCatalogs.Add(wineCatalogModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = wineCatalogModel.Id }, wineCatalogModel);
        }

        // DELETE: api/WineCatalogKOApi/5
        [ResponseType(typeof(WineCatalogModel))]
        public IHttpActionResult DeleteWineCatalogModel(int id)
        {
            WineCatalogModel wineCatalogModel = db.WineCatalogs.Find(id);
            if (wineCatalogModel == null)
            {
                return NotFound();
            }

            db.WineCatalogs.Remove(wineCatalogModel);
            db.SaveChanges();

            return Ok(wineCatalogModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WineCatalogModelExists(int id)
        {
            return db.WineCatalogs.Count(e => e.Id == id) > 0;
        }
    }
}
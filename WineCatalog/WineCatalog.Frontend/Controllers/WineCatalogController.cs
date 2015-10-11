using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WineCatalog.Frontend.Models;

namespace WineCatalog.Frontend.Controllers
{
    public class WineCatalogController : Controller
    {
        private WineCatalogDBContext db = new WineCatalogDBContext();

        // GET: WineCatalog
        public ActionResult Index()
        {
            return View(db.WineCatalogs.ToList());
        }

        // GET: WineCatalog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WineCatalogModel wineCatalogModel = db.WineCatalogs.Find(id);
            if (wineCatalogModel == null)
            {
                return HttpNotFound();
            }
            return View(wineCatalogModel);
        }

        // GET: WineCatalog/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WineCatalog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Color,TermExposure,Fortress,Price")] WineCatalogModel wineCatalogModel)
        {
            if (ModelState.IsValid)
            {
                db.WineCatalogs.Add(wineCatalogModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wineCatalogModel);
        }

        // GET: WineCatalog/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WineCatalogModel wineCatalogModel = db.WineCatalogs.Find(id);
            if (wineCatalogModel == null)
            {
                return HttpNotFound();
            }
            return View(wineCatalogModel);
        }

        // POST: WineCatalog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Color,TermExposure,Fortress,Price")] WineCatalogModel wineCatalogModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wineCatalogModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wineCatalogModel);
        }

        // GET: WineCatalog/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WineCatalogModel wineCatalogModel = db.WineCatalogs.Find(id);
            if (wineCatalogModel == null)
            {
                return HttpNotFound();
            }
            return View(wineCatalogModel);
        }

        // POST: WineCatalog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WineCatalogModel wineCatalogModel = db.WineCatalogs.Find(id);
            db.WineCatalogs.Remove(wineCatalogModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class WineListsController : Controller
    {
        private WineListDBContext db = new WineListDBContext();

        // GET: WineLists
        public ActionResult Index()
        {
            return View(db.Wines.ToList());
        }

        // GET: WineLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WineList wineList = db.Wines.Find(id);
            if (wineList == null)
            {
                return HttpNotFound();
            }
            return View(wineList);
        }

        // GET: WineLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WineLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Color,TermExposure,Fortress,Price")] WineList wineList)
        {
            if (ModelState.IsValid)
            {
                db.Wines.Add(wineList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wineList);
        }

        // GET: WineLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WineList wineList = db.Wines.Find(id);
            if (wineList == null)
            {
                return HttpNotFound();
            }
            return View(wineList);
        }

        // POST: WineLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Color,TermExposure,Fortress,Price")] WineList wineList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wineList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wineList);
        }

        // GET: WineLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WineList wineList = db.Wines.Find(id);
            if (wineList == null)
            {
                return HttpNotFound();
            }
            return View(wineList);
        }

        // POST: WineLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WineList wineList = db.Wines.Find(id);
            db.Wines.Remove(wineList);
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

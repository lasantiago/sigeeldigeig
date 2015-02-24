using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ORM;
using ORM.DC_Maestros;

namespace w.Controllers.DC_Maestros
{
    public class LocalitiesController : Controller
    {
        private SIGEeLDBContext db = new SIGEeLDBContext();

        // GET: Localities
        public ActionResult Index()
        {
            var localities = db.Localities.Include(l => l.Region);
            return View(localities.ToList().OrderBy(p => p.LocalityName));
        }

        // GET: Localities/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locality locality = db.Localities.Find(id);
            if (locality == null)
            {
                return HttpNotFound();
            }

            return View(locality);
        }

        // GET: Localities/Create
        public ActionResult Create()
        {
            ViewBag.RegionId = new SelectList(db.Regions, "RegionId", "RegionName");
            return View();
        }

        // POST: Localities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LocalityId,LocalityName,RegionId,DateEntered,DateModified,CreatedByUserId,ModifiedByUserId")] Locality locality)
        {
            if (ModelState.IsValid)
            {
                locality.LocalityId = Guid.NewGuid();
                db.Localities.Add(locality);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RegionId = new SelectList(db.Regions, "RegionId", "RegionName", locality.RegionId);
            return View(locality);
        }

        // GET: Localities/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locality locality = db.Localities.Find(id);
            if (locality == null)
            {
                return HttpNotFound();
            }
            ViewBag.RegionId = new SelectList(db.Regions, "RegionId", "RegionName", locality.RegionId);
            return View(locality);
        }

        // POST: Localities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LocalityId,LocalityName,RegionId,DateEntered,DateModified,CreatedByUserId,ModifiedByUserId")] Locality locality)
        {
            if (ModelState.IsValid)
            {
                db.Entry(locality).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RegionId = new SelectList(db.Regions, "RegionId", "RegionName", locality.RegionId);
            return View(locality);
        }

        // GET: Localities/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locality locality = db.Localities.Find(id);
            if (locality == null)
            {
                return HttpNotFound();
            }
            return View(locality);
        }

        // POST: Localities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Locality locality = db.Localities.Find(id);
            db.Localities.Remove(locality);
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

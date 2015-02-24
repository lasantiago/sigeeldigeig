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
    public class SubSectorsController : Controller
    {
        private SIGEeLDBContext db = new SIGEeLDBContext();

        // GET: SubSectors
        public ActionResult Index()
        {
            return View(db.SubSectors.ToList().OrderBy(p => p.SubSectorName));
        }

        // GET: SubSectors/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubSector subSector = db.SubSectors.Find(id);
            if (subSector == null)
            {
                return HttpNotFound();
            }
            return View(subSector);
        }

        // GET: SubSectors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SubSectors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubSectorId,SubSectorName,DateEntered,DateModified,CreatedByUserId,ModifiedByUserId")] SubSector subSector)
        {
            if (ModelState.IsValid)
            {
                subSector.SubSectorId = Guid.NewGuid();
                db.SubSectors.Add(subSector);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subSector);
        }

        // GET: SubSectors/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubSector subSector = db.SubSectors.Find(id);
            if (subSector == null)
            {
                return HttpNotFound();
            }
            return View(subSector);
        }

        // POST: SubSectors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubSectorId,SubSectorName,DateEntered,DateModified,CreatedByUserId,ModifiedByUserId")] SubSector subSector)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subSector).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subSector);
        }

        // GET: SubSectors/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubSector subSector = db.SubSectors.Find(id);
            if (subSector == null)
            {
                return HttpNotFound();
            }
            return View(subSector);
        }

        // POST: SubSectors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            SubSector subSector = db.SubSectors.Find(id);
            db.SubSectors.Remove(subSector);
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

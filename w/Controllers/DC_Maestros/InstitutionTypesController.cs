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
    public class InstitutionTypesController : Controller
    {
        private SIGEeLDBContext db = new SIGEeLDBContext();

        // GET: InstitutionTypes
        public ActionResult Index()
        {
            return View(db.InstitutionTypes.ToList().OrderBy(p => p.InstitutionTypeName));
        }

        // GET: InstitutionTypes/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InstitutionType institutionType = db.InstitutionTypes.Find(id);
            if (institutionType == null)
            {
                return HttpNotFound();
            }
            return View(institutionType);
        }

        // GET: InstitutionTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InstitutionTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InstitutionTypeId,InstitutionTypeName,DateEntered,DateModified,CreatedByUserId,ModifiedByUserId")] InstitutionType institutionType)
        {
            if (ModelState.IsValid)
            {
                institutionType.InstitutionTypeId = Guid.NewGuid();
                db.InstitutionTypes.Add(institutionType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(institutionType);
        }

        // GET: InstitutionTypes/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InstitutionType institutionType = db.InstitutionTypes.Find(id);
            if (institutionType == null)
            {
                return HttpNotFound();
            }
            return View(institutionType);
        }

        // POST: InstitutionTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InstitutionTypeId,InstitutionTypeName,DateEntered,DateModified,CreatedByUserId,ModifiedByUserId")] InstitutionType institutionType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(institutionType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(institutionType);
        }

        // GET: InstitutionTypes/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InstitutionType institutionType = db.InstitutionTypes.Find(id);
            if (institutionType == null)
            {
                return HttpNotFound();
            }
            return View(institutionType);
        }

        // POST: InstitutionTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            InstitutionType institutionType = db.InstitutionTypes.Find(id);
            db.InstitutionTypes.Remove(institutionType);
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

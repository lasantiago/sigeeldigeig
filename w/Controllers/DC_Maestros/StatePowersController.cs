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
    public class StatePowersController : Controller
    {
        private SIGEeLDBContext db = new SIGEeLDBContext();

        // GET: StatePowers
        public ActionResult Index()
        {
            return View(db.StatePowers.ToList().OrderBy(p => p.StatePowerName));
        }

        // GET: StatePowers/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatePower statePower = db.StatePowers.Find(id);
            if (statePower == null)
            {
                return HttpNotFound();
            }
            ViewBag.Institutions = db.Institutions.Where(i => i.StatePowerId == id).OrderBy(i => i.InstitutionName).ToList();

            return View(statePower);
        }

        // GET: StatePowers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StatePowers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StatePowerId,StatePowerName,DateEntered,DateModified,CreatedByUserId,ModifiedByUserId")] StatePower statePower)
        {
            if (ModelState.IsValid)
            {
                statePower.StatePowerId = Guid.NewGuid();
                db.StatePowers.Add(statePower);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(statePower);
        }

        // GET: StatePowers/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatePower statePower = db.StatePowers.Find(id);
            if (statePower == null)
            {
                return HttpNotFound();
            }
            return View(statePower);
        }

        // POST: StatePowers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StatePowerId,StatePowerName,DateEntered,DateModified,CreatedByUserId,ModifiedByUserId,AssignedToUserId")] StatePower statePower)
        {
            if (ModelState.IsValid)
            {
                db.Entry(statePower).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(statePower);
        }

        // GET: StatePowers/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatePower statePower = db.StatePowers.Find(id);
            if (statePower == null)
            {
                return HttpNotFound();
            }
            return View(statePower);
        }

        // POST: StatePowers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            StatePower statePower = db.StatePowers.Find(id);
            db.StatePowers.Remove(statePower);
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

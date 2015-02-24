using ORM;
using ORM.DC_Maestros;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace w.Controllers.DC_Maestros
{
    public class CountriesController : Controller
    {
        private SIGEeLDBContext db = new SIGEeLDBContext();

        // GET: Countries
        public ActionResult Index()
        {
            return View(db.Countries.ToList().OrderBy(p => p.CountryName));
        }

        // GET: Countries/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country country = db.Countries.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }

            ViewBag.Regions = db.Regions.Where(i => i.CountryId == id).OrderBy(i => i.RegionName).ToList();

            return View(country);
        }

        // GET: Countries/Create
        public ActionResult Create()
        {
            Country c = new Country();
            c.DateEntered = DateTime.Now;
            c.DateModified = DateTime.Now;

            User u = new User().GetUserByUserName(new SIGEeLDBContext(), "admin");

            // TODO - REMOVE BEFORE GOING INTO PRODUCTION
            c.CreatedByUserId = u.UserId;
            c.ModifiedByUserId = u.UserId;
            c.AssignedToUserId = u.UserId;

            return View(c);
        }

        // POST: Countries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CountryId,CountryName,DateEntered,DateModified,CreatedByUserId,ModifiedByUserId,AssignedToUserId")] Country country)
        {
            if (ModelState.IsValid)
            {
                country.CountryId = Guid.NewGuid();
                db.Countries.Add(country);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(country);
        }

        // GET: Countries/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country country = db.Countries.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        // POST: Countries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CountryId,CountryName,DateEntered,DateModified,CreatedByUserId,ModifiedByUserId,AssignedToUserId")] Country country)
        {
            if (ModelState.IsValid)
            {
                db.Entry(country).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(country);
        }

        // GET: Countries/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country country = db.Countries.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        // POST: Countries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Country country = db.Countries.Find(id);
            db.Countries.Remove(country);
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

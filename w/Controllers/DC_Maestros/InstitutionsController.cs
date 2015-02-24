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
    public class InstitutionsController : Controller
    {
        private SIGEeLDBContext db = new SIGEeLDBContext();

        // GET: Institutions
        public ActionResult Index()
        {
            var institutions = db.Institutions.Include(i => i.InstitutionType).Include(i => i.Locality).Include(i => i.Sector).Include(i => i.StatePower).Include(i => i.SubSector).Include(i => i.User);
            return View(institutions.ToList().OrderBy(p => p.InstitutionName));
        }

        // GET: Institutions/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Institution institution = db.Institutions.Find(id);
            if (institution == null)
            {
                return HttpNotFound();
            }
            return View(institution);
        }

        // GET: Institutions/Create
        public ActionResult Create()
        {
            ViewBag.InstitutionTypeId = new SelectList(db.InstitutionTypes, "InstitutionTypeId", "InstitutionTypeName");
            ViewBag.LocalityId = new SelectList(db.Localities, "LocalityId", "LocalityName");
            ViewBag.SectorId = new SelectList(db.Sectors, "SectorId", "SectorName");
            ViewBag.StatePowerId = new SelectList(db.StatePowers, "StatePowerId", "StatePowerName");
            ViewBag.SubSectorId = new SelectList(db.SubSectors, "SubSectorId", "SubSectorName");
            ViewBag.AssignedToUserId = new SelectList(db.Users, "UserId", "UserName");
            return View();
        }

        // POST: Institutions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InstitutionId,InstitutionName,InstitutionMission,InstitutionLegalBasis,IsInstitutionDescentralized,StatePowerId,InstitutionTypeId,SectorId,SubSectorId,IsInstitutionDisabled,InstitutionAddress,LocalityId,InstitutionPhone,InstitutionFax,InstitutionEmailAddress,InstitutionUrl,ShouldInstitutionHaveEthicsCommittee,ShouldInstitutionHaveOAI,DateEntered,DateModified,CreatedByUserId,ModifiedByUserId,AssignedToUserId")] Institution institution)
        {
            if (ModelState.IsValid)
            {
                institution.InstitutionId = Guid.NewGuid();
                db.Institutions.Add(institution);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InstitutionTypeId = new SelectList(db.InstitutionTypes, "InstitutionTypeId", "InstitutionTypeName", institution.InstitutionTypeId);
            ViewBag.LocalityId = new SelectList(db.Localities, "LocalityId", "LocalityName", institution.LocalityId);
            ViewBag.SectorId = new SelectList(db.Sectors, "SectorId", "SectorName", institution.SectorId);
            ViewBag.StatePowerId = new SelectList(db.StatePowers, "StatePowerId", "StatePowerName", institution.StatePowerId);
            ViewBag.SubSectorId = new SelectList(db.SubSectors, "SubSectorId", "SubSectorName", institution.SubSectorId);
            ViewBag.AssignedToUserId = new SelectList(db.Users, "UserId", "UserName", institution.AssignedToUserId);
            return View(institution);
        }

        // GET: Institutions/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Institution institution = db.Institutions.Find(id);
            if (institution == null)
            {
                return HttpNotFound();
            }
            ViewBag.InstitutionTypeId = new SelectList(db.InstitutionTypes, "InstitutionTypeId", "InstitutionTypeName", institution.InstitutionTypeId);
            ViewBag.LocalityId = new SelectList(db.Localities, "LocalityId", "LocalityName", institution.LocalityId);
            ViewBag.SectorId = new SelectList(db.Sectors, "SectorId", "SectorName", institution.SectorId);
            ViewBag.StatePowerId = new SelectList(db.StatePowers, "StatePowerId", "StatePowerName", institution.StatePowerId);
            ViewBag.SubSectorId = new SelectList(db.SubSectors, "SubSectorId", "SubSectorName", institution.SubSectorId);
            ViewBag.AssignedToUserId = new SelectList(db.Users, "UserId", "UserName", institution.AssignedToUserId);
            return View(institution);
        }

        // POST: Institutions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InstitutionId,InstitutionName,InstitutionMission,InstitutionLegalBasis,IsInstitutionDescentralized,StatePowerId,InstitutionTypeId,SectorId,SubSectorId,IsInstitutionDisabled,InstitutionAddress,LocalityId,InstitutionPhone,InstitutionFax,InstitutionEmailAddress,InstitutionUrl,ShouldInstitutionHaveEthicsCommittee,ShouldInstitutionHaveOAI,DateEntered,DateModified,CreatedByUserId,ModifiedByUserId,AssignedToUserId")] Institution institution)
        {
            if (ModelState.IsValid)
            {
                db.Entry(institution).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InstitutionTypeId = new SelectList(db.InstitutionTypes, "InstitutionTypeId", "InstitutionTypeName", institution.InstitutionTypeId);
            ViewBag.LocalityId = new SelectList(db.Localities, "LocalityId", "LocalityName", institution.LocalityId);
            ViewBag.SectorId = new SelectList(db.Sectors, "SectorId", "SectorName", institution.SectorId);
            ViewBag.StatePowerId = new SelectList(db.StatePowers, "StatePowerId", "StatePowerName", institution.StatePowerId);
            ViewBag.SubSectorId = new SelectList(db.SubSectors, "SubSectorId", "SubSectorName", institution.SubSectorId);
            ViewBag.AssignedToUserId = new SelectList(db.Users, "UserId", "UserName", institution.AssignedToUserId);
            return View(institution);
        }

        // GET: Institutions/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Institution institution = db.Institutions.Find(id);
            if (institution == null)
            {
                return HttpNotFound();
            }
            return View(institution);
        }

        // POST: Institutions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Institution institution = db.Institutions.Find(id);
            db.Institutions.Remove(institution);
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

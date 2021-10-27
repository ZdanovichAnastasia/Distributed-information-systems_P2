using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using lab6.Models;

namespace lab6.Controllers
{
    public class VisitsController : Controller
    {
        private VisitContext db = new VisitContext();

        // GET: Visits
        public ActionResult Index(string filter)
        {
            var visits = db.Visits.Include(v => v.lecture).Include(v => v.student);
            if (!String.IsNullOrEmpty(filter))
            {
                visits = db.Visits.Where(p => (p.student.surname.Equals(filter) || p.lecture.name.Equals(filter))).Include(v => v.lecture).Include(v => v.student);
            }
            
            return View(visits.ToList());
        }

        // GET: Visits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visit visit = db.Visits.Find(id);
            if (visit == null)
            {
                return HttpNotFound();
            }
            return View(visit);
        }

        // GET: Visits/Create
        public ActionResult Create()
        {
            ViewBag.lectureId = new SelectList(db.Lectures, "lectureId", "name");
            ViewBag.studentId = new SelectList(db.Students, "studentId", "name");
            return View();
        }

        // POST: Visits/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "visitId,studentId,lectureId,date,is_visit")] Visit visit)
        {
            if (ModelState.IsValid)
            {
                db.Visits.Add(visit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.lectureId = new SelectList(db.Lectures, "lectureId", "name", visit.lectureId);
            ViewBag.studentId = new SelectList(db.Students, "studentId", "name", visit.studentId);
            return View(visit);
        }

        // GET: Visits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visit visit = db.Visits.Find(id);
            if (visit == null)
            {
                return HttpNotFound();
            }
            ViewBag.lectureId = new SelectList(db.Lectures, "lectureId", "name", visit.lectureId);
            ViewBag.studentId = new SelectList(db.Students, "studentId", "name", visit.studentId);
            return View(visit);
        }

        // POST: Visits/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "visitId,studentId,lectureId,date,is_visit")] Visit visit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.lectureId = new SelectList(db.Lectures, "lectureId", "name", visit.lectureId);
            ViewBag.studentId = new SelectList(db.Students, "studentId", "name", visit.studentId);
            return View(visit);
        }

        // GET: Visits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visit visit = db.Visits.Find(id);
            if (visit == null)
            {
                return HttpNotFound();
            }
            return View(visit);
        }

        // POST: Visits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Visit visit = db.Visits.Find(id);
            db.Visits.Remove(visit);
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

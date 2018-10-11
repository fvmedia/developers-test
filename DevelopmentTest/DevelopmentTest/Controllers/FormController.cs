using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DevelopmentTest.Models;

namespace DevelopmentTest.Controllers
{
    public class FormController : Controller
    {
        private DevelopmentTestContext db = new DevelopmentTestContext();

        // GET: Form
        public ActionResult Index()
        {
            return View(db.Test_Form.ToList());
        }

        // GET: Form/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test_Form test_Form = db.Test_Form.Find(id);
            if (test_Form == null)
            {
                return HttpNotFound();
            }
            return View(test_Form);
        }

        // GET: Form/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Form/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "formid,Name,Email,Date,Password")] Test_Form test_Form)
        {
            if (ModelState.IsValid)
            {
                db.Test_Form.Add(test_Form);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(test_Form);
        }

        // GET: Form/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test_Form test_Form = db.Test_Form.Find(id);
            if (test_Form == null)
            {
                return HttpNotFound();
            }
            return View(test_Form);
        }

        // POST: Form/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "formid,Name,Email,Date,Password")] Test_Form test_Form)
        {
            if (ModelState.IsValid)
            {
                db.Entry(test_Form).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(test_Form);
        }

        // GET: Form/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test_Form test_Form = db.Test_Form.Find(id);
            if (test_Form == null)
            {
                return HttpNotFound();
            }
            return View(test_Form);
        }

        // POST: Form/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Test_Form test_Form = db.Test_Form.Find(id);
            db.Test_Form.Remove(test_Form);
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

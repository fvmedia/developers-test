using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
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


                //Configuring webMail class to send emails
                //gmail smtp server , This is the fastest, I tried using my own Domain SMPT Provider, Rather Use GMail to handle emails from your custom mail.
                WebMail.SmtpServer = "smtp.gmail.com";
                //gmail port to send emails
                WebMail.SmtpPort = 587;
                WebMail.SmtpUseDefaultCredentials = true;
                //sending emails with secure protocol
                WebMail.EnableSsl = true;
                //EmailId used to send emails from application
                WebMail.UserName = "interviewtest18@gmail.com";
                WebMail.Password = "0846255974";
                //Sender email address.  Should be the same as the one listed on Gmail as the alias.
                WebMail.From = "interviewtest18@gmail.com";
                //Send email:
                string temp;


                
                temp = @"
                   <div> " +
                    "<h1> Good Day " + test_Form.Name + "</h1>" +
                    "<p>Thank you for filling out the form.</br>Please see your details before:</p>" +
                    "" +
                    "<p><b>Our Team Will contact you shortly </b></p>" +
                    "<p><b>Your name is: </b>" + test_Form.Name +"</p>"+
                    "<p><b>Your email is: </b>" + test_Form.Email + "</p>" +
                    "<p><b>The date you selected: </b>" + test_Form.Date + "</p>" +
                    "<p><b>Your password is: </b>" + test_Form.Password + "</p>" +
                    "" +
                    "<p><b>Thank you For the Opportunity. </b>" +"</p>" +
                    "<p><b>Kind Regards. </b>" + "</p>" +
                    "<p><b>060 566 2030. </b>" + "</p>" +
                      "" +
                    "</div>";


                WebMail.Send(to: test_Form.Email, subject: "Firstview UI Developers Test", body: temp, cc: "", bcc: "", isBodyHtml: true);


              
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

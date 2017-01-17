using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AngularAssignment.Models;
using System.Data.Entity.Migrations;

namespace AngularAssignment.Controllers
{
    public class PersonsController : Controller
    {
        private PersonDB db = new PersonDB();

        // GET: Persons
        public ActionResult Index()
        {
            return View(db.Persons.ToList());
        }

        public JsonResult GiveMeList()
        {
            var myList = db.Persons.ToList();
            return Json(myList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult FullDetails(string userName)
        {
            var oneUser = db.Persons.Where(p => p.Name == userName).FirstOrDefault();
            return Json(oneUser, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Edit(int Id)
        {
            Person editPerson = db.Persons.FirstOrDefault(p => p.Id == Id);
            
            return Json(editPerson, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveEdit(int Id, string Name, string Email, string Telephone)
        {
            Person person = db.Persons.FirstOrDefault(p => p.Id == Id);
            if (person != null) 
            {
                person.Name = Name;
                person.Email = Email;
                person.Telephone = Telephone;

            }
            db.SaveChanges();

            return Json(person, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Create(string Name, string Email, string Telephone)
        {
            db.Persons.AddOrUpdate(p => p.Email,
                new Person
                {
                    Name = Name,
                    Email = Email,
                    Telephone = Telephone
                });
            db.SaveChanges();

            var myList = db.Persons.ToList();
            return Json(myList, JsonRequestBehavior.AllowGet);
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

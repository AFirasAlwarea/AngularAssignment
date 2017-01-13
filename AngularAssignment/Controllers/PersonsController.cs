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
            Person editPerson = db.Persons.Where(p => p.Id == Id).FirstOrDefault();
            
                db.Persons.AddOrUpdate(p => p.Email,
                new Person
                {
                    Name = editPerson.Name,
                    Email = editPerson.Email,
                    Telephone = editPerson.Telephone
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

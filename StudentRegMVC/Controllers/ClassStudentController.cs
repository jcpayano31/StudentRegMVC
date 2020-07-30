using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentRegMVC.Controllers
{
    public class ClassStudentController : Controller
    {
        AdvWebDevProjectEntities Contextobj = new AdvWebDevProjectEntities();
        // GET: ClassStudent
        public ActionResult Index()
        {

            return View();
        }

        // GET: ClassStudent/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClassStudent/Create
        public ActionResult Create(int studentid)
        {
            Models.ClassStudent obj = new Models.ClassStudent();
            return View();
        }

        // POST: ClassStudent/Create
        [HttpPost]
        public ActionResult Create(Models.ClassStudent obj)
        {
            try
            {
                // TODO: Add insert logic here


                Contextobj.ClassStudent.Add(new Class() { ClassId = obj.ClassId });
                Contextobj.SaveChanges();
                // TODO: Add insert logic here

                return RedirectToAction("Index");
               
            }
            catch
            {
                return View();
            }
        }

        // GET: ClassStudent/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClassStudent/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ClassStudent/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClassStudent/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

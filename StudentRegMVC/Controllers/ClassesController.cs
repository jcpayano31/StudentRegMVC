using StudentRegMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Web.Services.Description;

namespace StudentRegMVC.Controllers
{
    public class ClassesController : Controller
    {
        AdvWebDevProjectEntities Contextobj = new AdvWebDevProjectEntities();

        // GET: Classes
        public ActionResult Index()
        {
            return View();
        }

        // GET: Classes/Create/add
        public ActionResult AddClass()
        {
            Models.Classes obj = new Models.Classes();
           obj.ClassDate = DateTime.Now;
            return View("AddClass", obj);
        }

        // POST: Classes/Create/Add
        [HttpPost]
        public ActionResult AddClass(Models.Classes obj)
        {


            Contextobj.ClassStudent.Add(new Class() { ClassId = obj.ClassId, ClassName = obj.ClassName, ClassDate = obj.ClassDate, ClassDescription = obj.ClassDescription });
            Contextobj.SaveChanges();
            // TODO: Add insert logic here

            //return RedirectToAction("Index");
            return RedirectToAction("AddClass", obj);
           
        }

        
        public ActionResult DisplayClasses()
        {

            IList<Class> ClassesRec = Contextobj.ClassStudent.ToList();
            return View("DisplayClasses", ClassesRec);

        }

        // GET: Classes/Edit/5
        public ActionResult EditClasses(int classid)
        {
            var ClassesRecord = (from item in Contextobj.ClassStudent
                                 where item.ClassId == classid
                                 select item).First();
            return View("EditClasses", ClassesRecord);

        }

        // POST: Classes/Edit/5
        [HttpPost]
        public ActionResult EditClasses(Classes obj)
        {
            try
            {
                var ClassesREcord = (from item in Contextobj.ClassStudent
                                     where item.ClassId == obj.ClassId
                                     select item).First();
                ClassesREcord.ClassId = obj.ClassId;
                ClassesREcord.ClassName = obj.ClassName;
                ClassesREcord.ClassDate = obj.ClassDate;
                ClassesREcord.ClassDescription = obj.ClassDescription;


                Contextobj.SaveChanges();

                var ClassesRecord = Contextobj.ClassStudent.ToList();
                return RedirectToAction("DisplayClasses", "Classes");


            }
            catch
            {
                return View("DisplayClasses", "Classes");
            }
        }

        //GET: Classes/Delete/5
        //public ActionResult DelClass(int classid)
        //{
        //    return View();
        //}

        // POST: Classes/Delete/5
        [HttpPost]
        public ActionResult DelClass(int classid)
        {
            try
            {
                // TODO: Add delete logic

                Class delclasses = Contextobj.ClassStudent.Find(classid);
                Contextobj.ClassStudent.Remove(delclasses);
                Contextobj.SaveChanges();
                return RedirectToAction("DisplayClasses", "Classes");
            }
            catch
            {
                return RedirectToAction("DisplayClasses", "Classes");
            }
        }

        //// GET: Classes/Select/5
        //[HttpPost]
        public ActionResult SelectClasses()
        {
            IList<Class> ClassesRec = Contextobj.ClassStudent.ToList();
            return View("SelectClasses", ClassesRec);
        }
        

    }

}

    
    
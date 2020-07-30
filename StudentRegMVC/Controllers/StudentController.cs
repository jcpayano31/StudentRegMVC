using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentRegMVC.Models;
using System.Data.SqlClient;

namespace StudentRegMVC.Controllers
{


    public class StudentController : Controller
    {
        AdvWebDevProjectEntities Contextobj = new AdvWebDevProjectEntities();

        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;


        // GET: Student
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

                    

            

        // GET: Student/Create/add
        public ActionResult AddStudent()
        {

           

            Models.Student obj = new Models.Student();
            //obj.ClassDate = DateTime.Now;
            return View("AddStudent", obj);
        }
  
        // POST: Studetn/Create/Add
        [HttpPost]
        public ActionResult AddStudent(Models.Student obj)
        {

            AdvWebDevProjectEntities Contextobj = new AdvWebDevProjectEntities();
            try
            {
                Contextobj.Students.Add(new Student() { StudentId = obj.StudentID, StudentName = obj.StudentName, StudentEmail = obj.StudentEmail, StudentLogin = obj.StudentLogin ,StudentPassword =obj.StudentPassword});
                Contextobj.SaveChanges();
                // TODO: Add insert logic here

                return RedirectToAction("AddStudent" ,"Student");
            } 
            catch
            {
                return RedirectToAction("AddStudent", obj);
            }
        }

        void connectionString()
        {
            con.ConnectionString = @"data source=(Local); Initial Catalog=AdvWebDevProject;Integrated Security=SSPI;";
            //con.ConnectionString = @"Data Source=is-root01.ischool.uw.edu;uid=CSharp;pwd=sql;Initial Catalog=AdvWebDevProject;";


        }

        [HttpPost]
        public ActionResult Verify(Student  stu)
        {
            connectionString();
            con.Open();
            com.Connection = con;
                  
            
            com.CommandText = "Select * from Students  where [StudentLogin]='" +stu.StudentName + "' and [StudentPassword]='" + stu.StudentPassword+"'";
            dr = com.ExecuteReader();


            if (dr.Read() )
            {
                con.Close();
                //return RedirectToAction("Index","Home");
                return RedirectToAction("DisplayClasses", "Classes"  );
            }
            else
            {
                con.Close();
                //return View("Error");
                return RedirectToAction("Login");
            }





        }

        public ActionResult DisplayStudent()
        {
          
            List<Student> StudentRec = Contextobj.Students.ToList();

            return View("DisplayStudent", StudentRec);

        }
    }
}
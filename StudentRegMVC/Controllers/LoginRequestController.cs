using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentRegMVC.Models;

namespace StudentRegMVC.Controllers
{
    public class LoginRequestController : Controller
    {
        AdvWebDevProjectEntities Contextobj = new AdvWebDevProjectEntities();
        // GET: LoginRequest
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddLoginRequest()
        {
            Models.LoginRequest obj = new Models.LoginRequest();
            obj.DateRequiedBy = DateTime.Now;
            return View("AddLoginRequest", obj);
        }
        [HttpPost]
        public ActionResult AddLoginRequest(Models.LoginRequest obj)
        {

            Contextobj.LoginRequests.Add(new LoginRequest() { LoginId = obj.LogingID, Name = obj.Name, EmailAddress = obj.EmailAdress, LoginName = obj.LoginName, NewOrReactivate = obj.NewOrReactivaterd, ReasonForAccess = obj.ReasonForAccess, DateRequiredBy = obj.DateRequiedBy });
            Contextobj.SaveChanges();
            //return View("AddLoginRequest", obj);
            return RedirectToAction("DisPlayLoginRequest", obj);
        }

        public ActionResult DisplayLoginRequest()
        {

            List<LoginRequest> LoginRequestRec = Contextobj.LoginRequests.ToList();

            return View("DisplayLoginRequest", LoginRequestRec);

        }

        public ActionResult EditLoginRequest(int loginid)
        {
            var LoginReqRecord = (from item in Contextobj.LoginRequests
                                  where item.LoginId == loginid
                                  select item).First();
            return View("EditLoginRequest", LoginReqRecord);
        }

        [HttpPost]
        public ActionResult EditLoginRequest(LoginRequest obj)
        {
            var LoginReqRecord = (from item in Contextobj.LoginRequests
                                  where item.LoginId == obj.LoginId
                                  select item).First();
            LoginReqRecord.LoginId = obj.LoginId;
            LoginReqRecord.Name = obj.Name;
            LoginReqRecord.EmailAddress = obj.EmailAddress;
            LoginReqRecord.LoginName = obj.LoginName;
            LoginReqRecord.NewOrReactivate = obj.NewOrReactivate;
            LoginReqRecord.ReasonForAccess = obj.ReasonForAccess;
            LoginReqRecord.DateRequiredBy = obj.DateRequiredBy;

            Contextobj.SaveChanges();

            var Loginreqrecords = Contextobj.LoginRequests.ToList();
            return RedirectToAction("DisplayLoginRequest", "LoginRequest");
        }

    }
}
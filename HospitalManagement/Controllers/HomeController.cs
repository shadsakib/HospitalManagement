using HospitalManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages.Html;

namespace HospitalManagement.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            if(Session["UserId"] == null)
            {
                return View();
            }
            else
            {
                return View("LoggedIn");
            }
            
        }

        [HttpPost]
        public ActionResult Register(FormCollection collection)
        {
            bool filledUp = true;
            foreach (string key in collection.AllKeys)
            {
                if (key.StartsWith("_")) continue;
                Response.Write("Key = " + key + " , ");
                Response.Write("Value = " + collection[key]);
                Response.Write("<br/>");
                if (collection[key] == "") filledUp = false;
            }

            if (filledUp) {

                Patient p = new Patient
                {
                    PatientName = collection["PatientName"],
                    BloodGroup = collection["BloodGroup"],
                    ContactNo = collection["ContactNo"],
                    Gender = collection["Gender"],
                    PatientAddress = collection["PatientAddress"],
                    Username = collection["Username"],
                    Password = collection["Password"]
                };

                HospitalContext hospitalContext = new HospitalContext();
                hospitalContext.Patients.Add(p);
                hospitalContext.SaveChanges();

                Session["UserId"] = p.PatientId.ToString();
                Session["Username"] = p.PatientName.ToString();
                return View("Loggedin");
            }

            return View();
        }


        public ActionResult Login()
        {
            if (Session["UserId"] == null)
            {
                return View();
            }
            else
            {
                return View("LoggedIn");
            }
        }

        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            if (Session["UserId"] == null)
            {
                HospitalContext db = new HospitalContext();

                string username = collection["Username"];
                string password = collection["Password"];

                Patient p = null;
                try
                {
                    p = db.Patients.Single(u => u.Username == username && u.Password == password);
                }
                catch (Exception ex) { }

                if (p != null)
                {
                    Session["UserId"] = p.PatientId.ToString();
                    Session["Username"] = p.PatientName.ToString();
                    return View("Loggedin");
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect username or password");
                    return View();
                }
            }
            else
            {
                return View("LoggedIn");
            }
                            
        }

        public ActionResult LoggedIn()
        {
            if(Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                RedirectToAction("Login");
                return View("Login");
            }
     
        }

        public ActionResult Doctor()
        {
            return View();
        }
        public ActionResult Patients()
        {
            HospitalContext patientContext = new HospitalContext();
            var model = new List<Patient>();
            model = patientContext.Patients.ToList();
            return View(model);
        }
        public ActionResult DoctorSchedules()
        {
            HospitalContext doctorScheduleContext = new HospitalContext();
            var model = new List<DoctorSchedule>();
            model = doctorScheduleContext.DoctorSchedules.ToList();
            return View(model);
        }
        public ActionResult Medicines()
        {
            HospitalContext medicineContext = new HospitalContext();
            var model = new List<Medicine>();
            model = medicineContext.Medicines.ToList();
            return View(model);
        }
        public ActionResult Prescriptions()
        {
            HospitalContext prescriptionContext = new HospitalContext();
            var model = new List<Prescription>();
            model = prescriptionContext.Prescriptions.ToList();
            return View(model);
        }
        public ActionResult Tests()
        {
            HospitalContext testContext = new HospitalContext();
            var model = new List<Test>();
            model = testContext.Tests.ToList();
            return View(model);
        }

        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Profile()
        {
            return View();
        }

        public ActionResult Test()
        {
            return View();
        }
    }
}
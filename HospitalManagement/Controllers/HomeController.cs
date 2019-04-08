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

        public ActionResult Appointment()
        {
            HospitalContext hc = new HospitalContext();
            List<Doctor> doctors = hc.Doctors.ToList();
            ViewBag.doctors = doctors;

            return View();
        }

        [HttpPost]
        public ActionResult Appointment(FormCollection collection)
        {
            foreach (string key in collection.AllKeys)
            {       
                Response.Write("Key = " + key + " , ");
                Response.Write("Value = " + collection[key]);
                Response.Write("<br/>");
            }

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
                return RedirectToAction("Test");
            }
            
        }

        [HttpPost]
        public ActionResult Register(FormCollection collection)
        {
            bool filledUp = true;
            foreach (string key in collection.AllKeys)
            {
                if (key.StartsWith("_")) continue;

                /*
                Response.Write("Key = " + key + " , ");
                Response.Write("Value = " + collection[key]);
                Response.Write("<br/>");
                */
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
                return View("Test");
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
                return View("Test");
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
                    return View("Test");
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect username or password");
                    return View();
                }
            }
            else
            {
                return View("Test");
            }
                            
        }

        public ActionResult LoggedIn()
        {
            if(Session["UserId"] != null)
            {
                return View("Test");
            }
            else
            {
                RedirectToAction("Login");
                return View("Login");
            }
     
        }

        public ActionResult AppointmentList()
        {
            HospitalContext hc = new HospitalContext();
            List<Appointment> a = hc.Appointments.ToList();
            return View(a);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }

        public ActionResult Doctor()
        {
            return View();
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
            if(Session["UserId"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {             
                return View();
            }
        }

        [HttpPost]
        public ActionResult Test(FormCollection collection)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult PatientAccountInfo()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                HospitalContext hc = new HospitalContext();
                Patient p = hc.Patients.Find(Int32.Parse(Session["UserId"].ToString()));

                return View(p);
            }
        }

        public ActionResult ViewPrescription()
        {
            HospitalContext hc = new HospitalContext();
            Prescription p = hc.Prescriptions.Find(1);
            return View(p);
        }

        public ActionResult WritePrescription()
        {
            HospitalContext hc = new HospitalContext();
            Prescription p = hc.Prescriptions.Find(1);
            return View(p);
        }

        [HttpPost]
        public ActionResult WritePrescription(FormCollection collection)
        {
            HospitalContext hc = new HospitalContext();
            Prescription p = hc.Prescriptions.Find(1);
            p.Advice = collection["Advice"] ;
            p.Diagnosis = collection["Diagnosis"];
            p.Medication = collection["Medication"];
            p.Symptoms = collection["Symptoms"];
            hc.SaveChanges();
            return View(p);
        }

        public ActionResult PrescriptionList()
        {
            HospitalContext hc = new HospitalContext();
            List<Prescription> p = hc.Prescriptions.ToList();
            return View(p);
        }
    }
}
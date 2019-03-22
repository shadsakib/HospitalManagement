using HospitalManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalManagement.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Exp()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
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
        
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            foreach(string key in collection.AllKeys)
            {
                if (key.StartsWith("_") )continue;
                Response.Write("Key = " + key + " , ");
                Response.Write("Value = " +collection[key]);
                Response.Write("<br/>");
            }

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
            //hospitalContext.SaveChanges();

            return View();
        }
    }
}
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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        public ActionResult Patients()
        {
            PatientContext patientContext = new PatientContext();
            var model = new List<Patient>();
            model = patientContext.Patients.ToList();
            return View(model);
        }
        public ActionResult DoctorSchedules()
        {
            DoctorScheduleContext doctorScheduleContext = new DoctorScheduleContext();
            var model = new List<DoctorSchedule>();
            model = doctorScheduleContext.DoctorSchedules.ToList();
            return View(model);
        }
        public ActionResult Medicines()
        {
            MedicineContext medicineContext = new MedicineContext();
            var model = new List<Medicine>();
            model = medicineContext.Medicines.ToList();
            return View(model);
        }
        public ActionResult Prescriptions()
        {
            PrescriptionContext prescriptionContext = new PrescriptionContext();
            var model = new List<Prescription>();
            model = prescriptionContext.Prescriptions.ToList();
            return View(model);
        }
        public ActionResult Tests()
        {
            TestContext testContext = new TestContext();
            var model = new List<Test>();
            model = testContext.Tests.ToList();
            return View(model);
        }
    }
}
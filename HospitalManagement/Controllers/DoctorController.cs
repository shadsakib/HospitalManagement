using HospitalManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalManagement.Controllers
{
    public class DoctorController : Controller
    {
        // GET: Doctor
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Doctors()
        {
            DoctorContext doctorContext = new DoctorContext();
            var model = new List<Doctor>();
            model = doctorContext.Doctors.ToList();
            return View(model);
        }
    }
}
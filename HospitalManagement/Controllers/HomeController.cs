using HospitalManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages.Html;
using System.Globalization;

namespace HospitalManagement.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Schedule()
        {
            HospitalContext hc = new HospitalContext();
            DoctorSchedule ds = hc.DoctorSchedules.Find(1);
            return View(ds);
        }

        [HttpPost]
        public ActionResult Schedule(FormCollection fc)
        {
            HospitalContext hc = new HospitalContext();
            DoctorSchedule ds = null;
            try
            {
                ds = hc.DoctorSchedules.First(s => s.DoctorId == 1);
            }catch(Exception ex) { }

            //int doctorId = 

            string b = fc["DoctorName"].ToString();
            string c = fc["TotalSlots"];
            string d = fc["DaysOfTheWeek"].ToString();
            string e = fc["Time"].ToString();

            if ( ds == null)
            {
                /*
                DoctorSchedule s = new DoctorSchedule
                {
                    //DoctorId = 
                    DoctorName = b,
                    TotalSlots = Int32.Parse(c),
                    DaysOfTheWeek = d,
                    Time = e
                };
                hc.DoctorSchedules.Add(s);
                */
            }
            else {
                ds.DoctorName = b;
                ds.TotalSlots = Int32.Parse(c);
                ds.DaysOfTheWeek = d;
                ds.Time = e;
                hc.SaveChanges();
            }

            return View(ds);
        }

        public ActionResult MyAppointments()
        {
            HospitalContext hc = new HospitalContext();

            return View(hc.Appointments.ToList());
        }

        public ActionResult DocInfo()
        {
            HospitalContext hc = new HospitalContext();
            Doctor d = hc.Doctors.Find(1);
            return View(d);
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
                    return RedirectToAction("Test");
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect username or password");
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Test");
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
                string doctorName = collection["DoctorName"];
                string patientName = Session["Username"].ToString();
                string date = collection["Date"].ToString();
                string time = collection["Time"].ToString();
                //time = time.Insert(6, ":00");
                //DateTime dt = DateTime.ParseExact("08/04/2019 08:00 PM", "dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture);
                DateTime dt = DateTime.ParseExact(date+" "+time, "dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture);
                Response.Write(date);
                Response.Write(time);
                //DateTime dt = DateTime.ParseExact(date+time, "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
                HospitalContext hc = new HospitalContext();
                Doctor d = hc.Doctors.Single(u => u.DoctorName == doctorName);
                Appointment b = hc.Appointments.OrderByDescending(x => x.AppointmentId).First();
                int k = b.AppointmentId + 1;
                Appointment a = new Appointment
                {
                    DoctorId = d.DoctorId,
                    PatientId = Int32.Parse(Session["UserId"].ToString()),
                    Date = dt,
                };

                hc.Appointments.Add(a);
                hc.SaveChanges();
                return RedirectToAction("AppointmentList");
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

        public ActionResult editDoctorProfile()
        {
            return View();
        }

        public ActionResult DoctorProfile()
        {
            return View();
        }

        public ActionResult Prescription()
        {
            return View();
        }

        public ActionResult WritePrescription()
        {
            HospitalContext hc = new HospitalContext();
            Prescription p = hc.Prescriptions.Find(1);
            Prescription q = new Prescription { Date = DateTime.Today.ToString() };
            return View(q);
        }

        [HttpPost]
        public ActionResult WritePrescription(FormCollection collection)
        {
            HospitalContext hc = new HospitalContext();
            //Prescription p = hc.Prescriptions.Find(1);
            Prescription p = new Prescription();
            p.Advice = collection["Advice"] ;
            p.Diagnosis = collection["Diagnosis"];
            p.Medication = collection["Medication"];
            p.Symptoms = collection["Symptoms"];
            p.Date = DateTime.Today.ToString();
            hc.Prescriptions.Add(p);
            hc.SaveChanges();
            return View(p);
        }

        public ActionResult PrescriptionList()
        {
            HospitalContext hc = new HospitalContext();
            List<Prescription> p = hc.Prescriptions.ToList();

            /*
            List<Appointment> al = hc.Appointments.ToList();
            List<int> pids = new List<int>();
            try
            {
                foreach (var app in al)
                {
                    if (app.PatientId == Int32.Parse(Session["UserId"].ToString()))
                    {
                        pids.Add(app.PrescriptionId);
                    }
                }

                foreach (var pp in p)
                {
                    if (!pids.Contains(pp.PId))
                    {
                        p.Remove(pp);
                    }
                }
            }catch(Exception e) { }
            */
            return View(p);
        }
        public ActionResult DocProfile()
        {
            HospitalContext hc = new HospitalContext();
            List<Appointment> a = hc.Appointments.ToList();
            return View(a);
        }

        public ActionResult DocLogin()
        {
            if (Session["DoctorId"] == null)
            {
                return View();
            }
            else
            {
                return View("DocProfile");
            }
        }

        [HttpPost]
        public ActionResult DocLogin(FormCollection collection)
        {
            if (Session["DoctorId"] == null)
            {
                HospitalContext db = new HospitalContext();

                string username = collection["Username"];
                string password = collection["Password"];

                Doctor d = null;
                try
                {
                    d = db.Doctors.Single(u => u.Username == username && u.Password == password);
                }
                catch (Exception ex) { }

                if (d != null)
                {
                    Session["DoctorId"] = d.DoctorId.ToString();
                    Session["DoctorName"] = d.DoctorName.ToString();
                    Session["UserId"] = d.DoctorId.ToString();
                    return RedirectToAction("DocProfile");
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect username or password");
                    return View();
                }
            }
            else
            {
                return RedirectToAction("DocProfile");
            }

        }

        public ActionResult DocLogout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }


        public ActionResult CreatePrescription()
        {
            return View();
        }
    }
}
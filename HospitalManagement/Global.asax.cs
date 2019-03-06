using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace HospitalManagement
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer<HospitalManagement.Models.DoctorContext>(null);
            Database.SetInitializer<HospitalManagement.Models.DoctorScheduleContext>(null);
            Database.SetInitializer<HospitalManagement.Models.MedicineContext>(null);
            Database.SetInitializer<HospitalManagement.Models.PatientContext>(null);
            Database.SetInitializer<HospitalManagement.Models.PrescriptionContext>(null);
            Database.SetInitializer<HospitalManagement.Models.TestContext>(null);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}

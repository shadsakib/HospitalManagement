using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace HospitalManagement.Models
{
    public class DoctorContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
    }
}
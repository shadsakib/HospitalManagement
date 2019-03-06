using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HospitalManagement.Models
{
    public class PrescriptionContext : DbContext
    {
        public DbSet<Prescription> Prescriptions { get; set; }
    }
}
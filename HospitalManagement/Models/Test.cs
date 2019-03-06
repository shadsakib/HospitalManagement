using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HospitalManagement.Models
{
    [Table("Test")]
    public class Test
    {
        public int TestId { get; set; } 
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string TestName { get; set; }
        public string TestType { get; set; }
        public string Findings { get; set; }
    }
}
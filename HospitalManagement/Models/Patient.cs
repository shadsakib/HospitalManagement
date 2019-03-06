using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HospitalManagement.Models
{
    [Table("Patient")]
    public class Patient
    {
        public int PatientId{ get; set; }
        public string PatientName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string PatientAddress { get; set; }
        public string ContactNo { get; set; }
        public string BloodGroup { get; set; }
}
}
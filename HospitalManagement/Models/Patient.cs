using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalManagement.Models
{
    [Table("Patient")]
    public class Patient
    {
        public int PatientId{ get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string PatientName { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Password { get; set; }
        [Required(ErrorMessage ="This field is required")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string PatientAddress { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string ContactNo { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string BloodGroup { get; set; }
    }

}
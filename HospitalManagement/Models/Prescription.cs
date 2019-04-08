using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HospitalManagement.Models
{
    [Table("Prescription")]
    public class Prescription
    {
        [Key]
        public int PId { get; set; }
        public string Symptoms { get; set; }
        public string Diagnosis { get; set; }
        public string Advice { get; set; }
        public string Medication { get; set; }
        public string Date { get; set; }
    }
}
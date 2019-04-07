using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HospitalManagement.Models
{
    [Table("Appointment")]
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public int PrescriptionId { get; set; }
        public DateTime? Date { get; set; }
        public string Status { get; set; }
    }
}
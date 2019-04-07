using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HospitalManagement.Models
{
    [Table("DoctorSchedule")]
    public class DoctorSchedule
    {
        [Key]
        public int ScheduleId { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public int TotalSlots { get; set; }
        public string DaysOfTheWeek { get; set; }
        public String Time { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HospitalManagement.Models
{
    [Table("Medicine")]
    public class Medicine
    {
        public int MedicineId { get; set; }
        public string BrandName { get; set; }
        public string GenericName { get; set; }
        public string Dosages { get; set; }
        public string SideEffects { get; set; }
    }
}
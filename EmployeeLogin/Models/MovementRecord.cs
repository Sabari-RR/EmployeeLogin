using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeLogin.Models
{
    public class MovementRecord
    {
        [Key]
        public int sl_no { get; set; }
        public int Employeeid { get; set; }
        public String Date_Time { get; set; }
        public String LoginStatus { get; set; }
    }

}

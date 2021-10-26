using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MVCDemoAppMastek.Models
{
    public class Employee
    {
        [Required(ErrorMessage = "EmpId is compulsory field")]
        [RegularExpression(@"[0-9]{4}", ErrorMessage = "Enter four digit EmpId")]
        public int? EmpId { get; set; }

        [Required(ErrorMessage = " EmpName is compulsory field")]
        [StringLength(10, ErrorMessage = "Maximum EmpName length is 10 characters")]
        //[RegularExpression(@"[A-Za-z]{1,10}", ErrorMessage = "Enter only characters")]
        public string EmpName { get; set; }

        [Required(ErrorMessage = "Salary is compulsory field")]
        public double? Salary { get; set; }
    }
}

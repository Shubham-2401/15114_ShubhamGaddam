using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MVCDemoAppMastek.Models
{
    public class EmpMetaData
    {
        [BindRequired , Required]
        public int Empno { get; set; }
        
        [Required(ErrorMessage ="EmpName is required")]
        public string Ename { get; set; }
    }
}

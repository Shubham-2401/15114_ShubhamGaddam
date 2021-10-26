using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MVCDemoAppMastek.Models;
using MVCDemoApp;



namespace MVCDemoApp.ViewModels
{
    public class EmpDepViewModel
    {



        //public IConfiguration Configuration { get; set; }



        public Emp Employee { get; set; }
        public Dept Department { get; set; }

        public IConfiguration Config { get; private set; }

        public EmpDepViewModel(IConfiguration _config)
        {
            Config = _config;
        }


        private int years = 0;
        public int YearsCompleted
        {
            get
            {
                if (Employee.Hiredate.HasValue)
                {
                    years = DateTime.Now.Year - Employee.Hiredate.Value.Year;
                }
                return years;
            }
        }



        private string salarycolor;
        public string SalaryColor
        {
            get
            {
                decimal salvalue = decimal.Parse(Config["salvalue"]);
                if (Employee.Sal.HasValue)
                {
                    if (Employee.Sal.Value > salvalue)
                    {
                        salarycolor = "LightGreen";



                    }
                    else
                    {
                        salarycolor = "LightBlue";
                    }
                }
                else
                {
                    salarycolor = "White";
                }
                return salarycolor;



            }
        }

        public string DeptName
        {
            get
            {
                if (Employee.Deptno.HasValue == false)
                {
                    return string.Empty;
                }
                return Department.Dname;
            }
        }

        public string Location
        {
            get
            {
                if (Employee.Deptno.HasValue == false)
                {
                    return string.Empty;
                }
                return Department.Loc;
            }
        }
    }
}
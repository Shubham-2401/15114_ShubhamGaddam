using System;

namespace HRLib
{
    public class Employee
    {
        #region Fields & Properties

        private string empName;

        public string EmpName
        {
            get { return empName; }
            set { empName = value; }
        }

        private string address;

        public string Address
        {
            get { return address; }
            protected set { address = value; }
        }
        #endregion

        #region Constructor

        public Employee()
        {
            empName = "Shubham";
            address = "Goregaon, Mumbai";
        }

        public Employee(string name, string add)
        {
            this.EmpName = name;
            this.Address = add;
        }

        #endregion

        #region Method
        public override string ToString()
        {
            return string.Format($"Employee Name : {EmpName} Address : {Address}");
        }
        #endregion

    }
}

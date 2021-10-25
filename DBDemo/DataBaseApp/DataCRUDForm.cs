using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLibrary;

namespace DataBaseApp
{
    public partial class DataCRUDForm : Form
    {
        EmpDataStore dataStore = new EmpDataStore(@"server=(localdb)\MSSQLLocalDB;database=Training;Integrated Security=True");
        public DataCRUDForm()
        {
            InitializeComponent();
        }

        private void DataCRUDForm_Load(object sender, EventArgs e)
        {
            dgData.DataSource = dataStore.GetEmps();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAddEmp_Click(object sender, EventArgs e)
        {
            try
            {
                Emp newEmp = new Emp();
                newEmp.EmpNo = int.Parse(txtEmpno.Text);
                newEmp.EmpName = txtEmpName.Text;
                newEmp.HireDate = Convert.ToDateTime(txtHireDate.Text);
                newEmp.Salary = decimal.Parse(txtSalary.Text);

                int count = dataStore.AddEmp(newEmp);

                if (count == 1)
                {
                    MessageBox.Show("Record inserted");
                    dgData.DataSource = dataStore.GetEmps();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtEmpno.Clear();
            txtEmpName.Clear();
            txtHireDate.Clear();
            txtSalary.Clear();
        }

        private void btnEditEmp_Click(object sender, EventArgs e)
        {
            try
            {
                Emp empList = new Emp();
                empList.EmpNo = int.Parse(txtEmpno.Text);
                empList.EmpName = txtEmpName.Text;
                empList.HireDate = Convert.ToDateTime(txtHireDate.Text);
                empList.Salary = decimal.Parse(txtSalary.Text);



                int count = dataStore.EditEmps(empList);



                if (count == 1)
                {
                    MessageBox.Show($"Empno {txtEmpno.Text} is edited");
                    dgData.DataSource = dataStore.GetEmps();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEmpno.Text == "")
                {
                    return;
                }
                else
                {
                    int empid = int.Parse(txtEmpno.Text);
                    int count = dataStore.delEmps(empid);



                    if (count == 1)
                    {
                        MessageBox.Show($"{txtEmpno.Text} is deleted");
                        dgData.DataSource = dataStore.GetEmps();
                    }
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearchEmp_Click(object sender, EventArgs e)
        {
           if (txtEmpno.Text == string.Empty)
            {
                return;
            }
           try
            {
                int empno = int.Parse(txtEmpno.Text);
                Emp emp = dataStore.GetEmpByNo(empno);

                if (emp != null)
                {
                    txtEmpName.Text = emp.EmpName;
                    txtHireDate.Text = emp.HireDate.ToString();
                    txtSalary.Text = emp.Salary.ToString();
                }
                else
                {
                    MessageBox.Show($"Employee by no {empno} not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    } 
}

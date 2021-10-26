using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsAppDemo
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int result = int.Parse(txtFirst.Text) + int.Parse(txtSecond.Text);
            lblMsg.Text = result.ToString();
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            int result = int.Parse(txtFirst.Text) - int.Parse(txtSecond.Text);
            lblMsg.Text = result.ToString();
        }

        private void btnMultiplication_Click(object sender, EventArgs e)
        {
            int result = int.Parse(txtFirst.Text) * int.Parse(txtSecond.Text);
            lblMsg.Text = result.ToString();
        }

        private void btnDivision_Click(object sender, EventArgs e)
        {
            if (int.Parse(txtSecond.Text) > 1)
            {
                int result = int.Parse(txtFirst.Text) / int.Parse(txtSecond.Text);
                lblMsg.Text = result.ToString();
            }
            else
            {
                lblMsg.Text = "Cannot divide by 0";
            }
        }
    }
}

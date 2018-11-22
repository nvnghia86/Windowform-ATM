using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUL;
using DAL;


namespace ATM.UC.UC2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string sql = "select ID from ATM";
            DateTime aDateTime = DateTime.Now;
            lbNgayGD.Text = aDateTime.ToString();
            lbID.Text = sql.ToString();
            lbPhiGD.Text = "1100.00 VNĐ";
        }
    }
}

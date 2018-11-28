using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ATM.UC.UC2
{
    public partial class Fail : UserControl
    {
        private static Fail _instance;
 
        public static Fail Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Fail();
                }
                return _instance;
            }
        }

        public Fail()
        {
            InitializeComponent();
        }

        public void showErrorMoney()
        {
            lbErrorWidth.Visible = false;
            lbErrorMoney.Visible = true;
            lbLimit.Visible = false;

        }
        public void showErrorWidth()
        {
            lbErrorMoney.Visible = false;
            lbErrorWidth.Visible = true;
            lbLimit.Visible = false;
        }
        public void showErrorLimit()
        {
            lbErrorMoney.Visible = false;
            lbErrorWidth.Visible = false;
            lbLimit.Visible = true;
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Fail_Load(object sender, EventArgs e)
        {

        }

        private void lbErrorMoney_Click(object sender, EventArgs e)
        {

        }
    }
}

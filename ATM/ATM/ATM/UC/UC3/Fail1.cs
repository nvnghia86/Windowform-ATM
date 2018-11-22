using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM.UC.UC3
{
    public partial class Fail1 : UserControl
    {
        private static Fail1 _instance;
        public static Fail1 Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Fail1();
                }
                return _instance;
            }
        }

        public Fail1()
        {
            InitializeComponent();
        }

        public void showErrorMoney()
        {
            lbErrorMoney.Visible = true;
            lbErrorCard.Visible = false;
        }

        public void showErrorCard()
        {
            lbErrorMoney.Visible = false;
            lbErrorCard.Visible = true;
        }
    }
}

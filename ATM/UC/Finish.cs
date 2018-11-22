using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM.UC
{
    public partial class Finish : UserControl
    {
        private static Finish _instance;
        public static Finish Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Finish();
                }
                return _instance;
            }
        }
        public Finish()
        {
            InitializeComponent();
            formMain.state = "finish";
        }
    }
}

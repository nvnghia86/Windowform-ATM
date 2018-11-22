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
    public partial class Success1 : UserControl
    {
        private static Success1 _instance;
        public static Success1 Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Success1();
                }
                return _instance;
            }
        }

        public Success1()
        {
            InitializeComponent();
        }
    }
}

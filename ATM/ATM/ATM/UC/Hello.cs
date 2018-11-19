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
    public partial class Hello : UserControl
    {
        private static Hello _instance;
        public static Hello Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Hello();
                }
                return _instance;
            }
        }
        public Hello()
        {
            InitializeComponent();
        }
    }
}

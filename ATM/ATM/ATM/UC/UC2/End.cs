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
    public partial class End : UserControl
    {
        private static End _instance;
        public static End Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new End();
                }
                return _instance;
            }
        }
        public End()
        {
            InitializeComponent();
        }

        private void End_Load(object sender, EventArgs e)
        {

        }
    }
}

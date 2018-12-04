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
    public partial class NhanTien : UserControl
    {
        private static NhanTien _instance;
        public static NhanTien Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new NhanTien();
                }
                return _instance;
            }
        }
        public NhanTien()
        {
            InitializeComponent();
        }

        private void End_Load(object sender, EventArgs e)
        {

        }
    }
}

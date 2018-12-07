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

    public partial class DangThucHien : UserControl
    {
        public DangThucHien()
        {
            InitializeComponent();
        }
        private static DangThucHien _instance;
        public static DangThucHien Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DangThucHien();
                }
                return _instance;
            }
        }
    }


}

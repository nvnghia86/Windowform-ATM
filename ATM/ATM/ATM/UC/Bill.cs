using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM
{
    public partial class HoaDon : UserControl
    {
        
        public HoaDon()
        {
            InitializeComponent();
        }

        private void HoaDon_Load(object sender, EventArgs e)
        {
            DateTime aDateTime = DateTime.Now;
            lbNgayGD.Text = aDateTime.ToString();
            
        }
        
    }
}

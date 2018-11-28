using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUL;
using DAL;
using ATM.UC.UC3;

namespace ATM
{
    public partial class HoaDon : UserControl
    {
        private LogDAL logDAL = new LogDAL();
        private LogBUL logBUL = new LogBUL();
        private CardBUL cardBUL = new CardBUL();
        private static HoaDon _instance;
        public static HoaDon Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new HoaDon();
                }
                return _instance;
            }
        }
        public HoaDon()
        {
            InitializeComponent();
        }
        public void setLbBalance(string balance)
        {
            lbSoDu.Text = balance + " VND";
        }

        private void HoaDon_Load(object sender, EventArgs e)
        {
              
        }
        
    }
}

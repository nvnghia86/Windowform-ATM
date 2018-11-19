using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM.UC.UC6
{
    public partial class OldPIN : UserControl
    {
        private static OldPIN _instance;
        public static OldPIN Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new OldPIN();
                }
                return _instance;
            }
        }
        public OldPIN()
        {
            InitializeComponent();
        }
        public Label getLbCheckPIN()
        {
            return lbCheckMaPIN;
        }

        public string getTextBoxPin()
        {
            return tbPIN.Text;
        }

        public void setTextBoxPIN(string str)
        {
            if (tbPIN.Text.Length < 5)
                tbPIN.Text = tbPIN.Text + str;
        }

        public void clearTextBoxPIN()
        {
            tbPIN.Text = "";
        }

        public Label getLbLockCard()
        {
            return lbLockCard;
        }
    }
}

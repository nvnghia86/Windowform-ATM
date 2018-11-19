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
    public partial class MainMenu : UserControl
    {
        private static MainMenu _instance;
        public static MainMenu Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MainMenu();
                }
                return _instance;
            }
        }
        public MainMenu()
        {
            InitializeComponent();
            formMain.state = "mainMenu";
            
        }
        public void setNameHello(string name)
        {
            lblHello.Text = name;
        }
    }
}

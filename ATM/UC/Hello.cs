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
        List<string> path = new List<string>();
        int index = 0;
        public Hello()
        {
            InitializeComponent();
            path.Add(@"C:\Users\this PC\Desktop\ATM\ATM\Resources\hello.jpg");
            path.Add(@"C:\Users\this PC\Desktop\ATM\ATM\Resources\hello001.jpg");
            path.Add(@"C: \Users\this PC\Desktop\ATM\ATM\Resources\hello002.jpg");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            this.BackgroundImage = Image.FromFile(path[index]);
            index++;
            if (index == path.Count)
            {
                index = 0;
            }
        }
    }
}



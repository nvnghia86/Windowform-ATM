﻿using System;
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
    public partial class ListMenu : UserControl
    {
        private static ListMenu _instance;
        public static ListMenu Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ListMenu();
                }
                return _instance;
            }
        }
        public ListMenu()
        {
            InitializeComponent();
            formMain.state = "menu";
        }
        public void setNameHello(string name)
        {
            lblHello.Text = name;
        }

        
    }
}
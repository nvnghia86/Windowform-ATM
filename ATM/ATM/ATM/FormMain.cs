﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ATM.UC;
using ATM.UC.UC6;
using ATM.UC.UC1;
using BUL;
using DAL;


namespace ATM
{
    public partial class formMain : Form
    {
        public static string state;
        private CardBUL carcBUL = new CardBUL();
        private CustomerBUL custBUL = new CustomerBUL();
        private LogBUL logBUL = new LogBUL();
        private ConfigBUL configBUL = new ConfigBUL();
        private AccountBUL accountBUL = new AccountBUL();
        private StockBUL stockBUL = new StockBUL();
        private int numberRecord;
        public formMain()
        {
            InitializeComponent();
            state = "hello";
            panelMain.Controls.Add(Hello.Instance);
        }

        #region button_click
        private void btnThe_Click(object sender, EventArgs e)
        {
            numberRecord = configBUL.getNumPerPage();

            state = "validateCard";
            if (!panelMain.Controls.Contains(ValidateCard.Instance))
            {
                panelMain.Controls.Add(ValidateCard.Instance);
                ValidateCard.Instance.Dock = DockStyle.Fill;
                ValidateCard.Instance.BringToFront();
            }
            else
            {
                ValidateCard.Instance.BringToFront();
            }
        }
        private void btnEnter_Click(object sender, EventArgs e)
        {
            // state validate card
            if (state.Equals("validateCard"))
            {
                checkCardNo();
            }
            // state validate PIN
            else if (state.Equals("validatePin"))
            {
                checkPIN();
            }
            else if (state.Equals("oldPIN"))
            {
                checkOldPIN();

            }
            // state new PIN
            else if (state.Equals("newPIN"))
            {
                changePIN();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // state validate card
            if (state.Equals("validateCard"))
            {
                ValidateCard.Instance.clearTextBoxCardNo();
            }
            // state validate PIN
            else if (state.Equals("validatePin"))
            {
                ValidatePin.Instance.clearTextBoxPIN();
            }
            else if (state.Equals("oldPIN"))
            {
                OldPIN.Instance.clearTextBoxPIN();
            }
            // state change PIN
            else if (state.Equals("newPIN"))
            {
                NewPIN.Instance.clearTextBoxNewPIN();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // back to hello
            if (state.Equals("validateCard"))
            {
                exitValidatecard();
            }
            else if(state.Equals("validatePin"))
            {
                exitValidatecard();
            }
            // back to List menu
            else if (state.Equals("oldPIN") || state.Equals("newPIN") || state.Equals("changePINFail") || state.Equals("changePINSuccess"))
            {
                exitChangePIN();
                OldPIN.Instance.clearTextBoxPIN();
                NewPIN.Instance.clearTextBoxNewPIN();
            }
            // back to Validate Card
            else if (state.Equals("menu"))
            {
                exitListMenu();
            }

        }

        private void btnLeft1_Click(object sender, EventArgs e)
        {

        }

        private void btnLeft2_Click(object sender, EventArgs e)
        {

        }

        private void btnLeft3_Click(object sender, EventArgs e)
        {

        }

        private void btnLeft4_Click(object sender, EventArgs e)
        {
            if (state.Equals("menu"))
            {
                openStateOldPIN();
            }         
        }

        private void btnRight1_Click(object sender, EventArgs e)
        {

        }

        private void btnRight2_Click(object sender, EventArgs e)
        {

        }

        private void btnRight3_Click(object sender, EventArgs e)
        {
            // state validate card
            if (state.Equals("validateCard"))
            {
                checkCardNo();
            }
            // state validate PIN
            else if (state.Equals("validatePin"))
            {
                checkPIN();
            }
            else if (state.Equals("oldPIN"))
            {
                checkOldPIN();
                    
            }
            else if (state.Equals("newPIN"))
            {
                changePIN();
            }
            else if(state.Equals("changePINSuccess"))
            {
                exitChangePIN();
            }
        }

        private void btnRight4_Click(object sender, EventArgs e)
        {
            // state validate card
            if (state.Equals("validateCard"))
            {
                exitValidatecard();

            }
            // state validate PIN
            else if (state.Equals("validatePin"))
            {
                exitValidatePIN();
            }
            else if (state.Equals("oldPIN") || state.Equals("newPIN") || state.Equals("changePINFail") )
            {
                exitChangePIN();
                OldPIN.Instance.clearTextBoxPIN();
                NewPIN.Instance.clearTextBoxNewPIN();
            }
            else if(state.Equals("changePINSuccess"))
            {
                exit();
            }

        } 
        #endregion

        #region Key_click
        private void btn1_Click(object sender, EventArgs e)
        {
            if (state.Equals("validateCard"))
                enterTextBox("1");
            else if (state.Equals("validatePin"))
                enterTextBox("1");
            else if (state.Equals("oldPIN"))
                enterTextBox("1");
            else if (state.Equals("newPIN"))
                enterTextBox("1");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (state.Equals("validateCard"))
                enterTextBox("2");
            else if (state.Equals("validatePin"))
                enterTextBox("2");
            else if (state.Equals("oldPIN"))
                enterTextBox("2");
            else if (state.Equals("newPIN"))
                enterTextBox("2");
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (state.Equals("validateCard"))
                enterTextBox("3");
            else if (state.Equals("validatePin"))
                enterTextBox("3");
            else if (state.Equals("oldPIN"))
                enterTextBox("3");
            else if (state.Equals("newPIN"))
                enterTextBox("3");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (state.Equals("validateCard"))
                enterTextBox("4");
            else if (state.Equals("validatePin"))
                enterTextBox("4");
            else if (state.Equals("oldPIN"))
                enterTextBox("4");
            else if (state.Equals("newPIN"))
                enterTextBox("4");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (state.Equals("validateCard"))
                enterTextBox("5");
            else if (state.Equals("validatePin"))
                enterTextBox("5");
            else if (state.Equals("oldPIN"))
                enterTextBox("5");
            else if (state.Equals("newPIN"))
                enterTextBox("5");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (state.Equals("validateCard"))
                enterTextBox("6");
            else if (state.Equals("validatePin"))
                enterTextBox("6");
            else if (state.Equals("oldPIN"))
                enterTextBox("6");
            else if (state.Equals("newPIN"))
                enterTextBox("6");
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (state.Equals("validateCard"))
                enterTextBox("7");
            else if (state.Equals("validatePin"))
                enterTextBox("7");
            else if (state.Equals("oldPIN"))
                enterTextBox("7");
            else if (state.Equals("newPIN"))
                enterTextBox("7");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (state.Equals("validateCard"))
                enterTextBox("8");
            else if (state.Equals("validatePin"))
                enterTextBox("8");
            else if (state.Equals("oldPIN"))
                enterTextBox("8");
            else if (state.Equals("newPIN"))
                enterTextBox("8");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (state.Equals("validateCard"))
                enterTextBox("9");
            else if (state.Equals("validatePin"))
                enterTextBox("9");
            else if (state.Equals("oldPIN"))
                enterTextBox("9");
            else if (state.Equals("newPIN"))
                enterTextBox("9");
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if (state.Equals("validateCard"))
                enterTextBox("0");
            else if (state.Equals("validatePin"))
                enterTextBox("0");
            else if (state.Equals("oldPIN"))
                enterTextBox("0");
            else if (state.Equals("newPIN"))
                enterTextBox("0");
        } 
        #endregion

        //////////////////////////////////SV1: Nguyễn Đức Mạnh
        private void enterTextBox(string str)
        {
            // state validate card
            if (state.Equals("validateCard"))
            {
                ValidateCard.Instance.setTextBoxCardNo(str);
            }
            // state validate PIN
            else if (state.Equals("validatePin"))
            {
                ValidatePin.Instance.setTextBoxPIN(str);
            }
            else if (state.Equals("oldPIN"))
            {
                OldPIN.Instance.setTextBoxPIN(str);
            }
            //state change PIN
            else if (state.Equals("newPIN"))
            {
                NewPIN.Instance.setTextBoxNewPIN(str);
            }
        }
        //////////////////////////////////SV1: Nguyễn Đức Mạnh
        //back hello
        private void exitValidatecard()
        {
            if (!panelMain.Controls.Contains(ValidateCard.Instance))
            {
                panelMain.Controls.Add(Hello.Instance);
                Hello.Instance.Dock = DockStyle.Fill;
                Hello.Instance.BringToFront();
            }
            else
            {
                Hello.Instance.BringToFront();
            }
            state = "hello";
            ValidateCard.Instance.getlbCheckMa().Visible = false;

        }
        // function to check CardNo
        private void checkCardNo()
        {
            bool checkSuccess = carcBUL.checkCardNo(ValidateCard.Instance.getTextBoxCardNo());
            if (checkSuccess)
            {
                lbCardNo.Text = ValidateCard.Instance.getTextBoxCardNo();
                if (!panelMain.Controls.Contains(ValidatePin.Instance))
                {
                    panelMain.Controls.Add(ValidatePin.Instance);
                    ValidatePin.Instance.Dock = DockStyle.Fill;
                    ValidatePin.Instance.BringToFront();
                }
                else
                {
                    ValidatePin.Instance.BringToFront();
                }
                ValidateCard.Instance.clearTextBoxCardNo();
                state = "validatePin";
            }
            else
            {
                ValidateCard.Instance.getlbCheckMa().Visible = true;
                ValidateCard.Instance.clearTextBoxCardNo();
            }
        }

        // function to check PIN
        private void checkPIN()
        {
            bool checkAttempt = carcBUL.checkAttempt(lbCardNo.Text);
            bool checkStatus = carcBUL.checkStatus(lbCardNo.Text);
            bool checkExpiredDate = carcBUL.checkExpiredDate(lbCardNo.Text);
            if (carcBUL.checkPIN(lbCardNo.Text).Equals(ValidatePin.Instance.getTextBoxPin()) && checkAttempt && checkStatus && checkExpiredDate)
            {
                if (!panelMain.Controls.Contains(ListMenu.Instance))
                {
                    panelMain.Controls.Add(ListMenu.Instance);
                    ListMenu.Instance.Dock = DockStyle.Fill;
                    ListMenu.Instance.BringToFront();
                }
                else
                {
                    ListMenu.Instance.BringToFront();
                }
                state = "menu";
                ValidatePin.Instance.clearTextBoxPIN();
                ListMenu.Instance.setNameHello(custBUL.getNameCustomer(lbCardNo.Text));
            }
            else if (carcBUL.checkPIN(lbCardNo.Text).Equals(ValidatePin.Instance.getTextBoxPin()) || !checkAttempt || !checkStatus || !checkExpiredDate)
            {
                ValidatePin.Instance.getLbLockCard().Visible = true;
            }
            else
            {
                ValidatePin.Instance.getLbCheckPIN().Visible = true;
                ValidatePin.Instance.clearTextBoxPIN();
                bool checkUpdateAttempt = carcBUL.updateAttempt(lbCardNo.Text);
            }
        }
        //
        private void checkOldPIN()
        {
            bool checkAttempt = carcBUL.checkAttempt(lbCardNo.Text);
            bool checkStatus = carcBUL.checkStatus(lbCardNo.Text);
            bool checkExpiredDate = carcBUL.checkExpiredDate(lbCardNo.Text);
            if (carcBUL.checkPIN(lbCardNo.Text).Equals(OldPIN.Instance.getTextBoxPin()) && checkAttempt && checkStatus && checkExpiredDate)
            {
                if (!panelMain.Controls.Contains(NewPIN.Instance))
                {
                    panelMain.Controls.Add(NewPIN.Instance);
                    NewPIN.Instance.Dock = DockStyle.Fill;
                    NewPIN.Instance.BringToFront();
                }
                else
                {
                    NewPIN.Instance.BringToFront();
                }
                state = "newPIN";
                OldPIN.Instance.clearTextBoxPIN();

            }
            else if (carcBUL.checkPIN(lbCardNo.Text).Equals(OldPIN.Instance.getTextBoxPin()) || !checkAttempt || !checkStatus || !checkExpiredDate)
            {
                OldPIN.Instance.getLbLockCard().Visible = true;
            }
            else
            {
                OldPIN.Instance.getLbCheckPIN().Visible = true;
                OldPIN.Instance.clearTextBoxPIN();
                bool checkUpdateAttempt = carcBUL.updateAttempt(lbCardNo.Text);
            }
        }

        // function to change PIN
        private void changePIN()
        {
            if (NewPIN.Instance.getTextBoxNewPIN().Length == 0)
            {
                state = "changePINFail";
                if (!panelMain.Controls.Contains(ChangePINFail.Instance))
                {
                    panelMain.Controls.Add(ChangePINFail.Instance);
                    ChangePINFail.Instance.Dock = DockStyle.Fill;
                    ChangePINFail.Instance.BringToFront();
                }
                else
                {
                    ChangePINFail.Instance.BringToFront();
                }
                return;
            }
            bool checkChangePIN = carcBUL.changePIN(lbCardNo.Text, NewPIN.Instance.getTextBoxNewPIN());
            if (checkChangePIN)
            {
                state = "changePINSuccess";
                createLog("logtype04", 0, "", lbCardNo.Text, "atm01", "New PIN:" + NewPIN.Instance.getTextBoxNewPIN());
                if (!panelMain.Controls.Contains(ChangePINSuccess.Instance))
                {
                    panelMain.Controls.Add(ChangePINSuccess.Instance);
                    ChangePINSuccess.Instance.Dock = DockStyle.Fill;
                    ChangePINSuccess.Instance.BringToFront();
                }
                else
                {
                    ChangePINSuccess.Instance.BringToFront();
                }
            }
            else
            {
                state = "changePINFail";
                if (!panelMain.Controls.Contains(ChangePINFail.Instance))
                {
                    panelMain.Controls.Add(ChangePINFail.Instance);
                    ChangePINFail.Instance.Dock = DockStyle.Fill;
                    ChangePINFail.Instance.BringToFront();
                }
                else
                {
                    ChangePINFail.Instance.BringToFront();
                }
            }
        }
        // switch from control list service to control change pin
        private void openStateOldPIN()
        {
            if (!panelMain.Controls.Contains(OldPIN.Instance))
            {
                panelMain.Controls.Add(OldPIN.Instance);
                OldPIN.Instance.Dock = DockStyle.Fill;
                OldPIN.Instance.BringToFront();
            }
            else
            {
                OldPIN.Instance.BringToFront();
            }
            state = "oldPIN";
        }


        // back to state validate card from state validate pin
        private void exitValidatePIN()
        {
            ValidatePin.Instance.clearTextBoxPIN();
            ValidatePin.Instance.getLbLockCard().Visible = false;
            ValidatePin.Instance.getLbCheckPIN().Visible = false;
            if (!panelMain.Controls.Contains(ValidateCard.Instance))
            {
                panelMain.Controls.Add(ValidatePin.Instance);
                ValidateCard.Instance.Dock = DockStyle.Fill;
                ValidateCard.Instance.BringToFront();
            }
            else
            {
                ValidateCard.Instance.BringToFront();
            }
            lbCardNo.Text = "";
            ValidateCard.Instance.clearTextBoxCardNo();
            state = "validateCard";
        }

        // back to state list menu from state change PIN
        private void exitChangePIN()
        {
            NewPIN.Instance.clearTextBoxNewPIN();
            NewPIN.Instance.reset();
            if (!panelMain.Controls.Contains(ListMenu.Instance))
            {
                panelMain.Controls.Add(ListMenu.Instance);
                ListMenu.Instance.Dock = DockStyle.Fill;
                ListMenu.Instance.BringToFront();
            }
            else
            {
                ListMenu.Instance.BringToFront();
            }
            state = "menu";
            ListMenu.Instance.setNameHello(custBUL.getNameCustomer(lbCardNo.Text));
        }
        private void exit()
        {
           
            if (!panelMain.Controls.Contains(Finish.Instance))
            {
                panelMain.Controls.Add(Finish.Instance);
                Finish.Instance.Dock = DockStyle.Fill;
                Finish.Instance.BringToFront();
            }
            else
            {
                Finish.Instance.BringToFront();
            }
            state = "finish";
           
        }

        // back to state validate card from state list service
        private void exitListMenu()
        {
            if (!panelMain.Controls.Contains(ValidateCard.Instance))
            {
                panelMain.Controls.Add(ValidateCard.Instance);
                ValidateCard.Instance.Dock = DockStyle.Fill;
                ValidateCard.Instance.BringToFront();
            }
            else
            {
                ValidateCard.Instance.BringToFront();
            }
            state = "validateCard";
        }
        // function to create log
        private void createLog(string logType, int amount, string cardTo, string cardNo, string atmId, string details)
        {
            string dateTime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzz");
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            string logID = "log" + date;
            bool checkCreateLog = logBUL.createLog(logID, date, amount, details, cardTo, logType, atmId, cardNo);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ATM.UC.UC1;
using ATM.UC.UC6;
using ATM.UC;

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
        private int pageNumber;
        private int numberRecord;

        public formMain()
        {
            state = "hello";
            panelMain.Controls.Add(Hello.Instance);
            InitializeComponent();
        }

        private void btnThe_Click(object sender, EventArgs e)
        {
            pageNumber = 1;
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
            // state change PIN

            else if (state.Equals("changePIN"))
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
            // state change PIN
            else if (state.Equals("changePIN"))
            {
                ChangePIN.Instance.clearTextBoxNewPIN();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //back to hello
            if (state.Equals("validateCard"))
            {
                exitValidatecard();
            }
            // back to List service 
            else if (state.Equals("newPIN") || state.Equals("changePINFail") || state.Equals("changePINSuccess"))
            {
                exitChangePIN();
            }
            // back to Validate Card
            else if (state.Equals("mainMenu"))
            {
                exitListService();
            }
            // back to List service 
            
        }

       
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

        #region key_click

        private void btn1_Click(object sender, EventArgs e)
        {
            if (state.Equals("validateCard"))
                enterTextBox("1");
            else if (state.Equals("validatePin"))
                enterTextBox("1");
            else if (state.Equals("oldPIN"))
                enterTextBox("1");
            else if (state.Equals("changePIN"))
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
            else if (state.Equals("changePIN"))
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
            else if (state.Equals("changePIN"))
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
            else if (state.Equals("changePIN"))
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
            else if (state.Equals("changePIN"))
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
            else if (state.Equals("changePIN"))
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
            else if (state.Equals("changePIN"))
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
            else if (state.Equals("changePIN"))
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
            else if (state.Equals("changePIN"))
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
            else if (state.Equals("changePIN"))
                enterTextBox("0");

        }

        #endregion
        #region button_click
        private void btnLeft1_Click(object sender, EventArgs e)
        {
            //// state widthdraw
            //if (state.Equals("widthdraw")) {
            //    widthdrawSelectOne();
            //}
        }

        private void btnLeft2_Click(object sender, EventArgs e)
        {
            //// withDraw
            //if (state.Equals("listService")) {
            //    openStateWidthdraw();
            //}
            //// state widthdraw
            //else if (state.Equals("widthdraw"))
            //{
            //    widthdrawSelectTwo();
            //}


        }

        private void btnLeft3_Click(object sender, EventArgs e)
        {
            // check balance
            //if (state.Equals("listService"))
            //{
            //    openStateCheckBalance();
            //}
            //// state widthdraw
            //else if (state.Equals("widthdraw"))
            //{
            //    widthdrawSelectThree();
            //}

        }

        private void btnLeft4_Click(object sender, EventArgs e)
        {
            // change PIN
            if (state.Equals("listService"))
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
        }

        private void btnRight4_Click(object sender, EventArgs e)
        {
            // state validate card
            if (state.Equals("validateCard"))
            {
                ValidateCard.Instance.clearTextBoxCardNo();
            }
            // state validate PIN
            else if (state.Equals("validatePin"))
            {
                exitValidatePIN();
            }
            // view history
            else if (state.Equals("listService"))
            {
                openStateViewHistory();
            }
            else if (state.Equals("viewHistory"))
            {
                nextPageViewHistory();
            }
            // state check Balance
            //else if (state.Equals("checkBalance"))
            //{
            //    endUser();
            //}
            //// state cash transfer card
            //else if (state.Equals("cashTransferCard"))
            //{
            //    exitCashTransferCard();
            //}
            //// state cash transfer money
            //else if (state.Equals("cashTransferMoney"))
            //{
            //    exitCashTransferMoney();
            //}
            //// state custom widthdraw
            //else if (state.Equals("widthdraw"))
            //{
            //    openStateCustomWidthdraw();
            //}
        }
        #endregion
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
                if (!panelMain.Controls.Contains(MainMenu.Instance))
                {
                    panelMain.Controls.Add(MainMenu.Instance);
                    MainMenu.Instance.Dock = DockStyle.Fill;
                    MainMenu.Instance.BringToFront();
                }
                else
                {
                    MainMenu.Instance.BringToFront();
                }
                state = "mainMenu";
                ValidatePin.Instance.clearTextBoxPIN();
                MainMenu.Instance.setNameHello(custBUL.getNameCustomer(lbCardNo.Text));
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

        // back to state list service from state change PIN
        private void exitChangePIN()
        {
            NewPIN.Instance.clearTextBoxNewPIN();
            NewPIN.Instance.reset();
            if (!panelMain.Controls.Contains(MainMenu.Instance))
            {
                panelMain.Controls.Add(MainMenu.Instance);
                MainMenu.Instance.Dock = DockStyle.Fill;
                MainMenu.Instance.BringToFront();
            }
            else
            {
                MainMenu.Instance.BringToFront();
            }
            state = "mainMenu";
            MainMenu.Instance.setNameHello(custBUL.getNameCustomer(lbCardNo.Text));
        }

        // back to state validate card from state list service
        private void exitListService()
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

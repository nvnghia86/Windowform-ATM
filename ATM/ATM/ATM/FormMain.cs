using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ATM.UC;
using ATM.UC.UC6;
using ATM.UC.UC1;
using ATM.UC.UC3;
using ATM.UC.UC2;
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
        private LogDAL logDAL = new LogDAL();
        
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
            // state cash transfer card
            else if (state.Equals("cashTransferCard"))
            {
                pressEnterCashTransferCard();
            }
            // state cash transfer money
            else if (state.Equals("cashTransferMoney"))
            {
                pressEnterCashTransferMoney();
            }

            else if (state.Equals("customWidthdraw"))
            {
                pressEnterCustomWidthdraw();
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
            // state cash transfer card
            else if (state.Equals("cashTransferCard"))
            {
                CashTransfer.Instance.clearTextBoxCardNoTo();
            }
            // state cash transfer money
            else if (state.Equals("cashTransferMoney"))
            {
                CashTransfer.Instance.clearTextBoxMoneyTransfer();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // back to hello
            if (state.Equals("validateCard"))
            {
                exitValidatecard();
            }
            else if (state.Equals("validatePin"))
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

            // state cash transfer card
            else if (state.Equals("cashTransferCard"))
            {
                exitCashTransferCard();
            }
            // state cash transfer money
            else if (state.Equals("cashTransferMoney"))
            {
                exitCashTransferMoney();
            }
            // state cash transfer money
            else if (state.Equals("success"))
            {
                exitSuccessCashTransfer();
            }
            // state cash transfer money
            else if (state.Equals("fail"))
            {
                exitFailCashTransfer();
            }
            // state widthdraw
            else if (state.Equals("widthdraw"))
            {
                exitWidthdraw();
            }

        }

        private void btnLeft1_Click(object sender, EventArgs e)
        {
            if (state.Equals("widthdraw"))
            {
                widthdrawSelectOne();
            }

        }

        private void btnLeft2_Click(object sender, EventArgs e)
        {
            if (state.Equals("widthdraw"))
            {
                widthdrawSelectThree();
            }
            if (state.Equals("menu"))
            {
                openStateCheckBalance();
            }

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
            if (state.Equals("menu"))
            {
                openStateWidthdraw();
            }
            else if (state.Equals("widthdraw"))
            {
                widthdrawSelectTwo();
            }

        }

        private void btnRight2_Click(object sender, EventArgs e)
        {
            if (state.Equals("widthdraw"))
            {
                widthdrawSelectFour();
            }
            else if (state.Equals("success"))
            {
                exitChangePIN();
            }
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
            else if (state.Equals("changePINSuccess"))
            {
                exitChangePIN();
            }
            // state cash transfer
            else if (state.Equals("menu"))
            {
                openStateCashTransfer();
            }
            // state cash transfer card
            else if (state.Equals("cashTransferCard"))
            {
                checkCardStateCashTransfer();
            }
            // state cash transfer money
            else if (state.Equals("cashTransferMoney"))
            {
                processCashTransfer();
            }
            else if (state.Equals("widthdraw"))
            {
                openStateCustomWidthdraw();
            }
            else if (state.Equals("fail"))
            {
                exitChangePIN();
            }
            else if (state.Equals("success"))
            {
                exitChangePIN();
            }
            else if (state.Equals("customWidthdraw"))
            {
                pressEnterCustomWidthdraw();
            }
            else if (state.Equals("receivebill"))
            {
                openSuccess();
            }
            else if (state.Equals("success2"))
            {
                exitChangePIN();
            }
            else if (state.Equals("checkBalance"))
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
            else if (state.Equals("oldPIN") || state.Equals("newPIN") || state.Equals("changePINFail"))
            {
                exitChangePIN();
                OldPIN.Instance.clearTextBoxPIN();
                NewPIN.Instance.clearTextBoxNewPIN();
            }
            else if (state.Equals("changePINSuccess"))
            {
                exit();
            }

            // state cash transfer card
            else if (state.Equals("cashTransferCard"))
            {
                exitCashTransferCard();
            }
            // state cash transfer money
            else if (state.Equals("cashTransferMoney"))
            {
                exitCashTransferMoney();
            }
            else if (state.Equals("customWidthdraw"))
            {
                exitValidatecard();
            }
            else if (state.Equals("fail"))
            {
                exitValidatecard();
            }
            else if (state.Equals("success"))
            {
                exitValidatecard();
            }
            else if (state.Equals("receivebill"))
            {
                openSuccess();
            }
            else if (state.Equals("success2"))
            {
                openEnd();
            }
            else if (state.Equals("checkBalance"))
            {
                exitValidatecard();
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
            else if (state.Equals("cashTransferCard"))
                enterTextBox("1");
            else if (state.Equals("cashTransferMoney"))
                enterTextBox("1");
            else if (state.Equals("customWidthdraw"))
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
            else if (state.Equals("cashTransferCard"))
                enterTextBox("2");
            else if (state.Equals("cashTransferMoney"))
                enterTextBox("2");
            else if (state.Equals("customWidthdraw"))
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

            else if (state.Equals("cashTransferCard"))
                enterTextBox("3");
            else if (state.Equals("cashTransferMoney"))
                enterTextBox("3");
            else if (state.Equals("customWidthdraw"))

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
            else if (state.Equals("cashTransferCard"))
                enterTextBox("4");
            else if (state.Equals("cashTransferMoney"))
                enterTextBox("4");
            else if (state.Equals("customWidthdraw"))

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
            else if (state.Equals("cashTransferCard"))
                enterTextBox("5");
            else if (state.Equals("cashTransferMoney"))
                enterTextBox("5");
            else if (state.Equals("customWidthdraw"))

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
            else if (state.Equals("cashTransferCard"))
                enterTextBox("6");
            else if (state.Equals("cashTransferMoney"))
                enterTextBox("6");
            else if (state.Equals("customWidthdraw"))

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

            else if (state.Equals("cashTransferCard"))
                enterTextBox("7");
            else if (state.Equals("cashTransferMoney"))
                enterTextBox("7");
            else if (state.Equals("customWidthdraw"))

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

            else if (state.Equals("cashTransferCard"))
                enterTextBox("8");
            else if (state.Equals("cashTransferMoney"))
                enterTextBox("8");
            else if (state.Equals("customWidthdraw"))

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

            else if (state.Equals("cashTransferCard"))
                enterTextBox("9");
            else if (state.Equals("cashTransferMoney"))
                enterTextBox("9");
            else if (state.Equals("customWidthdraw"))

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

            else if (state.Equals("cashTransferCard"))
                enterTextBox("0");
            else if (state.Equals("cashTransferMoney"))
                enterTextBox("0");
            else if (state.Equals("customWidthdraw"))

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

            //state cash transfer
            else if (state.Equals("cashTransferCard"))
            {
                CashTransfer.Instance.setTextBoxCardNoTo(str);
            }
            else if (state.Equals("cashTransferMoney"))
            {
                CashTransfer.Instance.setTextBoxMoneyTransfer(str);
            }
            else if (state.Equals("customWidthdraw"))
            {
                CustomWidthdraw.Instance.setTextBoxCustom(str);

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
        //Ngô Minh Thắng
        // switch from control list service to control cash transfer
        private void openStateCashTransfer()
        {
            if (!panelMain.Controls.Contains(CashTransfer.Instance))
            {
                panelMain.Controls.Add(CashTransfer.Instance);
                CashTransfer.Instance.Dock = DockStyle.Fill;
                CashTransfer.Instance.BringToFront();
            }
            else
            {
                CashTransfer.Instance.BringToFront();
            }
            CashTransfer.Instance.refesh();
            state = "cashTransferCard";
        }

        // check card to cash transfer
        private void checkCardStateCashTransfer()
        {
            bool checkCardTo = carcBUL.checkCardNo(CashTransfer.Instance.getTextBoxCardNoTo());
            if (!checkCardTo)
            {
                if (!panelMain.Controls.Contains(Fail1.Instance))
                {
                    panelMain.Controls.Add(Fail1.Instance);
                    Fail1.Instance.Dock = DockStyle.Fill;
                    Fail1.Instance.BringToFront();
                }
                else
                {
                    Fail1.Instance.BringToFront();
                }
                Fail1.Instance.showErrorCard();
                state = "fail";
            }
            else
            {
                CashTransfer.Instance.hideCardShowMoney();
                state = "cashTransferMoney";
            }
        }

        // excute cash transfer
        private void processCashTransfer()
        {
            if (CashTransfer.Instance.getTextBoxMoneyTransfer().Equals(""))
            {
                return;
            }
            bool checkMoney = accountBUL.compareBalance(Convert.ToInt32(CashTransfer.Instance.getTextBoxMoneyTransfer()), lbCardNo.Text);

            if (!checkMoney)
            {
                if (!panelMain.Controls.Contains(Fail1.Instance))
                {
                    panelMain.Controls.Add(Fail1.Instance);
                    Fail1.Instance.Dock = DockStyle.Fill;
                    Fail1.Instance.BringToFront();
                }
                else
                {
                    Fail1.Instance.BringToFront();
                }
                Fail1.Instance.showErrorMoney();
                state = "fail";
            }
            else
            {
                bool checkSuccess = accountBUL.updateBalance(Convert.ToInt32(CashTransfer.Instance.getTextBoxMoneyTransfer())
                    , lbCardNo.Text, CashTransfer.Instance.getTextBoxCardNoTo());
                if (!checkSuccess)
                {
                    if (!panelMain.Controls.Contains(Fail1.Instance))
                    {
                        panelMain.Controls.Add(Fail1.Instance);
                        Fail1.Instance.Dock = DockStyle.Fill;
                        Fail1.Instance.BringToFront();
                    }
                    else
                    {
                        Fail1.Instance.BringToFront();
                    }
                    state = "fail";
                }
                else
                {
                    if (!panelMain.Controls.Contains(Success1.Instance))
                    {
                        panelMain.Controls.Add(Success1.Instance);
                        Success1.Instance.Dock = DockStyle.Fill;
                        Success1.Instance.BringToFront();
                    }
                    else
                    {
                        Success1.Instance.BringToFront();
                    }
                    state = "success";
                    createLog("logtype02", Convert.ToInt32(CashTransfer.Instance.getTextBoxMoneyTransfer()), CashTransfer.Instance.getTextBoxCardNoTo(), lbCardNo.Text, "atm01", "Thành công");
                }
            }
        }
        //
        // back to state list service from state cash transfer
        private void exitCashTransferCard()
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
        }

        // back to state list service from state cash transfer
        private void exitCashTransferMoney()
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
        }

        // back to state list service from state cash transfer success
        private void exitSuccessCashTransfer()
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
        }

        // back to state list service from state cash transfer fail
        private void exitFailCashTransfer()
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
        }
        // press ENTER in state cash transfer card
        private void pressEnterCashTransferCard()
        {
            bool checkCardTo = carcBUL.checkCardNo(CashTransfer.Instance.getTextBoxCardNoTo());
            if (!checkCardTo)
            {
                if (!panelMain.Controls.Contains(Fail1.Instance))
                {
                    panelMain.Controls.Add(Fail1.Instance);
                    Fail1.Instance.Dock = DockStyle.Fill;
                    Fail1.Instance.BringToFront();
                }
                else
                {
                    Fail1.Instance.BringToFront();
                }
                Fail1.Instance.showErrorCard();
                state = "fail";
            }
            else
            {
                CashTransfer.Instance.hideCardShowMoney();
                state = "cashTransferMoney";
            }
        }

        // press ENTER in state cash transfer money
        private void pressEnterCashTransferMoney()
        {
            if (CashTransfer.Instance.getTextBoxMoneyTransfer().Equals(""))
            {
                return;
            }
            bool checkMoney = accountBUL.compareBalance(Convert.ToInt32(CashTransfer.Instance.getTextBoxMoneyTransfer()), lbCardNo.Text);

            if (!checkMoney)
            {
                if (!panelMain.Controls.Contains(Fail1.Instance))
                {
                    panelMain.Controls.Add(Fail1.Instance);
                    Fail1.Instance.Dock = DockStyle.Fill;
                    Fail1.Instance.BringToFront();
                }
                else
                {
                    Fail1.Instance.BringToFront();
                }
                Fail1.Instance.showErrorMoney();
                state = "fail";
            }
            else
            {
                bool checkSuccess = accountBUL.updateBalance(Convert.ToInt32(CashTransfer.Instance.getTextBoxMoneyTransfer())
                    , lbCardNo.Text, CashTransfer.Instance.getTextBoxCardNoTo());
                if (!checkSuccess)
                {
                    if (!panelMain.Controls.Contains(Fail1.Instance))
                    {
                        panelMain.Controls.Add(Fail1.Instance);
                        Fail1.Instance.Dock = DockStyle.Fill;
                        Fail1.Instance.BringToFront();
                    }
                    else
                    {
                        Fail1.Instance.BringToFront();
                    }
                    state = "fail";
                }
                else
                {
                    if (!panelMain.Controls.Contains(Success1.Instance))
                    {
                        panelMain.Controls.Add(Success1.Instance);
                        Success1.Instance.Dock = DockStyle.Fill;
                        Success1.Instance.BringToFront();
                    }
                    else
                    {
                        Success1.Instance.BringToFront();
                    }
                    state = "success";
                    createLog("logtype02", Convert.ToInt32(CashTransfer.Instance.getTextBoxMoneyTransfer())
                        , CashTransfer.Instance.getTextBoxCardNoTo(), lbCardNo.Text, "atm01", "Thành công");
                }
            }
        }
        //


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

        private void formMain_Load(object sender, EventArgs e)
        {

        }
        // Nguyen Van Nghia
        private void openReceiveBill()
        {
            if (!panelMain.Controls.Contains(ReceiveBill.Instance))
            {
                panelMain.Controls.Add(ReceiveBill.Instance);
                ReceiveBill.Instance.Dock = DockStyle.Fill;
                ReceiveBill.Instance.BringToFront();
            }
            else
            {
                ReceiveBill.Instance.BringToFront();
            }
            state = "receivebill";
        }
        private void openSuccess()
        {
            if (!panelMain.Controls.Contains(Success.Instance))
            {
                panelMain.Controls.Add(Success.Instance);
                Success.Instance.Dock = DockStyle.Fill;
                Success.Instance.BringToFront();
            }
            else
            {
                Success.Instance.BringToFront();
            }
            state = "success2";
        }
        private void Endd()
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
        }

        System.Windows.Forms.Timer Countdown_Timer;
        private void openEnd()
        {
            Countdown_Timer = new System.Windows.Forms.Timer();
            Countdown_Timer.Interval = 10000;
            if (!panelMain.Controls.Contains(End.Instance))
            {
                panelMain.Controls.Add(End.Instance);
                End.Instance.Dock = DockStyle.Fill;
                End.Instance.BringToFront();
            }
            else
            {
                End.Instance.BringToFront();   
            }
            Countdown_Timer.Start();
            Endd();
            state = "end";
            
            
        }
        // back to state list service from state widthdraw
        private void exitWidthdraw()
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
            state = "listMenu";
        }

        // press ENTER in state custom widthdraw
        private void pressEnterCustomWidthdraw()
        {
            bool check = stockBUL.updateQuantity(Convert.ToInt32(CustomWidthdraw.Instance.getTextBoxCustom()));
            bool checkMoney = accountBUL.compareBalance(Convert.ToInt32(CustomWidthdraw.Instance.getTextBoxCustom()), lbCardNo.Text);
            if (check && checkMoney)
            {
                if (!panelMain.Controls.Contains(Success.Instance))
                {
                    panelMain.Controls.Add(Success.Instance);
                    Success.Instance.Dock = DockStyle.Fill;
                    Success.Instance.BringToFront();
                }
                else
                {
                    Success.Instance.BringToFront();
                }
                state = "success";
                openReceiveBill();
                createLog("logtype01", Convert.ToInt32(CustomWidthdraw.Instance.getTextBoxCustom()), "", lbCardNo.Text, "atm01", "Rút tiền thành công");
                accountBUL.updateBalance(Convert.ToInt32(CustomWidthdraw.Instance.getTextBoxCustom()), lbCardNo.Text);
            }
            else
            {
                if (!panelMain.Controls.Contains(Fail.Instance))
                {
                    panelMain.Controls.Add(Fail.Instance);
                    Fail.Instance.Dock = DockStyle.Fill;
                    Fail.Instance.BringToFront();
                }
                else
                {
                    Fail.Instance.BringToFront();
                }
                Fail.Instance.showErrorWidth();
                state = "fail";
            }
        }
        // select widthdraw 500.000
        private void widthdrawSelectOne()
        {
            bool check = stockBUL.updateQuantity(500000);
            
            bool checkMoney = accountBUL.compareBalance(500000, lbCardNo.Text);
            if (check && checkMoney )
            {
                if (!panelMain.Controls.Contains(Success.Instance))
                {
                    panelMain.Controls.Add(Success.Instance);
                    Success.Instance.Dock = DockStyle.Fill;
                    Success.Instance.BringToFront();
                }
                else
                {
                    Success.Instance.BringToFront();
                }
                state = "success";
                openReceiveBill();
                createLog("logtype01", 500000, "", lbCardNo.Text, "atm01", "Rút tiền thành công");
                accountBUL.updateBalance(500000, lbCardNo.Text);
            }
            else
            {
                if (!panelMain.Controls.Contains(Fail.Instance))
                {
                    panelMain.Controls.Add(Fail.Instance);
                    Fail.Instance.Dock = DockStyle.Fill;
                    Fail.Instance.BringToFront();
                }
                else
                {
                    Fail.Instance.BringToFront();
                }
                Fail.Instance.showErrorMoney();
                state = "fail";
            }
        }

        // switch from control list service to control widthdraw
        private void openStateWidthdraw()
        {
            if (!panelMain.Controls.Contains(Widthdraw.Instance))
            {
                panelMain.Controls.Add(Widthdraw.Instance);
                Widthdraw.Instance.Dock = DockStyle.Fill;
                Widthdraw.Instance.BringToFront();
            }
            else
            {
                Widthdraw.Instance.BringToFront();
            }
            state = "widthdraw";
        }
        private void openStateA() { }
        // select widthdraw 1.000.000
        private void widthdrawSelectTwo()
        {
            bool check = stockBUL.updateQuantity(1000000);
            bool checkMoney = accountBUL.compareBalance(1000000, lbCardNo.Text);
            
            if (check && checkMoney)
            {
                if (!panelMain.Controls.Contains(Success.Instance))
                {
                    panelMain.Controls.Add(Success.Instance);
                    Success.Instance.Dock = DockStyle.Fill;
                    Success.Instance.BringToFront();
                }
                else
                {
                    Success.Instance.BringToFront();
                }
                state = "success";
                openReceiveBill();
                createLog("logtype01", 1000000, "", lbCardNo.Text, "atm01", "Rút tiền thành công");
                accountBUL.updateBalance(1000000, lbCardNo.Text);
            }
            else
            {
                if (!panelMain.Controls.Contains(Fail.Instance))
                {
                    panelMain.Controls.Add(Fail.Instance);
                    Fail.Instance.Dock = DockStyle.Fill;
                    Fail.Instance.BringToFront();
                }
                else
                {
                    Fail.Instance.BringToFront();

                }
                Fail.Instance.showErrorMoney();
                state = "fail";
            }
        }

        // select widthdraw 2.000.000
        private void widthdrawSelectThree()
        {
            bool check = stockBUL.updateQuantity(2000000);
            bool checkMoney = accountBUL.compareBalance(2000000, lbCardNo.Text);
            if (check && checkMoney)
            {
                if (!panelMain.Controls.Contains(Success.Instance))
                {
                    panelMain.Controls.Add(Success.Instance);
                    Success.Instance.Dock = DockStyle.Fill;
                    Success.Instance.BringToFront();
                }
                else
                {
                    Success.Instance.BringToFront();
                }
                state = "success";
                openReceiveBill();
                createLog("logtype01", 2000000, "", lbCardNo.Text, "atm01", "Rút tiền thành công");
                accountBUL.updateBalance(2000000, lbCardNo.Text);
            }
            else
            {
                if (!panelMain.Controls.Contains(Fail.Instance))
                {
                    panelMain.Controls.Add(Fail.Instance);
                    Fail.Instance.Dock = DockStyle.Fill;
                    Fail.Instance.BringToFront();
                }
                else
                {
                    Fail.Instance.BringToFront();
                }
                Fail.Instance.showErrorMoney();
                state = "fail";
            }
        }
        
        // select widthdraw 5.000.000
        private void widthdrawSelectFour()
        {
            bool check = stockBUL.updateQuantity(5000000);
            bool checkMoney = accountBUL.compareBalance(5000000, lbCardNo.Text);
            if (check && checkMoney)
            {
                if (!panelMain.Controls.Contains(Success.Instance))
                {
                    panelMain.Controls.Add(Success.Instance);
                    Success.Instance.Dock = DockStyle.Fill;
                    Success.Instance.BringToFront();
                }
                else
                {
                    Success.Instance.BringToFront();
                }
                state = "success";
                openReceiveBill();
                createLog("logtype01", 5000000, "", lbCardNo.Text, "atm01", "Rút tiền thành công");
                accountBUL.updateBalance(5000000, lbCardNo.Text);
            }
            else
            {
                if (!panelMain.Controls.Contains(Fail.Instance))
                {
                    panelMain.Controls.Add(Fail.Instance);
                    Fail.Instance.Dock = DockStyle.Fill;
                    Fail.Instance.BringToFront();
                }
                else
                {
                    Fail.Instance.BringToFront();
                }
                Fail.Instance.showErrorMoney();
                state = "fail";
            }
        }
        // switch from control widthdraw to control custom widthdraw
        private void openStateCustomWidthdraw()
        {
            if (!panelMain.Controls.Contains(CustomWidthdraw.Instance))
            {
                panelMain.Controls.Add(CustomWidthdraw.Instance);
                CustomWidthdraw.Instance.Dock = DockStyle.Fill;
                CustomWidthdraw.Instance.BringToFront();
            }
            else
            {
                CustomWidthdraw.Instance.BringToFront();
            }
            state = "customWidthdraw";
            CustomWidthdraw.Instance.clearTextBoxCustom();
        }
        
        private void openFail()
        {
            if (!panelMain.Controls.Contains(Fail.Instance))
            {
                panelMain.Controls.Add(Fail.Instance);
                Fail.Instance.Dock = DockStyle.Fill;
                Fail.Instance.BringToFront();
            }
            else
            {
                Fail.Instance.BringToFront();
            }
            state = "failmoney";
        }
        private void openStateCheckBalance()
        {
            if (!panelMain.Controls.Contains(CheckBalance.Instance))
            {
                panelMain.Controls.Add(CheckBalance.Instance);
                CheckBalance.Instance.Dock = DockStyle.Fill;
                CheckBalance.Instance.BringToFront();
            }
            else
            {
                CheckBalance.Instance.BringToFront();
            }
            state = "checkBalance";
            
            
            CheckBalance.Instance.setLbBalance(accountBUL.getBalance(lbCardNo.Text));
            createLog("logtype03", accountBUL.getBalanceInt(lbCardNo.Text), "", lbCardNo.Text, "atm01", "Kiểm tra số dư");
        }
    }
}

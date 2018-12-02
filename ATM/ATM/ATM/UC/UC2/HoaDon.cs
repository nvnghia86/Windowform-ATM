using BUL;
using DTO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ATM.UC.UC2
{
    public partial class HoaDon : Form
    {
        string accID = "";
        string cardNo = "";
        public HoaDon(string accID, string cardNo)
        {
            InitializeComponent();
            this.accID = accID;
            this.cardNo = cardNo;
        }

        string rtb = "";
        LogDTO logDTO = new LogDTO();
        LogBUL logBUL = new LogBUL();
        AccountDTO accountDTO = new AccountDTO();
        AccountBUL accountBUL = new AccountBUL();
        

        private void HoaDon_Load_1(object sender, EventArgs e)
        {
            
            string balance = "";
           
            foreach (LogDTO alog in logBUL.LayHoaDon(cardNo))
            {
                lbNgayGD.Text = DateTime.Now.ToString("HH:mm   dd/mm/yyyy ");
                lbATMID.Text = alog.atmID;
                lbSoThe.Text = alog.cardNo;
                lbSoGD.Text = alog.logID;
                lbSoTien.Text = alog.amount.ToString();
                lbSoTK.Text = alog.cardNo;
                
            }
            lbPhi.Text = "1100";
            rtb += lbNgayGD;
            rtb += lbATMID;
            rtb += lbSoThe;
            rtb += lbSoGD;
            rtb += lbSoTien;
            rtb += lbSoTK;
            rtb += lbPhi;
            foreach (AccountDTO aAcc in accountBUL.DocBangAccountID(accID))
            {
                balance = aAcc.balance.ToString();
                lbSoDuSD.Text = balance;
            }
            
            rtb += lbSoDuSD;
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF file|* .pdf", ValidateNames = true })
            {
                iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.A5.Rotate());
                string path = Environment.CurrentDirectory;
                PdfWriter.GetInstance(doc, new FileStream(path + "/HoaDon.pdf", FileMode.OpenOrCreate));
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}

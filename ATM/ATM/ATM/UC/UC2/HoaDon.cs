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
            string date = "";
            string balance = "";
            string atmID = "";
            string logID = "";
            string amount = "";
            string cardno = "";
            string sogd = "";
            foreach (LogDTO alog in logBUL.LayHoaDon(cardNo))
            {
                date = DateTime.Now.ToString("HH:mm  dd/MM/yyyy ");
                atmID = alog.atmID;
                cardno = alog.cardNo;
                logID = alog.logID;
                amount = alog.amount.ToString();
                sogd = alog.logTypeID;
            }
            foreach (AccountDTO aAcc in accountBUL.DocBangAccountID(accID))
            {
                balance = aAcc.balance.ToString();  
            }
            rtb += "\n\t NGAY G/D:    " + date + "\n\n";
            rtb += "\t ATM ID:    " + atmID + "\n\n";
            rtb += "\t SO THE:    " + cardno + "\n\n";
            rtb += "\t SO G/D:    " + sogd + "\n\n";
            rtb += "\t\t GIAO DICH RUT TIEN" + "\n\n";
            rtb += "\t SO TIEN:    " + amount + "\n\n"; 
            rtb += "\t SO TAI KHOAN:   " + cardno + "\n\n";
            rtb += "\t SO DU SU DUNG:   " + balance + "\n\n";
            rtb += "\t PHI + VAT:  1100đ";
            richTextBox1.Text = rtb;
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF file|* .pdf", ValidateNames = true })
            {
                iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.A5.Rotate());
                string path = Environment.CurrentDirectory;
                PdfWriter.GetInstance(doc, new FileStream(path + "/HoaDon.pdf", FileMode.OpenOrCreate));
                doc.Open();
                doc.Add(new iTextSharp.text.Paragraph(richTextBox1.Text));
                doc.Close();
            }
        }
    }
}

using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DAL
{
    public class LogDAL
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnString"].ToString());
        public bool createLog(string logId, string logDate, int amount, string details, string cardNoTo, string logType, string atmID, string cardNo) {
            try
            {
                string query = "insert into Log values(@logId, @date,@amount,@details,@cardTo,@logType,@atmID,@cardNo)";
                ConnectDatabase.open();
                SqlCommand cmd1 = new SqlCommand(query, ConnectDatabase.connect);
                cmd1.Parameters.AddWithValue("logId", logId);
                cmd1.Parameters.AddWithValue("date", logDate);
                cmd1.Parameters.AddWithValue("amount", amount);
                cmd1.Parameters.AddWithValue("details", details);
                cmd1.Parameters.AddWithValue("cardTo", cardNoTo);
                cmd1.Parameters.AddWithValue("logType", logType);
                cmd1.Parameters.AddWithValue("atmID", atmID);
                cmd1.Parameters.AddWithValue("cardNo", cardNo);
                cmd1.ExecuteNonQuery();
                ConnectDatabase.close();
                return true;
            }
            catch {
                if (ConnectDatabase.CHECK_OPEN)
                {
                    ConnectDatabase.close();
                }
                return false;
            }
        }

        public List<LogDTO> getAllLog(string cardNo) {
            try {
                List<LogDTO> arrLog = new List<LogDTO>();
                string query = "select * from Log where CardNo = @cardNo";
                ConnectDatabase.open();
                SqlCommand cmd = new SqlCommand(query, ConnectDatabase.connect);
                cmd.Parameters.AddWithValue("cardNo", cardNo);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    LogDTO log = new LogDTO(
                        dr["LogID"].ToString(),
                        DateTime.Parse(dr["LogDate"].ToString()),
                        Convert.ToInt32(dr["Amount"]),
                        dr["Details"].ToString(),
                        dr["CardNoTo"].ToString(),
                        dr["LogTypeID"].ToString(),
                        dr["ATMID"].ToString(),
                        dr["CardNo"].ToString());
                    arrLog.Add(log);
                }
                ConnectDatabase.close();
                return arrLog;
            }
            catch {
                if (ConnectDatabase.CHECK_OPEN)
                {
                    ConnectDatabase.close();
                }
                return null;
            }
            
        }
        
        public int tongTien(int money, string cardNo)
        {
            try
            { 
            int tien = -1;
            string Date = DateTime.Now.ToString("yyyy/MM/dd");
            string query = "select sum(Amount) As Amount from Log where LogDate like " + Date + " and CardNo = @cardNo and LogTypeID = 'logtype01'";
            ConnectDatabase.open();
            SqlCommand cmd = new SqlCommand(query, ConnectDatabase.connect);
            cmd.Parameters.AddWithValue("cardNo", cardNo);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                tien = Convert.ToInt32(dr["Amount"]);
            }
            ConnectDatabase.close();
            return tien;
            }
            catch
            {
                if (ConnectDatabase.CHECK_OPEN)
                {
                    ConnectDatabase.close();
                }
                return -1;
            }
        }
        public int hanMuc(int money,string cardNo)
        {
            try
            { 
                int hanmuc = -1;
                string sql = "select Value from Account as ac left join WithdrawLimit wd on ac.WDID = wd.WDID left join Card as c on c.AccountID = ac.AccountID where CardNo = @cardNo group by ac.AccountID, c.AccountID, wd.Value";
                ConnectDatabase.open();
                SqlCommand cmd = new SqlCommand(sql, ConnectDatabase.connect);
                cmd.Parameters.AddWithValue("cardNo", cardNo);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    hanmuc = money - money + Convert.ToInt32(dr["Value"]);
                }
            return hanmuc;
            }
            catch
            {
                if (ConnectDatabase.CHECK_OPEN)
                {
                    ConnectDatabase.close();
                }
                return -1;
            }
        }
        public List<LogDTO> LayHoaDon(string cardNo)
        {
            con.Open();
            List<LogDTO> arrLog = new List<LogDTO>();
            string sql = "select TOP(1) * from Log where CardNo = @cardNo order by LogID DESC";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("cardNo", cardNo);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                LogDTO log = new LogDTO(
                        dr["LogID"].ToString(),
                        DateTime.Parse(dr["LogDate"].ToString()),
                        Convert.ToInt32(dr["Amount"]),
                        dr["Details"].ToString(),
                        dr["CardNoTo"].ToString(),
                        dr["LogTypeID"].ToString(),
                        dr["ATMID"].ToString(),
                        dr["CardNo"].ToString());
                arrLog.Add(log);
            }
            con.Close();
            return arrLog;

        }
    }
}

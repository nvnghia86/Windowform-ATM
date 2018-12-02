using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Configuration;

namespace DAL
{
    public class AccountDAL
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnString"].ToString());

               public int getBalance(string cardNo) {
            try {
                int balance = -1;
                string query = "select Account.Balance from Account inner join Card on Account.AccountID = Card.AccountID where CardNo = @cardNo";
                ConnectDatabase.open();
                SqlCommand cmd = new SqlCommand(query, ConnectDatabase.connect);
                cmd.Parameters.AddWithValue("cardNo",cardNo);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    balance = Convert.ToInt32(dr["Balance"]);
                }
                ConnectDatabase.close();
                return balance;
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
        

        public bool updateBalance(int money, string cardNo, string cardNoTo) {
            try {

                int balance = -1;
                string query = "select Account.Balance from Account inner join Card on Account.AccountID = Card.AccountID where CardNo = @cardNo";
                ConnectDatabase.open();
                SqlCommand cmd = new SqlCommand(query, ConnectDatabase.connect);
                cmd.Parameters.AddWithValue("cardNo", cardNo);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    balance = Convert.ToInt32(dr["Balance"]);
                }
                ConnectDatabase.close();
                int newBalance = balance - money;

                string queryUpdate = "update Account set Account.Balance = @newBalance from Account inner join Card on Account.AccountID = Card.AccountID where Card.CardNo = @cardNo ";
                ConnectDatabase.open();
                SqlCommand cmd1 = new SqlCommand(queryUpdate, ConnectDatabase.connect);
                cmd1.Parameters.AddWithValue("newBalance", newBalance);
                cmd1.Parameters.AddWithValue("cardNo", cardNo);
                cmd1.ExecuteNonQuery();

                ConnectDatabase.close();

                updateBalanceTo(money,cardNoTo);

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

        public bool updateBalanceTo(int money, string cardNo)
        {
            try
            {

                int balance = -1;
                string query = "select Account.Balance from Account inner join Card on Account.AccountID = Card.AccountID where CardNo = @cardNo";
                ConnectDatabase.open();
                SqlCommand cmd = new SqlCommand(query, ConnectDatabase.connect);
                cmd.Parameters.AddWithValue("cardNo", cardNo);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    balance = Convert.ToInt32(dr["Balance"]);
                }
                ConnectDatabase.close();
                int newBalance = balance + money;

                string queryUpdate = "update Account set Account.Balance = @newBalance from Account inner join Card on Account.AccountID = Card.AccountID where Card.CardNo = @cardNo ";
                ConnectDatabase.open();
                SqlCommand cmd1 = new SqlCommand(queryUpdate, ConnectDatabase.connect);
                cmd1.Parameters.AddWithValue("newBalance", newBalance);
                cmd1.Parameters.AddWithValue("cardNo", cardNo);
                cmd1.ExecuteNonQuery();

                ConnectDatabase.close();


                return true;
            }
            catch
            {
                if (ConnectDatabase.CHECK_OPEN)
                {
                    ConnectDatabase.close();
                }
                return false;
            }
        }

        public bool compareBalance(int money, string cardNo) {
            try
            {
                int balance = -1;
                string query = "select sum(ac.Balance+ov.Value) as Balance from Account as ac left join OverDraft ov on ac.ODID = ov.ODID left join Card as c on c.AccountID = ac.AccountID where CardNo = @cardNo group by ac.AccountID, c.AccountID, ov.ODID";
                ConnectDatabase.open();
                SqlCommand cmd = new SqlCommand(query, ConnectDatabase.connect);
                cmd.Parameters.AddWithValue("cardNo", cardNo);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    balance = Convert.ToInt32(dr["Balance"]);
                }
                ConnectDatabase.close();
                if (money <= balance)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                if (ConnectDatabase.CHECK_OPEN)
                {
                    ConnectDatabase.close();
                }
                return false;
            }
        }

        public bool updateBalance(int money, string cardNo)
        {
            try
            {
                int balance = -1;
                string query = "select Account.Balance from Account inner join Card on Account.AccountID = Card.AccountID where CardNo = @cardNo";
                ConnectDatabase.open();
                SqlCommand cmd = new SqlCommand(query, ConnectDatabase.connect);
                cmd.Parameters.AddWithValue("cardNo", cardNo);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    balance = Convert.ToInt32(dr["Balance"]);
                }
                ConnectDatabase.close();
                int newBalance = balance - money;

                string queryUpdate = "update Account set Account.Balance = @newBalance from Account inner join Card on Account.AccountID = Card.AccountID where Card.CardNo = @cardNo ";
                ConnectDatabase.open();
                SqlCommand cmd1 = new SqlCommand(queryUpdate, ConnectDatabase.connect);
                cmd1.Parameters.AddWithValue("newBalance", newBalance);
                cmd1.Parameters.AddWithValue("cardNo", cardNo);
                cmd1.ExecuteNonQuery();

                ConnectDatabase.close();

                return true;
            }
            catch
            {
                if (ConnectDatabase.CHECK_OPEN)
                {
                    ConnectDatabase.close();
                }
                return false;
            }
        }
        public List<AccountDTO> DocBangAccountID(string accID)
        {
            con.Open();
            List<AccountDTO> dsAcc = new List<AccountDTO>();
            string sql = " select * from Account where AccountID = @accID ";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("accID", accID);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                AccountDTO aAcc = new AccountDTO(
                    dr["AccountID"].ToString(),
                    int.Parse(dr["Balance"].ToString()),
                    dr["AccountNo"].ToString(),
                    dr["ODID"].ToString(),
                    dr["WDID"].ToString(),
                    dr["CustID"].ToString()
                    );
                dsAcc.Add(aAcc);
            }
            con.Close();
            return dsAcc;
        }

    }
}

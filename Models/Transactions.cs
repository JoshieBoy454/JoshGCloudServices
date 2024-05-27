using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace JoshGCloudServices.Models
{
    public class Transactions : Controller
    {
        public static string con_string = "Server=tcp:joshservercloud.database.windows.net,1433;Initial Catalog=JoshGDataBase;Persist Security Info=False;User ID=AdminLogin040504;Password=CloudLogin040504!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        public static SqlConnection con = new SqlConnection(con_string);

        // Developed with assistance from ChatGPT
        // Link:https://chatgpt.com/share/722629d5-520c-498f-8cdb-a55543990d16

        public int TransactionID { get; set; }
        public int ProductID { get; set; }
        public int UserID { get; set; }
        //----------------------------------------------------------------------------------------->
        public int InsertTransaction(Transactions t)
        {
            try
            {
                string sql = "INSERT INTO Transctions (ProductID, UserID) VALUES (@ProductID, @UserID)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@ProductID", t.ProductID);
                cmd.Parameters.AddWithValue("@UserID", t.UserID);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                return rowsAffected;
            }
            catch (Exception)
            {
                throw;
            }
        }
        //----------------------------------------------------------------------------------------->
        public static List<Transactions> GetAllTransactions()
        {
            List<Transactions> transactions = new List<Transactions>();

            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT * FROM Transactions";
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Transactions transaction = new Transactions();
                    transaction.TransactionID = Convert.ToInt32(rdr["TransactionID"]);
                    transaction.ProductID = Convert.ToInt32(rdr["ProductID"]);
                    transaction.UserID = Convert.ToInt32(rdr["UserID"]);

                    transactions.Add(transaction);
                }
            }

            return transactions;
        }
        //----------------------------------------------------------------------------------------->
    }
}

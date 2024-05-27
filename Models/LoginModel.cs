using Microsoft.AspNetCore.Mvc;
using System;
using System.Data.SqlClient;

namespace JoshGCloudServices.Models
{
    public class LoginModel
    {
        public static string con_string = "Server=tcp:joshservercloud.database.windows.net,1433;Initial Catalog=JoshGDataBase;Persist Security Info=False;User ID=AdminLogin040504;Password=CloudLogin040504!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

        public int SelectUser(string email, string name)
        {
            int userId = -1;
            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT UserID FROM Users WHERE UserEmail = @Email AND UserName = @Name";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Name", name);
                try
                {
                    con.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        userId = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception
                    Console.WriteLine($"Error: {ex.Message}");
                    throw; // Rethrow the exception to propagate it further
                }
            }
            return userId;
        }
    }
}

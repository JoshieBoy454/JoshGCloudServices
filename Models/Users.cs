using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace JoshGCloudServices.Models
{
    public class Users : Controller
    {
        public static string con_string = "Server=tcp:joshservercloud.database.windows.net,1433;Initial Catalog=JoshGDataBase;Persist Security Info=False;User ID=AdminLogin040504;Password=CloudLogin040504!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        public static SqlConnection con = new SqlConnection(con_string);
        public string? UserID { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        //----------------------------------------------------------------------------------------->
        public int insert_User(Users u)
        {
            try
            {
                string sql = "INSERT INTO Users (UserName, UserSurname, UserEmail, UserPassword) VALUES (@Name, @Surname, @Email, @Password)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Name", u.Name);
                cmd.Parameters.AddWithValue("@Surname", u.Surname);
                cmd.Parameters.AddWithValue("@Email", u.Email);
                cmd.Parameters.AddWithValue("@Password", u.Password);
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
        public static List<Users> GetAllUsers()
        {
            List<Users> users = new List<Users>();

            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT * FROM Users";
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Users user = new Users();
                    user.UserID = rdr["UserID"].ToString();
                    user.Name = rdr["UserName"].ToString();
                    user.Surname = rdr["UserSurname"].ToString();
                    user.Email = rdr["UserEmail"].ToString();
                    user.Password = rdr["UserPassword"].ToString();
                    users.Add(user);
                }
                con.Close();
            }
            return users;
        }
        //----------------------------------------------------------------------------------------->
    }
}

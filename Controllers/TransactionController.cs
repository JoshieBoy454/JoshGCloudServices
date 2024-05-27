using JoshGCloudServices.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace JoshGCloudServices.Controllers
{
    public class TransactionController : Controller
    {
        [HttpPost]
        public ActionResult PlaceOrder(int userID, int productID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Products.con_string))
                {
                    string sql = "INSERT INTO Transactions (UserID, ProductID) VALUES (@UserID, @ProductID)";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userID);
                        cmd.Parameters.AddWithValue("@ProductID", productID);

                        con.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();

                        con.Close();

                        if (rowsAffected > 0)
                        {
                            return RedirectToAction("MyWork", "Home");
                        }
                        else
                        {
                            return RedirectToAction("MyWork", "Home");
                        }
                    }
                }
            }
            catch (Exception)
            {
               
                return View("Error");
            }
        }
    }
}

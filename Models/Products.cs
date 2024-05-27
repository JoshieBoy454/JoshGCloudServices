using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace JoshGCloudServices.Models
{
    public class Products : Controller
    {
        public static string con_string = "Server=tcp:joshservercloud.database.windows.net,1433;Initial Catalog=JoshGDataBase;Persist Security Info=False;User ID=AdminLogin040504;Password=CloudLogin040504!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        public static SqlConnection con = new SqlConnection(con_string);

        public int? ProductID { get; set; }

        public string? Name { get; set; }

        public decimal Price { get; set; }

        public string? Category { get; set; }

        public bool? Availability { get; set; }
        //----------------------------------------------------------------------------------------->
        public int insert_product(Products p)
        {

            try
            {
                string sql = "INSERT INTO Products (ProductName, ProductPrice, ProductCategory, ProductAvailability) VALUES (@Name, @Price, @Category, @Availability)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Name", p.Name);
                cmd.Parameters.AddWithValue("@Price", p.Price);
                cmd.Parameters.AddWithValue("@Category", p.Category);
                cmd.Parameters.AddWithValue("@Availability", p.Availability);
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
        public static List<Products> GetAllProducts()
        {
            List<Products> products = new List<Products>();

            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT * FROM Products";
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Products product = new Products();
                    product.ProductID = Convert.ToInt32(rdr["productID"]);
                    product.Name = rdr["productName"].ToString();
                    product.Price = (decimal)rdr["productPrice"];
                    product.Category = rdr["productCategory"].ToString();
                    byte[] availabilityBytes = rdr["ProductAvailability"] as byte[];
                    if (availabilityBytes != null && availabilityBytes.Length > 0)
                    {
                        // Interpret the first byte as a boolean value (0 for false, 1 for true)
                        product.Availability = availabilityBytes[0] == 1;
                    }
                    else
                    {
                        // Handle the case when availability data is missing or invalid
                        product.Availability = null; // or any default value you prefer
                    }

                    products.Add(product);
                }
            }

            return products;
        }
        //----------------------------------------------------------------------------------------->
    }
}

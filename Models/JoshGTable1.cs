using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace JoshGCloudServices.Models
{
    public class JoshGTable1 : Controller
    {
        public static string con_string = "Server=tcp:joshservercloud.database.windows.net,1433;Initial Catalog=JoshGDataBase;Persist Security Info=False;User ID=AdminLogin040504;Password=CloudLogin040504!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        public static SqlConnection on = new SqlConnection(con_string);
        public IActionResult Index()
        {
            return View();
        }
    }
}

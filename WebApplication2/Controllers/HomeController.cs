using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string name, string surname)
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult AddPers(string FIO, int age, int pasport, int zag_pasport)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\VAS\Desktop\WebApplication2\WebApplication2\App_Data\Vasikhin.mdf;Integrated Security=True;Connect Timeout=30"))
            {

                SqlCommand com = new SqlCommand("INSERT INTO [Table] (FIO, age, pasport, zag_pasport )VALUES (@FIO, @age, @pasport, @zag_pasport)", con);
                com.Parameters.AddWithValue("FIO", FIO);
                com.Parameters.AddWithValue("age", age);
                com.Parameters.AddWithValue("pasport", pasport);
                com.Parameters.AddWithValue("zag_pasport", zag_pasport);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
            }
            return View();
        }

        [HttpPost]
        public ActionResult EditPers()
        {
            List<Table> pers_id = new List<Table>();

            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\VAS\Desktop\WebApplication2\WebApplication2\App_Data\Vasikhin.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                con.Open();
                SqlCommand com = new SqlCommand("Select * from [Table]", con);
                SqlDataReader r = com.ExecuteReader();
                while (r.Read())
                {
                    pers_id.Add(new Table()
                    {
                        id = Convert.ToInt32(r["id"]),
                    });
                }
                r.Close();
            }
            ViewBag.Pers = pers_id;
            return View();
        }

        [HttpPost]
        public ActionResult DeletePers()
        {
            List<Table> pers_id = new List<Table>();

            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\VAS\Desktop\WebApplication2\WebApplication2\App_Data\Vasikhin.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                con.Open();
                SqlCommand com = new SqlCommand("Select * from [Table]", con);
                SqlDataReader r = com.ExecuteReader();
                while (r.Read())
                {
                    pers_id.Add(new Table()
                    {
                        id = Convert.ToInt32(r["id"]),
                    });
                }
                r.Close();
            }
            ViewBag.Pers = pers_id;
            return View();
        }

        [HttpPost]
        public ActionResult SelectedEditPers(int id, string FIO, int age, int pasport, int zag_pasport)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\VAS\Desktop\WebApplication2\WebApplication2\App_Data\Vasikhin.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                SqlCommand com = new SqlCommand("UPDATE [Table] SET   [FIO]=@FIO, [age]=@age, [pasport]=@pasport, [zag_pasport]=@zag_pasport WHERE [id]=@id", con);
                com.Parameters.AddWithValue("FIO", FIO);
                com.Parameters.AddWithValue("age", age);
                com.Parameters.AddWithValue("pasport", pasport);
                com.Parameters.AddWithValue("zag_pasport", zag_pasport);
                com.Parameters.AddWithValue("id", id);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
            }
            return View();
        }

        [HttpPost]
        public ActionResult DeletedPers(int id)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\VAS\Desktop\WebApplication2\WebApplication2\App_Data\Vasikhin.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                SqlCommand com = new SqlCommand("DELETE FROM [Table] WHERE [id]=@id", con);
                com.Parameters.AddWithValue("id", id);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
            }
            return View();
        }

   

        [HttpPost]
        public ActionResult PersView()
        {
            List<Table> ps = new List<Table>();
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\VAS\Desktop\WebApplication2\WebApplication2\App_Data\Vasikhin.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                con.Open();
                SqlCommand com = new SqlCommand("Select * from [Table]", con);
                SqlDataReader r = com.ExecuteReader();
                while (r.Read())
                {
                    ps.Add(new Table()
                    {
                        id = Convert.ToInt32(r["Id"]),
                        FIO = r["FIO"].ToString(),
                        age = Convert.ToInt32(r["age"]),
                        pasport = Convert.ToInt32(r["pasport"]),
                        zag_pasport = Convert.ToInt32(r["zag_pasport"]),

                    });
                }
                r.Close();

                ViewBag.Pers = ps;
                return View();
            }
        }

    }
}
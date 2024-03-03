using PoliziaMunicipale.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace PoliziaMunicipale.Controllers
{
    public class ViolazioniController : Controller
    {
        // GET: Violazioni
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Violazioni()
        {
            List<Violazioni> violazione = new List<Violazioni>();
            string connectionString = ConfigurationManager.ConnectionStrings["Polizia"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM VIOLAZIONI";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Violazioni d = new Violazioni();
                        d.IDviolazione = Convert.ToInt16(reader["IDviolazione"]);
                        d.Descrizione_Verbale = reader["Descrizione_Verbale"].ToString();
                        //d.IDverbale = Convert.ToInt16(reader["IDverbale"]);

                        violazione.Add(d);
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("Errore: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
                return View(violazione);
            }
        }
    }
}
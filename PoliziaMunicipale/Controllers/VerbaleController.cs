using PoliziaMunicipale.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace PoliziaMunicipale.Controllers
{
    public class VerbaleController : Controller
    {
        // GET: Verbale
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Verbale()
        {
            ViewBag.ListaAgenti = GetAgente();
            ViewBag.ListaViolazioni = GetIDviolazione();
            return View();
        }

        [HttpPost]
        public ActionResult Verbale(Verbale verbale)
        {
            if (ModelState.IsValid)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["Polizia"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO VERBALE (DataViolazione, IndirizzoViolazione, Nominativo_Agente, DataVerbale, Importo, DecurtamentoPunti, IDviolazione, IDanagrafica) " +
                                   "VALUES (@DataViolazione, @IndirizzoViolazione, @Nominativo_Agente, @DataVerbale, @Importo, @DecurtamentoPunti, @IDviolazione, @IDanagrafica)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        PopulateCommandParameters(command, verbale);
                        command.ExecuteNonQuery();
                    }
                }

                return RedirectToAction("Index", "Home");
            }

            ViewBag.ListaAgenti = GetAgente();
            return View(verbale);
        }
    

        private void PopulateCommandParameters(SqlCommand command, Verbale verbale)
        {
            command.Parameters.AddWithValue("@DataViolazione", verbale.DataViolazione);
            command.Parameters.AddWithValue("@IndirizzoViolazione", verbale.IndirizzoViolazione);
            command.Parameters.AddWithValue("@Nominativo_Agente", verbale.Nominativo_Agente);
            command.Parameters.AddWithValue("@DataVerbale", verbale.DataVerbale);
            command.Parameters.AddWithValue("@Importo", verbale.Importo);
            command.Parameters.AddWithValue("@DecurtamentoPunti", verbale.DecurtamentoPunti);
            command.Parameters.AddWithValue("@IDviolazione", verbale.IDviolazione);
            command.Parameters.AddWithValue("@IDanagrafica", verbale.IDanagrafica);
        }

        public List<string> GetAgente()
        {
            List<string> agenti = new List<string>();
            string connectionString = ConfigurationManager.ConnectionStrings["Polizia"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Nominativo_Agente FROM VERBALE";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            agenti.Add(reader.GetString(0));
                        }
                    }
                }
            }
            return agenti;
        }

        public List<string> GetIDviolazione()
        {
            List<string> IDviolazioni = new List<string>();
            string connectionString = ConfigurationManager.ConnectionStrings["Polizia"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT IDviolazione FROM VERBALE";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        { 
                            //Così se ci sono ID duplicati non vengono aggiunti
                            string id = reader.GetInt32(0).ToString();
                            if (!IDviolazioni.Contains(id))
                            {
                                IDviolazioni.Add(id);
                            }
                        }
                    }
                }
            }
            return IDviolazioni;
        }
    }
}

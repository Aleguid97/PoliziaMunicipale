using PoliziaMunicipale.Models;
using System;
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
            return View();
        }


        [HttpPost]
        public ActionResult Verbale(Verbale verbale)
        {


            string connectionString = ConfigurationManager.ConnectionStrings["Polizia"].ConnectionString.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string query = "INSERT INTO VERBALE (DataViolazione, IndirizzoViolazione, Nominativo_Agente, DataVerbale, Importo, DecurtamentoPunti, IDviolazione, IDanagrafica) VALUES (@DataViolazione, @IndirizzoViolazione, @Nominativo_Agente, @DataVerbale, @Importo, @DecurtamentoPunti, @IDviolazione, @IDanagrafica)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    connection.Open();
                    command.Parameters.AddWithValue("@DataViolazione", verbale.DataViolazione);
                    command.Parameters.AddWithValue("@IndirizzoViolazione", verbale.IndirizzoViolazione);
                    command.Parameters.AddWithValue("@Nominativo_Agente", verbale.Nominativo_Agente);
                    command.Parameters.AddWithValue("@DataVerbale", verbale.DataVerbale);
                    command.Parameters.AddWithValue("@Importo", verbale.Importo);
                    command.Parameters.AddWithValue("@DecurtamentoPunti", verbale.DecurtamentoPunti);
                    command.Parameters.AddWithValue("@IDviolazione", verbale.IDviolazione);
                    command.Parameters.AddWithValue("@IDanagrafica", verbale.IDanagrafica);
                    command.ExecuteNonQuery();
                }
            }

            return View(verbale);

        }
    }
}

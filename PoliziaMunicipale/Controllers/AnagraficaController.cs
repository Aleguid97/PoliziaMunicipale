using PoliziaMunicipale.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PoliziaMunicipale.Controllers
{
    public class AnagraficaController : Controller
    {
        // GET: Anagrafica
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Anagrafica()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Anagrafica(Anagrafica anagrafica)
        {



            string connectionString = ConfigurationManager.ConnectionStrings["Polizia"].ConnectionString.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string query = "INSERT INTO ANAGRAFICA (Cognome, Nome, Indirizzo, Citta, CAP, Cod_Fiscale) VALUES (@Cognome, @Nome, @Indirizzo, @Citta, @CAP, @Cod_Fiscale )";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    connection.Open();
                    command.Parameters.AddWithValue("@Cognome", anagrafica.Cognome);
                    command.Parameters.AddWithValue("@Nome", anagrafica.Nome);
                    command.Parameters.AddWithValue("@Indirizzo", anagrafica.Indirizzo);
                    command.Parameters.AddWithValue("@Citta", anagrafica.Citta);
                    command.Parameters.AddWithValue("@CAP", anagrafica.CAP);
                    command.Parameters.AddWithValue("@Cod_Fiscale", anagrafica.Cod_Fiscale);
                    command.ExecuteNonQuery();
                }
            }

            return RedirectToAction("Index");

        }
    }
}
using PoliziaMunicipale.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace PoliziaMunicipale.Controllers
{
    public class AvanzateController : Controller
    {

        public ActionResult Avanzate()
        {
            return View();
        }



        public ActionResult Trasgressori()
        {
            List<Trasgressori> trasgressori = new List<Trasgressori>();
            string connectionString = ConfigurationManager.ConnectionStrings["Polizia"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT ANAGRAFICA.COGNOME, ANAGRAFICA.NOME, COUNT(ANAGRAFICA.IDanagrafica) AS TOTALE FROM ANAGRAFICA JOIN VERBALE ON ANAGRAFICA.IDanagrafica = VERBALE.IDanagrafica GROUP BY ANAGRAFICA.COGNOME, ANAGRAFICA.NOME";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Trasgressori d = new Trasgressori();
                        d.Cognome = reader["COGNOME"].ToString();
                        d.totale = Convert.ToInt32(reader["TOTALE"]);
                        d.trasgressori = reader["NOME"].ToString();

                        trasgressori.Add(d);
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = "Errore: " + ex.Message;
                }
                finally
                {
                    conn.Close();
                }
            }

            return View(trasgressori);
        }

        public ActionResult Punti()
        {
            List<Trasgressori> trasgressori = new List<Trasgressori>();
            string connectionString = ConfigurationManager.ConnectionStrings["Polizia"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT ANAGRAFICA.COGNOME, ANAGRAFICA.NOME, SUM(Verbale.DecurtamentoPunti) AS TOTALE FROM ANAGRAFICA JOIN VERBALE ON ANAGRAFICA.IDanagrafica = VERBALE.IDanagrafica GROUP BY ANAGRAFICA.COGNOME, ANAGRAFICA.NOME";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Trasgressori d = new Trasgressori();
                        d.Cognome = reader["COGNOME"].ToString();
                        d.totale = Convert.ToInt32(reader["TOTALE"]);
                        d.trasgressori = reader["NOME"].ToString();

                        trasgressori.Add(d);
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = "Errore: " + ex.Message;
                }
                finally
                {
                    conn.Close();
                }
            }

            return View(trasgressori);
        }

        public ActionResult Piudieci()
        {

            List<Verbale> trasgressori = new List<Verbale>();
            string connectionString = ConfigurationManager.ConnectionStrings["Polizia"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
                try
                {
                    conn.Open();
                    string query = "SELECT v.*, tv.Descrizione_Verbale, a.Nome, a.Cognome " +
                                   "FROM Verbale v " +
                                   "INNER JOIN Violazioni tv ON v.IDviolazione = tv.idViolazione " +
                                   "INNER JOIN Anagrafica a ON v.idAnagrafica = a.idAnagrafica " +
                                   "WHERE v.DecurtamentoPunti > 10";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Verbale v = new Verbale();
                        v.IDverbale = Convert.ToInt32(reader["IDverbale"]);
                        v.DataViolazione = Convert.ToDateTime(reader["DataViolazione"]);
                        v.IndirizzoViolazione = reader["IndirizzoViolazione"].ToString();
                        v.Nominativo_Agente = reader["Nominativo_Agente"].ToString();
                        v.DataVerbale = Convert.ToDateTime(reader["DataVerbale"]);
                        v.Importo = Convert.ToInt16(reader["Importo"]);
                        v.DecurtamentoPunti = Convert.ToInt32(reader["DecurtamentoPunti"]);
                        v.IDanagrafica = Convert.ToInt32(reader["IDanagrafica"]);
                        v.IDviolazione = Convert.ToInt32(reader["IDviolazione"]);
                        v.Descrizione_Verbale = reader["Descrizione_Verbale"].ToString();
                        v.Nome = reader["Nome"].ToString();
                        v.Cognome = reader["Cognome"].ToString();
                        trasgressori.Add(v);
                    }
                }
                catch (Exception ex)
                {
                    Response.Write($"Errore durante il recupero dei dati: {ex.Message}");
                }
                finally
                {
                    conn.Close();
                }
            return View(trasgressori);

        }
        public ActionResult Quattrocento()
        {

            List<Verbale> trasgressori = new List<Verbale>();
            string connectionString = ConfigurationManager.ConnectionStrings["Polizia"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
                try
                {
                    conn.Open();
                    string query = "SELECT v.*, tv.Descrizione_Verbale, a.Nome, a.Cognome " +
                                   "FROM Verbale v " +
                                   "INNER JOIN Violazioni tv ON v.IDviolazione = tv.idViolazione " +
                                   "INNER JOIN Anagrafica a ON v.idAnagrafica = a.idAnagrafica " +
                                   "WHERE v.Importo > 400";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Verbale v = new Verbale();
                        v.IDverbale = Convert.ToInt32(reader["IDverbale"]);
                        v.DataViolazione = Convert.ToDateTime(reader["DataViolazione"]);
                        v.IndirizzoViolazione = reader["IndirizzoViolazione"].ToString();
                        v.Nominativo_Agente = reader["Nominativo_Agente"].ToString();
                        v.DataVerbale = Convert.ToDateTime(reader["DataVerbale"]);
                        v.Importo = Convert.ToInt16(reader["Importo"]);
                        v.DecurtamentoPunti = Convert.ToInt32(reader["DecurtamentoPunti"]);
                        v.IDanagrafica = Convert.ToInt32(reader["IDanagrafica"]);
                        v.IDviolazione = Convert.ToInt32(reader["IDviolazione"]);
                        v.Descrizione_Verbale = reader["Descrizione_Verbale"].ToString();
                        v.Nome = reader["Nome"].ToString();
                        v.Cognome = reader["Cognome"].ToString();
                        trasgressori.Add(v);
                    }
                }
                catch (Exception ex)
                {
                    Response.Write($"Errore durante il recupero dei dati: {ex.Message}");
                }
                finally
                {
                    conn.Close();
                }
            return View(trasgressori);
        }
    }
}


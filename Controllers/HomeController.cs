using _1MarzoTest.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1MarzoTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Uno()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"SELECT Verbale.IdAnagrafica, Angrafica.Cognome, Angrafica.Nome, COUNT(Verbale.IdAnagrafica) AS TotaleVerbali 
                                 FROM Verbale 
                                 INNER JOIN Angrafica ON Verbale.IdAnagrafica = Angrafica.IdAnagrafica 
                                 GROUP BY Verbale.IdAnagrafica, Angrafica.Cognome, Angrafica.Nome;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    List<Uno> uni = new List<Uno>();
                    while (rdr.Read())
                    {
                        Uno uno = new Uno();

                        uno.IdAnagrafica = (int)rdr["IdAnagrafica"];
                        uno.Cognome = (string)rdr["Cognome"];
                        uno.Nome = (string)rdr["Nome"];
                        uno.TotaleVerbali = (int)rdr["TotaleVerbali"];
                        uni.Add(uno);
                    }
                    return View(uni);
                }
            }

        }

        [HttpGet]
        public ActionResult Due()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"SELECT Verbale.IdAnagrafica, Angrafica.Cognome, Angrafica.Nome, SUM(Verbale.DecurtamentoPunti) AS TotalePuntiDecurtati
                                FROM Verbale 
                                INNER JOIN Angrafica ON Verbale.IdAnagrafica = Angrafica.IdAnagrafica 
                                GROUP BY Verbale.IdAnagrafica, Angrafica.Cognome, Angrafica.Nome;;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    List<Due> dui = new List<Due>();
                    while (rdr.Read())
                    {
                        Due due = new Due();

                        due.IdAnagrafica = (int)rdr["IdAnagrafica"];
                        due.Cognome = (string)rdr["Cognome"];
                        due.Nome = (string)rdr["Nome"];
                        due.TotalePuntiDecurtati = (int)rdr["TotalePuntiDecurtati"];
                        dui.Add(due);
                    }
                    return View(dui);
                }
            }

        }

        [HttpGet]
        public ActionResult Tre()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"SELECT Verbale.Importo, Angrafica.Cognome, Angrafica.Nome, Verbale.DataViolazione, Verbale.DecurtamentoPunti
                                 FROM Verbale
                                 INNER JOIN Angrafica ON Verbale.IdAnagrafica = Angrafica.IdAnagrafica 
                                 WHERE Verbale.DecurtamentoPunti > 10";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    List<Tre> Tri = new List<Tre>();
                    while (rdr.Read())
                    {
                        Tre Tre = new Tre();

                        Tre.Importo = (decimal)rdr["Importo"];
                        Tre.Cognome = (string)rdr["Cognome"];
                        Tre.Nome = (string)rdr["Nome"];
                        Tre.DataViolazione = (DateTime)rdr["DataViolazione"];
                        Tre.DecurtamentoPunti = (int)rdr["DecurtamentoPunti"];
                        Tri.Add(Tre);
                    }
                    return View(Tri);
                }
            }

        }

        [HttpGet]
        public ActionResult Quattro()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"SELECT * FROM Verbale WHERE Importo >400";
                

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    List<Verbale> Verbali = new List<Verbale>();
                    while (rdr.Read())
                    {
                        Verbale Verbale = new Verbale();

                        Verbale.IdVerbale = (int)rdr["IdVerbale"];
                        Verbale.DataViolazione = (DateTime)rdr["DataViolazione"];
                        Verbale.IndirizzoViolazione = (string)rdr["IndirizzoViolazione"];
                        Verbale.NominativoAgente = (string)rdr["NominativoAgente"];
                        Verbale.DataTrascrizioneVerbale = (DateTime)rdr["DataTrascrizioneVerbale"];
                        Verbale.Importo = (decimal)rdr["Importo"];
                        Verbale.decurtazionePunti = (int)rdr["DecurtamentoPunti"];
                        Verbale.Contestabile = (bool)rdr["Contestabile"];
                        Verbale.IdAnagrafica = (int)rdr["IdAnagrafica"];
                        Verbali.Add(Verbale);

                    }
                    return View(Verbali);
                }

            }
        }
    }
}
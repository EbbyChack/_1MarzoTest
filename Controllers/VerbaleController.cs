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
    public class VerbaleController : Controller
    {
        // GET: Verbale
        //per visualizzare tutti i verbali contestabili
        [HttpGet]
        public ActionResult Index()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT * FROM Verbale WHERE Contestabile = 1";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    //creo una lista di oggetti
                    List<Verbale> verbali = new List<Verbale>();
                    while (rdr.Read())
                    {
                        //creo un oggetto per ogni riga del db
                        Verbale verbale = new Verbale();

                        verbale.IdVerbale = (int)rdr["IdVerbale"];
                        verbale.DataViolazione = (DateTime)rdr["DataViolazione"];
                        verbale.IndirizzoViolazione = (string)rdr["IndirizzoViolazione"];
                        verbale.NominativoAgente = (string)rdr["NominativoAgente"];
                        verbale.DataTrascrizioneVerbale = (DateTime)rdr["DataTrascrizioneVerbale"];
                        verbale.Importo = (decimal)rdr["Importo"];
                        verbale.decurtazionePunti = (int)rdr["DecurtamentoPunti"];
                        verbale.Contestabile = (bool)rdr["Contestabile"];
                        verbale.IdAnagrafica =(int)rdr["IdAnagrafica"];
                        
                        //inserisco l'oggetto nella lista
                        verbali.Add(verbale);
                    }
                    return View(verbali);
                }
            }

        }

       
        public ActionResult InserisciVerbale()
        {
            return View();
        }

        //per inserire un verbale

        [HttpPost]
        public ActionResult InserisciVerbale(Verbale verbale)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"INSERT INTO Verbale (DataViolazione, IndirizzoViolazione, NominativoAgente,DataTrascrizioneVerbale, Importo, DecurtamentoPunti, Contestabile, IdAnagrafica)
                                 VALUES (@DataViolazione, @IndirizzoViolazione, @NominativoAgente, @DataTrascrizioneVerbale, @Importo, @DecurtamentoPunti, @Contestabile, @IdAnagrafica)";


                System.Diagnostics.Debug.WriteLine(verbale.DataViolazione);
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    //assegno i valori presi dal form alle variabili
                    cmd.Parameters.AddWithValue("@DataViolazione", verbale.DataViolazione.Date);
                    cmd.Parameters.AddWithValue("@IndirizzoViolazione", verbale.IndirizzoViolazione);
                    cmd.Parameters.AddWithValue("@NominativoAgente", verbale.NominativoAgente);
                    cmd.Parameters.AddWithValue("@DataTrascrizioneVerbale", verbale.DataTrascrizioneVerbale.Date);
                    cmd.Parameters.AddWithValue("@Importo", verbale.Importo);
                    cmd.Parameters.AddWithValue("@DecurtamentoPunti", verbale.decurtazionePunti);
                    cmd.Parameters.AddWithValue("@Contestabile", verbale.Contestabile);
                    cmd.Parameters.AddWithValue("@IdAnagrafica", verbale.IdAnagrafica);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                return RedirectToAction("Index");
            }
        }
    }
}
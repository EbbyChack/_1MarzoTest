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
    public class AngraficaController : Controller
    {
        // GET: Angrafica
        public ActionResult Index()
        {
            return View();
        }
       
        [HttpPost]
        public ActionResult InserisciAnagrafica(Angrafica angrafica)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"INSERT INTO Angrafica (Cognome, Nome, Indirizzo, Città, CAP, CF, FK_Id_Violazione)
                                 VALUES (@Cognome, @Nome, @Indirizzo, @Città, @CAP, @CF, @FK_Id_Violazione)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    //assegno i valori presi dal form alle variabili 
                    cmd.Parameters.AddWithValue("@Cognome", angrafica.Cognome);
                    cmd.Parameters.AddWithValue("@Nome", angrafica.Nome);
                    cmd.Parameters.AddWithValue("@Indirizzo", angrafica.Indirizzo);
                    cmd.Parameters.AddWithValue("@Città", angrafica.Citta);
                    cmd.Parameters.AddWithValue("@CAP", angrafica.Cap);
                    cmd.Parameters.AddWithValue("@CF", angrafica.CF);
                    cmd.Parameters.AddWithValue("@FK_Id_Violazione", angrafica.IdViolazione);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                return View("Index");

            }

        }

    }
}
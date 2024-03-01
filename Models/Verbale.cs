using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1MarzoTest.Models
{
    public class Verbale
    {
        
        public int IdVerbale { get; set; }

        [Display(Name = "Data della violazione")]
        
        public DateTime DataViolazione { get; set; }

        [Display(Name = "Indirizzo della violazione")]
        public string IndirizzoViolazione { get; set; }

        [Display(Name = "Nominativo agente")]
        public string NominativoAgente { get; set; }

        [Display(Name = "Data trascrizione verbale")]
        
        public DateTime DataTrascrizioneVerbale { get; set; }

        
        public decimal Importo { get; set; }


        [Display(Name = "Decurtazione punti")]
        public int decurtazionePunti { get; set; }

       
        public bool Contestabile { get; set; }

        [Display(Name = "Id Anagrafica")]
        public int IdAnagrafica { get; set; }

    }
}
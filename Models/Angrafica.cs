using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1MarzoTest.Models
{
    public class Angrafica
    {
        [HiddenInput(DisplayValue = false)] public int IdAnagrafica { get; set; }
        public string Cognome { get; set; }
        public string Nome { get; set; }    
        public string Indirizzo { get; set; }
        public string Citta { get; set; }
        public string Cap { get; set; }
        public string CF { get; set; }

        [Display(Name = "Id Violazione")]
        public int IdViolazione { get; set; }

    }
}
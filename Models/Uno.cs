using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _1MarzoTest.Models
{
    public class Uno
    {
        public int IdAnagrafica { get; set; }
        public string Cognome { get; set; }
        public string Nome { get; set; }

        [Display(Name = "Totale Verbali")]
        public int TotaleVerbali { get; set; }
    }
}
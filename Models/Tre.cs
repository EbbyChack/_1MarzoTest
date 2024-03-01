using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _1MarzoTest.Models
{
    public class Tre
    {
        public decimal Importo { get; set; }
        public string Cognome { get; set; }
        public string Nome { get; set; }

        [Display(Name = "Data Violazione")]
        public DateTime DataViolazione { get; set; }

        [Display(Name = "Decurtamento Punti")]
        public int DecurtamentoPunti { get; set; }
    }
}
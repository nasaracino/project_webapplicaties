using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyWatchList.Models
{
    [Table("Seizoenen")]
    public class Seizoen
    {
        public int SeizoenID { get; set; }
        [Required]
        public string Titel { get; set; }
        [Required]
        public string Omschrijving { get; set; }
        [Required]
        public string JaarVanUitkomst { get; set; }
        [Required]
        public int AantalAfleveringen { get; set; }
        
        //navigatieproperties
        public ICollection<Aflevering> Afleveringen { get; set; }
        public Serie Serie { get; set; }
       
    }
}

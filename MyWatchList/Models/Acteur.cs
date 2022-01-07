using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWatchList.Models
{
    public class Acteur
    {
        public int ActeurID { get; set; }
        [Required]
        public string Voornaam { get; set; }
        [Required]
        public string Achternaam { get; set; }
        public string Geboortejaar { get; set; }
        [Required]
        public string LandVanHerkomst { get; set; }

        //navigatieproperties
        public ICollection<SpeeltIn> SpeeltIn { get; set; }
    }
}

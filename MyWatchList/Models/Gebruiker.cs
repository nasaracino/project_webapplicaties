using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWatchList.Models
{
    public class Gebruiker
    {
        public int GebruikerID { get; set; }
        [Required]
        public string Voornaam { get; set; }
        [Required]
        public string Achternaam { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Wachtwoord { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Geboortedatum { get; set; }
        [Required]
        public bool isBeheerder { get; set; }

        //navigatieproperties
        public ICollection<GebruikerSerie> GebruikerSeries { get; set; }
    }
}

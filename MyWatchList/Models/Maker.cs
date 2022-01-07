using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyWatchList.Models
{
    [Table("Maker")]

    public class Maker
    {
        public int MakerID { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Geboortejaar { get; set; }
        public string LandVanHerkomst { get; set; }
        

        //navigatieproperties
        public ICollection<Maakte> Maakte { get; set; }
    }
}

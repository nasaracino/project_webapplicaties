using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyWatchList.Models
{
    [Table("GebruikerSerie")]
    public class GebruikerSerie
    {
        public int GebruikerSerieID { get; set; }
        public int GebruikerID { get; set; }
        public int SerieID { get; set; }

        //navigatieproperties
        public virtual Gebruiker Gebruiker { get; set; }
        public virtual Serie Serie { get; set; }
    }
}

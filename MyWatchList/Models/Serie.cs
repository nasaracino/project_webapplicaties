using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWatchList.Models
{
    public class Serie
    {
        public int SerieID { get; set; }
        [Required]
        public string Titel { get; set; }
        [Required]
        public string JaarVanUitkomst { get; set; }
        [Required]
        public int AantalSeizoenen { get; set; }
        public string MinimumLeeftijd { get; set; }
        public string CoverImg { get; set; }

        //navigatieproperties
        public ICollection<Seizoen> Seizoenen { get; set; }
        public ICollection<GebruikerSerie> GebruikerSeries { get; set; }
        public ICollection<SpeeltIn> SpeeltIn { get; set; }
        public ICollection<Maakte> Maakte { get; set; }
    }
}

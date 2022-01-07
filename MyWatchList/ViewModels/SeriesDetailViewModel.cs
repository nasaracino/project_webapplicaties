using MyWatchList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWatchList.ViewModels
{
    public class SeriesDetailViewModel
    {
        public string Titel { get; set; }
        public string JaarVanUitkomst { get; set; }
        public int AantalSeizoenen { get; set; }
        public string MinimumLeeftijd { get; set; }
        public List<SpeeltIn> Hoofdrollen { get; set; }
        public List<Acteur> Acteurs { get; set; }
        public int? SerieId { get; set; }

    }
}

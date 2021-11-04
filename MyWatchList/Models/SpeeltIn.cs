using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyWatchList.Models
{
    [Table("SpeeltIn")]
    public class SpeeltIn
    {
        public int SpeeltInID { get; set; }
        public int ActeurID { get; set; }
        public int SerieID { get; set; }
        public string NaamInSerie { get; set; }

        //navigatieproperties
        public virtual Acteur Acteur { get; set; }
        public virtual Serie Serie { get; set; }
    }
}

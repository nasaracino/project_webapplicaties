using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyWatchList.Models
{
    [Table("Maakte")]
    public class Maakte
    {
        public int MaakteID { get; set; }
        public int MakerID { get; set; }
        public int SerieID { get; set; }

        //navigatieproperties
        public virtual Maker Maker { get; set; }
        public virtual Serie Serie { get; set; }

    }
}

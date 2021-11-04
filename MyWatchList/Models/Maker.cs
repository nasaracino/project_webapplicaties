using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWatchList.Models
{
    public class Maker: Acteur
    {
        public int MakerID { get; set; }
        

        //navigatieproperties
        public ICollection<Maakte> Maakte { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyWatchList.Models
{
    [Table("Afleveringen")]
    public class Aflevering
    {
        public int AfleveringID { get; set; }
        [Required]
        public string Titel { get; set; }
        [Required]
        public int Duur { get; set; }

        //navigatieproperties
        public Seizoen Seizoen { get; set; }
    }
}

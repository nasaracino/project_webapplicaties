using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWatchList.ViewModels
{
    public class AccountViewModel
    {
        public int? GebruikerId { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Email { get; set; }
        public string Wachtwoord { get; set; }
        public DateTime Geboortedatum { get; set; }

    }
}

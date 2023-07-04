using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SqlServerData.Models
{
    public class Klant
    {
        public int KlantId { get; set; }
        public string? BedrijfNaam { get; set; }
        public string? Voornaam { get; set; }
        public string? Achternaam { get; set; }        
        public string? Straat { get; set; }
        public string? Huisnummer { get; set; }
        public string? Gemeente { get; set; }
        public string? Telefoon { get; set; }        
        public string? Email { get; set; }
    }
}

using CommunityToolkit.Mvvm.ComponentModel;

namespace KleineZelfstandige.Models
{
    public class Klant : ObservableObject
    {
        public int? KlantId { get; set; }
        public string BedrijfNaam { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Straat { get; set; }
        public string Huisnummer { get; set; }
        public string Gemeente { get; set; }        
        public string Telefoon { get; set; }
        public string Email { get; set; }

        public string Adress => $"{Straat} {Huisnummer}, {Gemeente}";
        public string Naam => $"{Achternaam} {Voornaam}";

    }
}

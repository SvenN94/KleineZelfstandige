namespace SqlServerData.Models
{
    public class Activiteit
    {
        public int Id { get; set; }
        public int KlantId { get; set; }
        public DateTime GeplandeDatum { get; set; }
        public decimal GewerkteUren { get; set; }
        public string SoortWerk { get; set; }
        public string Materialen { get; set; }
        public string Locatie { get; set; }

        public string SqlDate()
        {
            string sqldate = GeplandeDatum.ToString("yyyy / MM / dd HH: mm:ss");
            return sqldate;
        }

    }
}

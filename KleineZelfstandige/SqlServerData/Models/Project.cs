namespace SqlServerData.Models
{
    public class Project
    {
        public int Id { get; set; }
        public int KlantId { get; set; }
        public int ActiviteitId { get; set; }
        public int DoodleId { get; set; }
        public string Locatie { get; set; }
        public DateTime EindDatum { get; set; }

        public string SqlDate()
        {
            string sqldate = EindDatum.ToString("yyyy / MM / dd HH: mm:ss");
            return sqldate;
        }
    }
}

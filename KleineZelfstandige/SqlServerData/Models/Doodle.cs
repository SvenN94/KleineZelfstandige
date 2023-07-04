namespace SqlServerData.Models
{
    public class Doodle
    {
        public int DoodleId { get; set;  }
        public string? Tekst { get; set; }
        public DateTime Created { get;  set; }

        public string SqlDate()
        {
            
            string sqlDate = Created.ToString("yyyy / MM / dd HH: mm:ss");
            return sqlDate;
        }
    }
}

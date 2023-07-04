namespace KleineZelfstandige.Models
{
    public class Doodle
    {
        public int DoodleId { get; set; }        
        public string Tekst { get; set; }
        public static DateTime Created { get; set; }
        public Doodle()
        {
            Created = DateTime.Now;
        }
    }
}

using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KleineZelfstandige.Models
{
    public class Login
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }        
    }
}

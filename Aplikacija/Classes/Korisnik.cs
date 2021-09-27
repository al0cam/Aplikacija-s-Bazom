using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikacija.Classes
{
    public class Korisnik
    {
        public long Id { get; set; }
        public string Naziv { get; set; }
        public string Password { get; set; }
        public long GameCount { get; set; }
    }
}

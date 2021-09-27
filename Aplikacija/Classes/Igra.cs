using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikacija
{
    public class Igra
    {
        public long Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public string Izdavac { get; set; }
        public string Zanr { get; set; }
        public float ProsjecnaOcjena { get; set; }
        public string Proizvodac { get; set; }
        public string Pokretac { get; set; }
        public bool Posjedovanje { get; set; }
        public long Ocjena { get; set; }
    }
}

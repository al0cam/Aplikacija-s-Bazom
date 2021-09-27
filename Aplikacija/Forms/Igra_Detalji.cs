using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplikacija
{
    public partial class Igra_Detalji : Form
    {
        private Igra Redak = new Igra();
        public Igra_Detalji(Igra RedakIzTablice)
        {
            InitializeComponent();
            Location = new Point(100, 100);
            Redak = RedakIzTablice;
            this.Text = Redak.Naziv;
            this.labelNaziv.Text = "Naziv: " + Redak.Naziv;
            this.labelOpis.Text = "Opis: " + Redak.Opis;
            this.labelIzdavac.Text = "Izdavac: " + Redak.Izdavac;
            this.labelZanr.Text = "Zanr: " + Redak.Zanr;
            this.labelDeveloper.Text = "Proizvodac: " + Redak.Proizvodac;
            this.labelPlatforma.Text = "Prosjecna ocjena: " + Redak.ProsjecnaOcjena;
            this.labelEngine.Text = "Pokretac: " + Redak.Pokretac;
            this.labelPosjedovanje.Text = "Posjedovanje: " + Redak.Posjedovanje;
        }
    }
}

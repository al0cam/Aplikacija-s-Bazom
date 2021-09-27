using Aplikacija.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplikacija.Forms
{
    public partial class Ocjena : Form
    {
        private Korisnik korisnik = new Korisnik();
        private Igra igra = new Igra();
        public Ocjena(Korisnik retrieved,Igra retrievedIgra)
        {
            InitializeComponent();
            Location = new Point(100, 100);
            korisnik = retrieved;
            igra = retrievedIgra;
            labelNaziv.Text = igra.Naziv;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(int.Parse(textBoxOcjena.Text) <= 5 && int.Parse(textBoxOcjena.Text) >= 1)
            {
                string toInsert = "update Korisnik_Igra " +
                                  " set ocjena = " + textBoxOcjena.Text +
                                  " where Korisnik_igra.ID_igra = " + igra.Id +
                                  " and Korisnik_Igra.ID_korisnik = " + korisnik.Id;
                BazaPodataka.InsertSql(toInsert, 0);
            }
            
        }
    }
}

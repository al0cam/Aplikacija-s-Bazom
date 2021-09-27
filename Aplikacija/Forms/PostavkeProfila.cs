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
    public partial class PostavkeProfila : Form
    {
        private Korisnik korisnik = new Korisnik();
        public PostavkeProfila(Korisnik retrieved)
        {
            InitializeComponent();
            Location = new Point(100, 100);
            korisnik = retrieved;
        }

        private void PostavkeProfila_Load(object sender, EventArgs e)
        {
            textBox1.Text = korisnik.Naziv;
            textBox2.Text = korisnik.Password;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            korisnik.Naziv = textBox1.Text;
            korisnik.Password = textBox2.Text;
            BazaPodataka.AlterKorisnik(korisnik);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BazaPodataka.DeleteKorisnik(korisnik);

        }
    }
}

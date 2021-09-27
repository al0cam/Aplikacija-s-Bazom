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
    public partial class StartMenu : Form
    {
        private Korisnik korisnik = new Korisnik();
        public StartMenu(Korisnik retrieved)
        {
            InitializeComponent();
            Location = new Point(100, 100);
            korisnik = retrieved;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string check = BazaPodataka.LoginCheck(korisnik.Naziv, korisnik.Password);
            if (check == "true")
            {
                Sve_Igre sveIgre = new Sve_Igre(korisnik);
                this.Hide();
                sveIgre.ShowDialog();
                this.Show();
            }
            else
                label1.Text = "niste prijavljeni, registrirajte se";
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PostavkeProfila postavke = new PostavkeProfila(korisnik);
            this.Hide();
            postavke.ShowDialog();
            this.Show();
        }
    }
}

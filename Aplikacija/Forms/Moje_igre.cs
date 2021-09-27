using Aplikacija.Classes;
using Aplikacija.Forms;
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
    public partial class Moje_Igre : Form
    {
        private Korisnik korisnik = new Korisnik();
        private void RefreshMojeIgre()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = BazaPodataka.ReadMojeIgre(korisnik);
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["Izdavac"].Visible = false;
            dataGridView1.Columns["Pokretac"].Visible = false;
            dataGridView1.Columns["Proizvodac"].Visible = false;
            dataGridView1.Columns["Posjedovanje"].Visible = false;
            labelGameCount.Text = "Broj igara u kolekciji: " + BazaPodataka.RetrieveGameCount(korisnik);
            dataGridView1.AutoResizeColumns();
        }
        public Moje_Igre(Korisnik retrieved)
        {
            InitializeComponent();
            Location = new Point(100, 100);
            korisnik = retrieved;
            RefreshMojeIgre();
        }
        

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Igra stavka = dataGridView1.SelectedRows[0].DataBoundItem as Igra;
                Igra_Detalji igra_detalji = new Igra_Detalji(stavka);
                igra_detalji.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Igra stavka = dataGridView1.SelectedRows[0].DataBoundItem as Igra;
                Ocjena ocjena = new Ocjena(korisnik, stavka);
                ocjena.ShowDialog();
                RefreshMojeIgre();
            }
            
        }
    }
}

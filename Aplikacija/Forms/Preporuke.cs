using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplikacija.Classes
{
    public partial class Preporuke : Form
    {
        private Korisnik korisnik = new Korisnik();
        public Preporuke(Korisnik retrieved)
        {
            InitializeComponent();
            Location = new Point(100, 100);
            korisnik = retrieved;
        }
        private void RefreshPreporuka()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = BazaPodataka.ReadPreporuke(korisnik);
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["Izdavac"].Visible = false;
            dataGridView1.Columns["Pokretac"].Visible = false;
            dataGridView1.Columns["Proizvodac"].Visible = false;
            dataGridView1.Columns["Ocjena"].Visible = false;
            dataGridView1.AutoResizeColumns();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Preporuke_Load(object sender, EventArgs e)
        {
            RefreshPreporuka();
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
                if (stavka.Posjedovanje == true)
                {
                    labelPosjedovanje.Text = "U kolekciji";
                }
                else
                {
                    BazaPodataka.DodajUKolekciju(stavka, korisnik);
                    labelPosjedovanje.Text = "Dodano u kolekciju";
                    RefreshPreporuka();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Igra stavka = dataGridView1.SelectedRows[0].DataBoundItem as Igra;
                if (stavka.Posjedovanje == false)
                {
                    labelPosjedovanje.Text = "Nije u kolekciji";
                }
                else
                {
                    BazaPodataka.MakniIzKolekcije(stavka, korisnik);
                    labelPosjedovanje.Text = "Maknuto iz kolekcije";
                    RefreshPreporuka();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Moje_Igre moje_Igre = new Moje_Igre(korisnik);
            this.Hide();
            moje_Igre.ShowDialog();
            RefreshPreporuka();
            this.Show();
        }
    }
}

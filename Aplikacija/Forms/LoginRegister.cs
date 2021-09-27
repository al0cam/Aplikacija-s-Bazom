using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Aplikacija.Classes;

namespace Aplikacija.Forms
{
    public partial class LoginRegister : Form
    {
        public LoginRegister()
        {
            InitializeComponent();
            Location = new Point(100, 100);
        }

        private void PrijavaButton_Click(object sender, EventArgs e)
        {
            string username = UsernameTextbox.Text,
                   password = PasswordTextBox.Text;
            string returnedValue = BazaPodataka.LoginCheck(username, password);
            if (returnedValue == "true")
            {
                StatusPrijaveLabel.Text = "Prijava uspjesna";
                CountdownEvent pauza = new CountdownEvent(1);
                pauza.Wait(1500);
                StartMenu meni = new StartMenu(BazaPodataka.RetrieveKorisnik(username, password));
                this.Hide();
                meni.ShowDialog();
                this.Show();
            }
            else
            {
                StatusPrijaveLabel.Text = "Prijava neuspjesna";
            }
        }

        private void RegistracijaButton_Click(object sender, EventArgs e)
        {
            string username = UsernameTextbox.Text,
                   password = PasswordTextBox.Text;
            string returnedValue = BazaPodataka.RegisterCheck(username, password);
            StatusPrijaveLabel.Text = returnedValue;
        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }
    }
}

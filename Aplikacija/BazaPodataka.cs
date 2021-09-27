using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aplikacija.Classes;
using Microsoft.Data.Sqlite;

namespace Aplikacija
{
    public class BazaPodataka
    {
        static string connectionString;
        static SqliteConnection connection;
        static SqliteCommand command;
        public static void Connect()
        {
            connectionString = "Data Source = " + Environment.CurrentDirectory + @"\..\..\Resources\Database.db3";
            //Conso
            Console.WriteLine(connectionString);
            string stm = "SELECT SQLITE_VERSION()";

            connection = new SqliteConnection(connectionString);
            connection.Open();

            command = new SqliteCommand(stm, connection);
            string version = command.ExecuteScalar().ToString();
            connection.Close();
        }
        public static string InsertSql(string insertValue, int choice)
        {
            connection.Open();
            command.CommandText = insertValue;
            if (choice == 1)
            {
                string returnValue = command.ExecuteScalar().ToString();
                connection.Close();
                return returnValue;
            }
            else
            {
                command.ExecuteNonQuery();
                connection.Close();
                return "Done";
            }
        }
        public static string RetrieveGameCount(Korisnik korisnik)
        {
            string toInsert = "select broj_igara_u_kolekciji from Korisnik where ID_korisnik = '" + korisnik.Id + "';";
            return InsertSql(toInsert, 1);
        }

        public static List<Aplikacija.Igra> ReadIgre(Korisnik korisnik)
        {
            connection.Open();
            command.CommandText = "select distinct Igra.ID_igra,Igra.naziv,Igra.opis,Izdavac.naziv,VrstaIgre.naziv," +
                                  " Igra.prosjecna_ocjena,group_concat(DISTINCT Proizvodac.naziv),Pokretac.naziv,Korisnik_Igra.posjedovanje,Korisnik_Igra.ocjena" +
                                  " from Igra,Izdavac,VrstaIgre,Proizvodac,Pokretac,Korisnik," +
                                  " VrstaIgre_Igra,Proizvodac_Igra,Pokretac_Igra,Korisnik_Igra" +
                                  " where Igra.izdavac = Izdavac.ID_Izdavac" +
                                  " and Igra.ID_igra = VrstaIgre_Igra.ID_igra and VrstaIgre.ID_vrstaIgre = VrstaIgre_Igra.ID_vrstaIgre" +
                                  " and Igra.ID_igra = Proizvodac_Igra.ID_igra and Proizvodac.ID_proizvodac = Proizvodac_Igra.ID_proizvodac" +
                                  " and Igra.ID_igra = Pokretac_Igra.ID_igra and Pokretac.ID_pokretac = Pokretac_Igra.ID_pokretac" +
                                  " and Igra.ID_igra = Korisnik_Igra.ID_igra and Korisnik.ID_korisnik='" + korisnik.Id + "' " +
                                  " and Korisnik_Igra.ID_korisnik ='" + korisnik.Id + "' " +
                                  " group by Igra.ID_igra, Igra.naziv, Igra.opis, Izdavac.naziv, VrstaIgre.naziv, Pokretac.naziv;";
            IDataReader executed = command.ExecuteReader();

            List<Igra> popis = new List<Igra>();
            while (executed.Read())
            {
                Igra jednaIgra = new Igra()
                {
                    Id = long.Parse(executed.GetString(0)),
                    Naziv = executed.GetString(1),
                    Opis = executed.GetString(2),
                    Izdavac = executed.GetString(3),
                    Zanr = executed.GetString(4),
                    ProsjecnaOcjena = float.Parse(executed.GetString(5)),
                    Proizvodac = executed.GetString(6),
                    Pokretac = executed.GetString(7),
                    Posjedovanje = Boolean.Parse(executed.GetString(8)),
                    Ocjena = long.Parse(executed.GetString(9))

                };
                popis.Add(jednaIgra);
            }
            executed.Close();
            connection.Close();
            return popis;
        }
        public static List<Aplikacija.Igra> ReadMojeIgre(Korisnik korisnik)
        {
            connection.Open();
            command.CommandText = "select distinct Igra.ID_igra,Igra.naziv,Igra.opis,Izdavac.naziv,VrstaIgre.naziv," +
                                  " Igra.prosjecna_ocjena,group_concat(DISTINCT Proizvodac.naziv),Pokretac.naziv,Korisnik_Igra.posjedovanje,Korisnik_Igra.ocjena" +
                                  " from Igra,Izdavac,VrstaIgre,Proizvodac,Pokretac,Korisnik," +
                                  " VrstaIgre_Igra,Proizvodac_Igra,Pokretac_Igra,Korisnik_Igra" +
                                  " where Igra.izdavac = Izdavac.ID_Izdavac" +
                                  " and Igra.ID_igra = VrstaIgre_Igra.ID_igra and VrstaIgre.ID_vrstaIgre = VrstaIgre_Igra.ID_vrstaIgre" +
                                  " and Igra.ID_igra = Proizvodac_Igra.ID_igra and Proizvodac.ID_proizvodac = Proizvodac_Igra.ID_proizvodac" +
                                  " and Igra.ID_igra = Pokretac_Igra.ID_igra and Pokretac.ID_pokretac = Pokretac_Igra.ID_pokretac" +
                                  " and Igra.ID_igra = Korisnik_Igra.ID_igra and Korisnik.ID_korisnik='" + korisnik.Id + "' " +
                                  "and Korisnik_Igra.ID_korisnik='" + korisnik.Id + "' and Korisnik_Igra.posjedovanje = 'true'" +
                                  " group by Igra.ID_igra, Igra.naziv, Igra.opis, Izdavac.naziv, VrstaIgre.naziv, Pokretac.naziv;";
            IDataReader executed = command.ExecuteReader();

            List<Igra> popis = new List<Igra>();
            while (executed.Read())
            {
                Igra jednaIgra = new Igra()
                {
                    Id = long.Parse(executed.GetString(0)),
                    Naziv = executed.GetString(1),
                    Opis = executed.GetString(2),
                    Izdavac = executed.GetString(3),
                    Zanr = executed.GetString(4),
                    ProsjecnaOcjena = float.Parse(executed.GetString(5)),
                    Proizvodac = executed.GetString(6),
                    Pokretac = executed.GetString(7),
                    Posjedovanje = Boolean.Parse(executed.GetString(8)),
                    Ocjena = long.Parse(executed.GetString(9))
                };
                popis.Add(jednaIgra);
            }
            executed.Close();
            connection.Close();
            return popis;
        }
        public static List<Aplikacija.Igra> ReadPreporuke(Korisnik korisnik)
        {
            connection.Open();
            command.CommandText = "select distinct Igra.ID_igra,Igra.naziv,Igra.opis,Izdavac.naziv,VrstaIgre.naziv," +
                                  " Igra.prosjecna_ocjena,group_concat(DISTINCT Proizvodac.naziv),Pokretac.naziv,Korisnik_Igra.posjedovanje,Korisnik_Igra.ocjena" +
                                  " from Igra,Izdavac,VrstaIgre,Proizvodac,Pokretac,Korisnik," +
                                  " VrstaIgre_Igra,Proizvodac_Igra,Pokretac_Igra,Korisnik_Igra" +
                                  " where Igra.izdavac = Izdavac.ID_Izdavac" +
                                  " and Igra.ID_igra = VrstaIgre_Igra.ID_igra and VrstaIgre.ID_vrstaIgre = VrstaIgre_Igra.ID_vrstaIgre" +
                                  " and Igra.ID_igra = Proizvodac_Igra.ID_igra and Proizvodac.ID_proizvodac = Proizvodac_Igra.ID_proizvodac" +
                                  " and Igra.ID_igra = Pokretac_Igra.ID_igra and Pokretac.ID_pokretac = Pokretac_Igra.ID_pokretac" +
                                  " and Igra.ID_igra = Korisnik_Igra.ID_igra and Korisnik.ID_korisnik= " + korisnik.Id + 
                                  " and Korisnik_Igra.ID_korisnik=" + korisnik.Id +
                                  " and VrstaIgre.ID_vrstaIgre = " +
                                  " (select distinct VrstaIgre.ID_vrstaIgre " +
                                  " from Igra, VrstaIgre, VrstaIgre_Igra, Korisnik_Igra" +
                                  " where Korisnik_Igra.ID_korisnik = "+ korisnik.Id +" and Korisnik_Igra.ID_igra = Igra.ID_igra and" +
                                  " Igra.ID_igra = VrstaIgre_Igra.ID_igra and VrstaIgre_Igra.ID_vrstaIgre = VrstaIgre.ID_vrstaIgre" +
                                  " and Korisnik_Igra.ocjena > 2)" +
                                  " group by Igra.ID_igra, Igra.naziv, Igra.opis, Izdavac.naziv, VrstaIgre.naziv, Pokretac.naziv;";
            IDataReader executed = command.ExecuteReader();

            List<Igra> popis = new List<Igra>();
            while (executed.Read())
            {
                Igra jednaIgra = new Igra()
                {
                    Id = long.Parse(executed.GetString(0)),
                    Naziv = executed.GetString(1),
                    Opis = executed.GetString(2),
                    Izdavac = executed.GetString(3),
                    Zanr = executed.GetString(4),
                    ProsjecnaOcjena = float.Parse(executed.GetString(5)),
                    Proizvodac = executed.GetString(6),
                    Pokretac = executed.GetString(7),
                    Posjedovanje = Boolean.Parse(executed.GetString(8)),
                    Ocjena = long.Parse(executed.GetString(9))
                };
                popis.Add(jednaIgra);
            }
            executed.Close();
            connection.Close();
            return popis;
        }
        public static void DodajUKolekciju(Igra jednaIgra, Korisnik korisnik)
        {
            connection.Open();
            string toInsert = "update Korisnik_Igra " +
                              "set posjedovanje = 'true' where ID_korisnik = '" + korisnik.Id + "' " +
                              "and ID_Igra = '" + jednaIgra.Id + "';";
            command.CommandText = toInsert;
            command.ExecuteNonQuery();
            connection.Close();
        }
        public static void MakniIzKolekcije(Igra jednaIgra, Korisnik korisnik)
        {
            connection.Open();
            string toInsert = "update Korisnik_Igra " +
                              "set posjedovanje = 'false' where ID_korisnik = '" + korisnik.Id + "' " +
                              "and ID_Igra = '" + jednaIgra.Id + "';";
            command.CommandText = toInsert;
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static string LoginCheck(string username, string password)
        {
            string toInsert = "select case " +
                              "when exists(select ID_korisnik from Korisnik " +
                              "where naziv = '" + username + "' and password= '"+password+"') then 'true' " +
                              "else 'false' end;";
            string returnValue = BazaPodataka.InsertSql(toInsert, 1);
            return returnValue;
        }
        public static Korisnik RetrieveKorisnik(string username, string password)
        {
            connection.Open();
            string toInsert = "select * from Korisnik where naziv = '" + username + "' and password ='" + password + "';";
            command.CommandText = toInsert;
            IDataReader executed = command.ExecuteReader();
            executed.Read();
            Korisnik returnValue = new Korisnik()
            {
                Id = long.Parse(executed.GetString(0)),
                Naziv = executed.GetString(1),
                Password = executed.GetString(2),
                GameCount = long.Parse(executed.GetString(3))
            };
            executed.Close();
            connection.Close();
            return returnValue;
        }
        public static string RegisterCheck(string username, string password)
        {
            string toInsert = "select case " +
                              "when exists(select ID_korisnik from Korisnik where naziv = '"+username+"') then 'true' " +
                              "else 'false' end;";
            string returnValue = BazaPodataka.InsertSql(toInsert, 1);
            if (returnValue == "true")
                return "Korisnik vec postoji";
            else
            {
                toInsert = "insert into Korisnik(naziv,password) " +
                           "values ('" + username + "','" + password + "');";
                BazaPodataka.InsertSql(toInsert, 0);
                toInsert = "select count(ID_Igra) from Igra;";
                Korisnik korisnik = RetrieveKorisnik(username, password);
                int limit = int.Parse(BazaPodataka.InsertSql(toInsert, 1));
                for (int i = 1; i <= limit; i++)
                {
                    toInsert = "insert into Korisnik_Igra(ID_korisnik,ID_igra) " +
                               " values (" + korisnik.Id + "," + i + ");";
                    BazaPodataka.InsertSql(toInsert, 0);
                }

                return "Korisnik stvoren";
            }

        }
        public static void AlterKorisnik(Korisnik korisnik)
        {
            string toInsert = "update Korisnik " +
                              " set naziv ='"+korisnik.Naziv +"', password = '"+korisnik.Password +
                              "' where ID_korisnik = "+korisnik.Id+";";
            InsertSql(toInsert, 0);
        }
        public static void DeleteKorisnik(Korisnik korisnik)
        {
            string toInsert = "delete from Korisnik where ID_korisnik = "+korisnik.Id+";";
            InsertSql(toInsert, 0);
        }
    }
}

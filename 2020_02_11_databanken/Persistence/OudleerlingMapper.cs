using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2020_02_11_databanken.Business;
using MySql.Data.MySqlClient;

namespace _2020_02_11_databanken.Persistence
{
    class OudleerlingMapper
    {
        private string _connectionstring;
        public OudleerlingMapper()
        {
            _connectionstring = "server = localhost; user id = root;password=1234; database=2020_02_11_toets";
        }
        public OudleerlingMapper(string connectionstring)
        {
            _connectionstring = connectionstring;
        }

        public List<Oudleerling> getOudleerlingenFromDB()
        {
            //de connectie met de databank maken
            MySqlConnection conn = new MySqlConnection(_connectionstring);

            //Het SQL-commando definiëren
            string opdracht = "SELECT * FROM 2020_02_11_toets.oudleerlingen;";
            MySqlCommand cmd = new MySqlCommand(opdracht, conn);

            List<Oudleerling> itemLijst = new List<Oudleerling>();
            conn.Open();
            MySqlDataReader dataReader = cmd.ExecuteReader();

            
            while (dataReader.Read())
            {
                Oudleerling item = new Oudleerling(
                Convert.ToInt16(dataReader[0]),
                dataReader[1].ToString(),
                dataReader[2].ToString(),
                dataReader[3].ToString(),
                dataReader[4].ToString(),
                dataReader[5].ToString(),
                dataReader[6].ToString(),
                dataReader[7].ToString(),
                dataReader[8].ToString()
                );
                itemLijst.Add(item);
            }
            conn.Close();
            return itemLijst;
        }
        public void addOudleerlingToDB(Oudleerling item)
        {
            //de connectie met de databank maken
            MySqlConnection conn = new MySqlConnection(_connectionstring);
            //Het SQL-commando definiëren
            string opdracht = "INSERT INTO 2020_02_11_toets.oudleerlingen (Familienaam, Voornaam, richtingkOsh, StraatNr, Postcode, Gemeente, GSMNummer, MailAdres) VALUES(@para0,@para1,@para2,@para3,@para4,@para5,@para6,@para7)";
            
            MySqlCommand cmd = new MySqlCommand(opdracht, conn);
            //voeg de waarden toe, je haalt ze uit het object eval
            cmd.Parameters.AddWithValue("para0", item.IDOudleerling);
            cmd.Parameters.AddWithValue("para1", item.Familienaam);
            cmd.Parameters.AddWithValue("para2", item.Voornaam);
            cmd.Parameters.AddWithValue("para3", item.RicthingkOsh);
            cmd.Parameters.AddWithValue("para4", item.StraatNr);
            cmd.Parameters.AddWithValue("para5", item.Postcode);
            cmd.Parameters.AddWithValue("para6", item.Gemeente);
            cmd.Parameters.AddWithValue("para7", item.MailAdres);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}

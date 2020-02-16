using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2020_02_11_databanken.Business;
using MySql.Data.MySqlClient;
using MySql.Data.MySqlClient;

namespace _2020_02_11_databanken.Persistence
{
    class OudleerlingMetStudieRichtingMapper
    {
        private string _connectionstring;
        public OudleerlingMetStudieRichtingMapper()
        {
            _connectionstring = "server = localhost; user id = root;password=1234; database=2020_02_11_toets";
        }
        public OudleerlingMetStudieRichtingMapper(string connectionstring)
        {
            _connectionstring = connectionstring;
        }

        public List<OudleerlingMetStudieRichting> getOudleerlingMetStudieRichtingFromDB()
        {
            //de connectie met de databank maken
            MySqlConnection conn = new MySqlConnection(_connectionstring);

            //Het SQL-commando definiëren
            string opdracht = "SELECT * FROM 2020_02_11_toets.oudleerlingvolgtstudierichting";
            MySqlCommand cmd = new MySqlCommand(opdracht, conn);

            List<OudleerlingMetStudieRichting> itemLijst = new List<OudleerlingMetStudieRichting>();
            conn.Open();
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                OudleerlingMetStudieRichting item = new OudleerlingMetStudieRichting(
                Convert.ToInt16(dataReader[0]),
                Convert.ToInt16(dataReader[1]),
                Convert.ToDateTime(dataReader[2]),
                Convert.ToBoolean(dataReader[3])
                );
                itemLijst.Add(item);
            }
            conn.Close();
            return itemLijst;
        }
        public List<string> getGevolgdeOpleidingenFromOudleerling(Oudleerling oll)
        {
            //de connectie met de databank maken
            MySqlConnection conn = new MySqlConnection(_connectionstring);

            //Het SQL-commando definiëren
            string opdracht = "select 2020_02_11_toets.studierichtingen.NaamStudierichting, 2020_02_11_toets.studierichtingen.HogeschoolUnif, 2020_02_11_toets.oudleerlingvolgtstudierichting.startDatum," +
                "2020_02_11_toets.oudleerlingvolgtstudierichting.Geslaagd from 2020_02_11_toets.oudleerlingvolgtstudierichting inner join 2020_02_11_toets.studierichtingen on oudleerlingvolgtstudierichting.PKStudierichting = studierichtingen.idStudierichting" +
                " where 2020_02_11_toets.oudleerlingvolgtstudierichting.PKOudleerling = @para0 order by startDatum";
            MySqlCommand cmd = new MySqlCommand(opdracht, conn);
            cmd.Parameters.AddWithValue("para0", oll.IDOudleerling);
            List<string> itemLijst = new List<string>();
            conn.Open();
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                string item = (Convert.ToDateTime(dataReader[2])).ToString() + ": " + (dataReader[0]).ToString() + " aan " + (dataReader[1]).ToString();
                if (Convert.ToBoolean(dataReader[3]))
                    item += " (geslaagd)";
                itemLijst.Add(item);
            }
            conn.Close();
            return itemLijst;
        }
        public void addOudleerlingMetStudierichtingToDB(OudleerlingMetStudieRichting item)
        {
            //de connectie met de databank maken
            MySqlConnection conn = new MySqlConnection(_connectionstring);
            MySqlCommand cmd;
            //Het SQL-commando definiëren
            string opdracht = "INSERT INTO 2020_02_11_toets.oudleerlingvolgtstudierichting (PKOudleerling, PKStudierichting, startDatum, Geslaagd) VALUES (@para0,@para1,@para2,@para3)";
            cmd = new MySqlCommand(opdracht, conn);
            //voeg de waarden toe, je haalt ze uit het object eval
            cmd.Parameters.AddWithValue("para0", item.PKOudleerling);
            cmd.Parameters.AddWithValue("para1", item.PKStudierichting);
            cmd.Parameters.AddWithValue("para2", item.StartDatum);
            cmd.Parameters.AddWithValue("para3", item.Geslaagd);
            
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void adjustStudieInDB(int idOLL, int idStudieRichting, bool geslaagd)
        {
            
            //de connectie met de databank maken
            MySqlConnection conn = new MySqlConnection(_connectionstring);

            //Het SQL-commando definiëren
            string opdracht = "UPDATE 2020_02_11_toets.oudleerlingvolgtstudierichting SET Geslaagd = @para1 WHERE(PKOudleerling = @para2) and(PKStudierichting = @para3);";


            MySqlCommand cmd = new MySqlCommand(opdracht, conn);
            //voeg de waarden toe, je haalt ze uit het object eval            
            cmd.Parameters.AddWithValue("para1", geslaagd);
            cmd.Parameters.AddWithValue("para2", idOLL);
            cmd.Parameters.AddWithValue("para3", idStudieRichting);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}

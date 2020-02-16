using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2020_02_11_databanken.Business;
using MySql.Data.MySqlClient;

namespace _2020_02_11_databanken.Persistence
{
    class StudierichtingMapper
    {
        private string _connectionstring;
        public StudierichtingMapper()
        {
            _connectionstring = "server = localhost; user id = root;password=1234; database=2020_02_11_toets";
        }
        public StudierichtingMapper(string connectionstring)
        {
            _connectionstring = connectionstring;
        }
        
        public List<Studierichting> getStudierichtingenFromDB()
        {
            //de connectie met de databank maken
            MySqlConnection conn = new MySqlConnection(_connectionstring);

            //Het SQL-commando definiëren
            string opdracht = "SELECT * FROM 2020_02_11_toets.studierichtingen";
            MySqlCommand cmd = new MySqlCommand(opdracht, conn);

            List<Studierichting> itemLijst = new List<Studierichting>();
            conn.Open();
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                Studierichting item = new Studierichting(
                Convert.ToInt16(dataReader[0]),
                dataReader[1].ToString(),
                dataReader[2].ToString()
                );
                itemLijst.Add(item);
            }
            conn.Close();
            return itemLijst;
        }
        public void addStudierichtingToDB(Studierichting item)
        {
            //de connectie met de databank maken
            MySqlConnection conn = new MySqlConnection(_connectionstring);

            //Het SQL-commando definiëren
            string opdracht= "INSERT INTO 2020_02_11_toets.studierichtingen (NaamStudierichting, HogeschoolUnif) VALUES(@para0,@para1)";
            

            MySqlCommand cmd = new MySqlCommand(opdracht, conn);
            //voeg de waarden toe, je haalt ze uit het object eval
            cmd.Parameters.AddWithValue("para0", item.NaamStudierichting);
            cmd.Parameters.AddWithValue("para1", item.HogeschoolUnif);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

    }
}

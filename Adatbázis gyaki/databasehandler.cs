using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Adatbázis_gyaki
{
    class databasehandler
    {
        MySqlConnection connection;
        string tablename = "kolbasz";
        public databasehandler(){
            string username = "root";
            string password = "";
            string host = "localhost";
            string dbname = "kolbi";
            string connectionstring = ($"username={username}; password={password}; host={host} ; database={dbname}");
            connection = new MySqlConnection(connectionstring);
            
        
        }

        public void readall()
        {
            
            try
            {
                connection.Open();
                string query = "SELECT * FROM kolbasz";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader read = command.ExecuteReader();
                datastore.kolbaszok.Clear();
                while (read.Read())
                {
                    int id = read.GetInt32(read.GetOrdinal("id"));
                    string fajta = read.GetString(read.GetOrdinal("fajta"));
                    int hossz = read.GetInt32(read.GetOrdinal("hossza"));
                    datastore data = new datastore();
                    data.id = id;
                    data.fajta = fajta;
                    data.hossz = hossz;
                    datastore.kolbaszok.Add(data);
                }
                command.Dispose();
                read.Close();
                connection.Close();
                MessageBox.Show("siker");
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "Error");
            }
        }
        public void remove(datastore data)
        {
            try
            {
                connection.Open();
                string query = $"DELETE * FROM kolbasz where id ={data.id}";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                MessageBox.Show("Gotchu bro");
                connection.Close();
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "Error");
            }
            
            

        }
        public void deleteall()
        {
            
            try
            {
                connection.Open();
                string query = "DELETE * FROM kolbasz";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                MessageBox.Show("Kitoroltel mindent te gorcs");
                connection.Close();
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "Error");
            }
        }
        public void add(datastore onedata)
        {
            datastore data = new datastore();
            try
            {
                connection.Open();
                string query = $"INSERT INTO kolbasz (fajta,hossza) values ('{onedata.fajta}','{onedata.hossz}')";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                MessageBox.Show("Siker az addolásban");
                connection.Close();
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "Error");
            }
        }

    }
}

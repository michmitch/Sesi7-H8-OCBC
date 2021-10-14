using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace Sesi7
{
    public class Config
    {
        string ConnectionString = "";
        public MySqlConnection connection = null;
        public string server = "127.0.0.1";
        public string user = "root";
        public string password = "root";

        DataSet ds;
        DataTable dt;

        public string Table = "user_info";
        public string ConnectionType = "";
        string RecordSource = "";

        DataGridView tempdata;

        public void loginCoba(string username, string pwd)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=root;database=userdata;";
            // Your query,
            string query = "SELECT * FROM `user_info` where username='" + username + "' and `password`='" + pwd+"';";

            // Prepare the connection
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            
            try
            {
                // Open the database
                databaseConnection.Open();

                // Execute the query
                reader = commandDatabase.ExecuteReader();

                // All succesfully executed, now do something

                // IMPORTANT : 
                // If your query returns result, use the following processor :

                if (reader.HasRows)
                {
                    reader.Read();
                    
                    MessageBox.Show($"Success Login As {reader.GetString(2)}");


                    //while (reader.Read())
                    //{
                        //Console.WriteLine($"ID : {reader.GetString(0)}");
                        //Console.WriteLine($"Name : {reader.GetString(1)}");
                        //Console.WriteLine($"Username : {reader.GetString(2)}");
                        //Console.WriteLine($"Password : {reader.GetString(3)}");
                    //    Console.WriteLine(reader.GetString(2));
                    //    // As our database, the array will contain : ID 0, FIRST_NAME 1,LAST_NAME 2, ADDRESS 3
                    //    // Do something with every received database ROW
                    //    string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3) };

                    //}
                }
                else
                {
                    MessageBox.Show("Failed");
                }

                // Finally close the connection
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                // Show any error message.
                MessageBox.Show(ex.Message);
            }
        }

        public Config()
        {

        }

        public void Connect(string db_name)
        {
            try
            {
                ConnectionString = "SERVER=" + server + ";" + "DATABASE=" + db_name + ";" + "UID=" + user + ";" + "PASSWORD=" + password + ";";
                //ConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=root;database=userdata";
                connection = new MySqlConnection(ConnectionString);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void ExecuteSql(string sql_cmd)
        {
            nowquiee(sql_cmd);
        }

        public void nowquiee(string sql_cmd)
        {
            try
            {
                //ConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=root;database=userdata";
                MySqlConnection cs = new MySqlConnection(ConnectionString);
                cs.Open();
                MySqlCommand myc = new MySqlCommand(sql_cmd, cs);
                myc.ExecuteNonQuery();

                cs.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void Execute(string sql_cmd)
        {
            RecordSource = sql_cmd;
            ConnectionType = Table;
            dt = new DataTable(ConnectionType);
            try
            {
                string command = RecordSource.ToUpper();

                MySqlDataAdapter da2 = new MySqlDataAdapter(RecordSource, connection);
                DataSet tempds = new DataSet();
                da2.Fill(tempds, ConnectionType);
                da2.Fill(tempds);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public string Results(int ROW, string COLUMN_NAME)
        {
            try
            {
                return dt.Rows[ROW][COLUMN_NAME].ToString();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return dt.Rows[ROW][COLUMN_NAME].ToString();
            }
        }

        public void ExecuteSelect(string sql_cmd)
        {
            RecordSource = sql_cmd;
            ConnectionType = Table;

            dt = new DataTable(ConnectionType);
            try
            {
                string command = RecordSource.ToUpper();

                MySqlDataAdapter da = new MySqlDataAdapter(RecordSource, connection);
                ds = new DataSet();
                da.Fill(ds, ConnectionType);
                da.Fill(ds);

                tempdata = new DataGridView();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public int Count()
        {
            return dt.Rows.Count;
        }

        //public void SaveUser()
        //{
        //    string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;root;database=userdata;";
        //    //string query = "INSERT INTO `user_info` (`id`, `name`, `username`, `password`) VALUES (NULL, '" +  + "', '" + username + "', '" + password + "';";
        //    // Which could be translated manually to :
        //    // INSERT INTO user(`id`, `first_name`, `last_name`, `address`) VALUES (NULL, 'Bruce', 'Wayne', 'Wayne Manor')

        //    MySqlConnection databaseConnection = new MySqlConnection(connectionString);
        //    MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
        //    commandDatabase.CommandTimeout = 60;

        //    try
        //    {
        //        databaseConnection.Open();
        //        MySqlDataReader myReader = commandDatabase.ExecuteReader();

        //        MessageBox.Show("User succesfully registered");

        //        databaseConnection.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        // Show any error message.
        //        MessageBox.Show(ex.Message);
        //    }
        //}
    }
}

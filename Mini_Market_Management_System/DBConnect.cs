using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Mini_Market_Management_System
{
    internal class DBConnect
    {
        private SqlConnection connection = new SqlConnection(
@"Data Source=(LocalDB)\MSSQLLocalDB;
AttachDbFilename=C:\Users\Hp\source\repos\Mini_Market_Management_System\Mini_Market_Management_System\Marketdb.mdf;
Integrated Security=True");
        public SqlConnection GetCon()
        {
            return connection;
        }
        public void OpenCon()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {

                connection.Open();
            }


        }

        public void CloseCon()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            { 
                connection.Close();
            
             }

        }
    
    }
}

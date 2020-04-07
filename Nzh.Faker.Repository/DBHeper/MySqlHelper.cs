using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nzh.Faker.Repository
{
    public class MySqlHelper
    {
        public static string mysqlconnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["mysqlconn"].ConnectionString;

        public static System.Data.IDbConnection GetConnection()
        {
            var connection = new MySqlConnection(mysqlconnectionString);
            connection.Open();
            return connection;
        }
    }
}

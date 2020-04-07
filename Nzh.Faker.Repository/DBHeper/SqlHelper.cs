using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nzh.Faker.Repository
{
    public class SqlHelper
    {
        static string sqlconnectionString = ConfigurationManager.ConnectionStrings["sqlconn"].ToString();
        public static SqlConnection SqlConnection()
        {
            var connection = new SqlConnection(sqlconnectionString);
            connection.Open();
            return connection;
        }
    }
}

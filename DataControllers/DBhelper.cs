using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataControllers
{
    public class DBhelper
    {
        public static SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection("Data Source=QASIM-DESKTOP\\SQLEXPRESS;Initial Catalog=VPLabFinalQ1;Integrated Security=True");
            return connection;
        }
    }
}

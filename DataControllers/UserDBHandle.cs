using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataControllers
{
    public class UserDBHandle
    {
        public static void Adduser(UserModel user)
        {
            String Query = "insert into Users (Userid, Name, Password, Role) values (@uid, @uname, @upass, @role)";
            using (SqlConnection conn = DBhelper.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmdd = new SqlCommand(Query, conn))
                {
                    cmdd.CommandType = CommandType.Text;
                    cmdd.Parameters.AddWithValue("@uname", user.Username);
                    cmdd.Parameters.AddWithValue("@upass", user.Password);
                    cmdd.Parameters.AddWithValue("@uid", user.Userid);
                    cmdd.Parameters.AddWithValue("@role", user.Role);
                    cmdd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public static bool Login(UserModel user)
        {
            using (SqlConnection conn = DBhelper.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmdd = new SqlCommand("userlgin", conn))
                {
                    cmdd.CommandType = CommandType.StoredProcedure;
                    cmdd.Parameters.AddWithValue("@pass", user.Password);
                    int count = (int)cmdd.ExecuteScalar();
                    conn.Close();
                    return count > 0;
                }
            }
        }

        public static string Getname(string useremail)
        {
            string name = "";
            string query = "select username from Users where email = @email";
            using (SqlConnection conn = DBhelper.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmdd = new SqlCommand(query, conn))
                {
                    cmdd.CommandType = CommandType.Text;
                    cmdd.Parameters.AddWithValue("@email", useremail);
                    SqlDataReader reader = cmdd.ExecuteReader();
                    while (reader.Read())
                    {
                        name = reader["username"].ToString();
                    }
                }
                conn.Close();
                return name;
            }
        }
    }
}

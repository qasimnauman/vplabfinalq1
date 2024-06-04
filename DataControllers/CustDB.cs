using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataControllers
{
    public class CustDB
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

        public static void addcust(CustomersModel cust)
        {
            string Query = "insert into Customers (CustomerID, Name, Email, Phone, Status) values (@cid, @cname, @cemail, @cphone, @status)";
            using (SqlConnection conn = DBhelper.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmdd = new SqlCommand(Query, conn))
                {
                    cmdd.CommandType = CommandType.Text;
                    cmdd.Parameters.AddWithValue("@cname", cust.cname);
                    cmdd.Parameters.AddWithValue("@cemail", cust.email);
                    cmdd.Parameters.AddWithValue("@cid", cust.cid);
                    cmdd.Parameters.AddWithValue("@cphone", cust.phone);
                    cmdd.Parameters.AddWithValue("@status", cust.status);
                    cmdd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public static List<CustomersModel> getcust()
        {
            string Query = "select * from Customers";
            List<CustomersModel> newlist = new List<CustomersModel>();
            using (SqlConnection conn = DBhelper.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmdd = new SqlCommand(Query, conn))
                {
                    cmdd.CommandType = CommandType.Text;
                    SqlDataReader reader = cmdd.ExecuteReader();
                    while (reader.Read())
                    {
                        CustomersModel cust = new CustomersModel();
                        cust.cid = Convert.ToInt32(reader["CustomerID"]);
                        cust.cname = reader["Name"].ToString();
                        cust.email = reader["Email"].ToString();
                        cust.phone = reader["Phone"].ToString();
                        cust.status = reader["Status"].ToString();
                        newlist.Add(cust);
                    }
                }
                conn.Close();
                return newlist;
            }
        }

        public static void updcuststatus(int cid, string sts)
        {
            string Query = "update Customers set Status = @sts where CustomerID = @cid";
            using (SqlConnection conn = DBhelper.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmdd = new SqlCommand(Query, conn))
                {
                    cmdd.CommandType = CommandType.Text;
                    cmdd.Parameters.AddWithValue("@sts", sts);
                    cmdd.Parameters.AddWithValue("@cid", cid);
                    cmdd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
    }
}

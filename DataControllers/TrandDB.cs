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
    public class TrandDB
    {
        public static void AddTrans(TransactionsModel book)
        {
            string Query = "insert into Transactions (TransacrtionID, CustomerID, BookID, Type, Date) values (@tid, @cid, @bid, @type, @date)";
            string updatequery = "update Books set Status = @sts where BookID = @bid";
            using (SqlConnection conn = DBhelper.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmdd = new SqlCommand(Query, conn))
                {
                    cmdd.CommandType = CommandType.Text;
                    cmdd.Parameters.AddWithValue("@tid", book.tid);
                    cmdd.Parameters.AddWithValue("@cid", book.cid);
                    cmdd.Parameters.AddWithValue("@bid", book.bid);
                    cmdd.Parameters.AddWithValue("@type", book.type);
                    cmdd.Parameters.AddWithValue("@date", book.date);
                    cmdd.ExecuteNonQuery();
                }

                using (SqlCommand cmdd = new SqlCommand(updatequery, conn))
                {
                    cmdd.CommandType = CommandType.Text;
                    cmdd.Parameters.AddWithValue("@sts", book.type + "ed");
                    cmdd.Parameters.AddWithValue("@bid", book.bid);
                    cmdd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public static void Addreturn(TransactionsModel book)
        {
            string Query = "update into Transactions (TransacrtionID, CustomerID, BookID, Type, Date) values (@tid, @cid, @bid, @type, @date)";
            string updatequery = "update Books set Status = @sts where BookID = @bid";
            using (SqlConnection conn = DBhelper.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmdd = new SqlCommand(Query, conn))
                {
                    cmdd.CommandType = CommandType.Text;
                    cmdd.Parameters.AddWithValue("@tid", book.tid);
                    cmdd.Parameters.AddWithValue("@cid", book.cid);
                    cmdd.Parameters.AddWithValue("@bid", book.bid);
                    cmdd.Parameters.AddWithValue("@type", book.type);
                    cmdd.Parameters.AddWithValue("@date", book.date);
                    cmdd.ExecuteNonQuery();
                }

                using (SqlCommand cmdd = new SqlCommand(updatequery, conn))
                {
                    cmdd.CommandType = CommandType.Text;
                    cmdd.Parameters.AddWithValue("@sts", book.type + "ed");
                    cmdd.Parameters.AddWithValue("@bid", book.bid);
                    cmdd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
    }
}

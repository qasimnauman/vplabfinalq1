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
    public class BookDB
    {
        public static void AddBooks(BooksModel book)
        {
            string Query = "insert into Books (BookID, Title, Author, Year, Status) values (@bid, @title, @author, @year, @status)";
            using (SqlConnection conn = DBhelper.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmdd = new SqlCommand(Query, conn))
                {
                    cmdd.CommandType = CommandType.Text;
                    cmdd.Parameters.AddWithValue("@bid", book.bid);
                    cmdd.Parameters.AddWithValue("@title", book.title);
                    cmdd.Parameters.AddWithValue("@author", book.author);
                    cmdd.Parameters.AddWithValue("@year", book.year);
                    cmdd.Parameters.AddWithValue("@status", book.status);
                    cmdd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public static List<BooksModel> getbooks()
        {
            string Query = "select * from Books";
            List<BooksModel> newlist = new List<BooksModel>();
            using (SqlConnection conn = DBhelper.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmdd = new SqlCommand(Query, conn))
                {
                    cmdd.CommandType = CommandType.Text;
                    SqlDataReader reader = cmdd.ExecuteReader();
                    while (reader.Read())
                    {
                        BooksModel book = new BooksModel();
                        book.bid = Convert.ToInt32(reader["BookID"]);
                        book.title = reader["Title"].ToString();
                        book.author = reader["Author"].ToString();
                        book.status = reader["Status"].ToString();
                        newlist.Add(book);
                    }
                }
                conn.Close();
                return newlist;
            }
        }

        public static List<BooksModel> getavailbooks()
        {
            string Query = "select * from Books where Status = 'available';";
            List<BooksModel> newlist = new List<BooksModel>();
            using (SqlConnection conn = DBhelper.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmdd = new SqlCommand(Query, conn))
                {
                    cmdd.CommandType = CommandType.Text;
                    SqlDataReader reader = cmdd.ExecuteReader();
                    while (reader.Read())
                    {
                        BooksModel book = new BooksModel();
                        book.bid = Convert.ToInt32(reader["BookID"]);
                        book.title = reader["Title"].ToString();
                        book.author = reader["Author"].ToString();
                        book.status = reader["Status"].ToString();
                        newlist.Add(book);
                    }
                }
                conn.Close();
                return newlist;
            }
        }

        public static List<BooksModel> getborrwobooks()
        {
            string Query = "select * from Books where BookID In (select BookID from Transactions where Type = 'borrow')";
            List<BooksModel> newlist = new List<BooksModel>();
            using (SqlConnection conn = DBhelper.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmdd = new SqlCommand(Query, conn))
                {
                    cmdd.CommandType = CommandType.Text;
                    SqlDataReader reader = cmdd.ExecuteReader();
                    while (reader.Read())
                    {
                        BooksModel book = new BooksModel();
                        book.bid = Convert.ToInt32(reader["BookID"]);
                        book.title = reader["Title"].ToString();
                        book.author = reader["Author"].ToString();
                        book.status = reader["Status"].ToString();
                        newlist.Add(book);
                    }
                }
                conn.Close();
                return newlist;
            }
        }

        public static void updatebookstatus(int bid, string sts)
        {
            string Query = "update Books set Status = @sts where BookID = @bid";
            using (SqlConnection conn = DBhelper.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmdd = new SqlCommand(Query, conn))
                {
                    cmdd.CommandType = CommandType.Text;
                    cmdd.Parameters.AddWithValue("@sts", sts);
                    cmdd.Parameters.AddWithValue("@bid", bid);
                    cmdd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
    }
}

using static System.Net.Mime.MediaTypeNames;
using System;
using BibleApplication.Models;
using Microsoft.Data.SqlClient;

namespace BibleApplication.Services
{
    public class VerseDAO
    {

        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bible;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public List<VerseModel> SearchedVerses(string searchTerm, int testament)
        {

            
            List<VerseModel> foundVerses = new List<VerseModel>();

            string sqlStatement;
            if (testament == 1)
                sqlStatement = "SELECT * FROM dbo.t_kjv WHERE t like @Search AND b < 40";
            else if(testament == 2)
                sqlStatement = "SELECT * FROM dbo.t_kjv WHERE t like @Search AND b > 39";
            else
                sqlStatement = "SELECT * FROM dbo.t_kjv WHERE t like @Search";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.AddWithValue("@Search", '%' + searchTerm + '%');

                try
                {  
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        foundVerses.Add(new VerseModel((int)reader[0], GetBookNames().ElementAt((int)reader[1] -1 ), (int)reader[2], (int)reader[3], (string)reader[4]));
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            
           

            }
            return foundVerses;
        }


        public List<string> GetBookNames()
        {
           List<String> bookNames = new List<String>();

            string sqlStatement = "SELECT * FROM dbo.key_english";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);


                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();


                    while(reader.Read())
                    {
                        bookNames.Add((string)reader[1]);

                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


                return bookNames;
            }
        }
    }
}

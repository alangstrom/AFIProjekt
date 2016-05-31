using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace AFIProjekt.Models
{
    public class Movie
    {
        public string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=AFIProjekt;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";

        public int id
        {
            get;
            set;
        }

        public string imdbID
        {
            get;
            set;
        }
        public string getRandomMovie()
        {
            Random random = new Random();
            int movieId = random.Next(0, 10);
            string sqlString = "SELECT imdbID FROM dbo.Movies WHERE id = @movieId";

            SqlConnection dbConnection = new SqlConnection(connectionString);
            SqlCommand dbCommand = new SqlCommand(sqlString, dbConnection);
            dbCommand.Parameters.AddWithValue("@movieId", movieId);
            SqlDataAdapter dbAdapter = new SqlDataAdapter(dbCommand);
            dbConnection.Open();
            string imdbid = (string)dbCommand.ExecuteScalar();
            return imdbid;
        }

    }

}
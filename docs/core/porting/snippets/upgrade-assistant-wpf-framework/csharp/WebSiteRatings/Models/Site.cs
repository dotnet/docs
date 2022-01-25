using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSiteRatings.Models
{
    public class Site
    {
        public string Title;
        public int Rating;
        public string Url;
        public long Id = -1;

        public Site(string title, int rating, string url, long id = -1)
        {
            Title = title;
            Rating = rating;
            Url = url;
            Id = id;
        }

        public void Save()
        {
            using (SqliteConnection connection = Database.OpenConnection())
            {
                connection.Open();

                using (SqliteCommand saveCmd = connection.CreateCommand())
                {
                    if (Id == -1)
                    {
                        saveCmd.CommandText = $"INSERT INTO Sites (Title, Rating, URL) VALUES ($title, $rating, $url);";
                        saveCmd.Parameters.AddWithValue("$title", Title);
                        saveCmd.Parameters.AddWithValue("$rating", Rating);
                        saveCmd.Parameters.AddWithValue("$url", Url);
                        saveCmd.ExecuteNonQuery();

                        saveCmd.CommandText = @"select last_insert_rowid()";
                        Id = (long)saveCmd.ExecuteScalar();
                    }
                    else
                    {
                        saveCmd.CommandText = $"UPDATE Sites SET Title = $title, Rating = $rating, URL = $url WHERE SiteID = $siteId;";
                        saveCmd.Parameters.AddWithValue("$title", Title);
                        saveCmd.Parameters.AddWithValue("$rating", Rating);
                        saveCmd.Parameters.AddWithValue("$url", Url);
                        saveCmd.Parameters.AddWithValue("$siteId", Id);
                        saveCmd.ExecuteNonQuery();
                    }
                }

                connection.Close();
            }
        }

        public void Delete()
        {
            if (Id == -1) throw new InvalidOperationException("Can't delete a site that hasn't been saved.");

            using (SqliteConnection connection = Database.OpenConnection())
            {
                connection.Open();

                using (SqliteCommand saveCmd = connection.CreateCommand())
                {
                    saveCmd.CommandText = $"DELETE FROM Sites WHERE SiteID = $siteId;";
                    saveCmd.Parameters.AddWithValue("$siteId", Id);
                    saveCmd.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}

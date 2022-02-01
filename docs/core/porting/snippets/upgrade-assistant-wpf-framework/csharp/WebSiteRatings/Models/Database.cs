using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace WebSiteRatings.Models
{
    internal class Database
    {
        public static SqliteConnection OpenConnection() =>
            new SqliteConnection(App.Config.GetConnectionString("database"));

        // More code below...

        public static IEnumerable<Site> ReadSites()
        {
            using (SqliteConnection connection =  OpenConnection())
            {
                connection.Open();
                
                using (SqliteCommand readCmd = connection.CreateCommand())
                {
                    readCmd.CommandText = @"SELECT * FROM Sites";
                    foreach (System.Data.Common.DbDataRecord item in readCmd.ExecuteReader(System.Data.CommandBehavior.SequentialAccess))
                    {
                        Site site = new Site(item.GetString(1), (int)item.GetInt64(2), item.GetString(3))
                        {
                            Id = item.GetInt64(0),
                        };

                        yield return site;
                    }
                }

                connection.Close();
            }
        }
    }
}

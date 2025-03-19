// <Snippet1>
using System;
using System.Data.OracleClient;

static class Program
{
    static void Main()
    {
        const string connectionString =
            "Data Source=ThisOracleServer;Integrated Security=yes;";
        const string queryString =
            "SELECT CUSTOMER_ID, NAME FROM DEMO.CUSTOMER";
        using (OracleConnection connection =
                   new(connectionString))
        {
            OracleCommand command = connection.CreateCommand();
            command.CommandText = queryString;

            try
            {
                connection.Open();

                OracleDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"\t{reader[0]}\t{reader[1]}");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
// </Snippet1>

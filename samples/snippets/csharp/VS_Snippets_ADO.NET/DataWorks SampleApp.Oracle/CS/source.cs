// <Snippet1>
using System;
using System.Data;
using System.Data.OracleClient;

class Program
{
    static void Main()
    {
        string connectionString = 
            "Data Source=ThisOracleServer;Integrated Security=yes;";
        string queryString =
            "SELECT CUSTOMER_ID, NAME FROM DEMO.CUSTOMER";
        using (OracleConnection connection =
                   new OracleConnection(connectionString))
        {
            OracleCommand command = connection.CreateCommand();
            command.CommandText = queryString;

            try
            {
                connection.Open();

                OracleDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine("\t{0}\t{1}",
                        reader[0], reader[1]);
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


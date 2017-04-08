using System;
using System.Data;
using System.Data.SqlClient;

namespace SqlPrepareCS
{
    class Program
    {
        static void Main()
        {
            string connectionString = "Persist Security Info=False;Integrated Security=SSPI;database=Northwind;server=(local)";
            SqlCommandPrepareEx(connectionString);
            Console.ReadLine();

        }
        // <Snippet1>
        private static void SqlCommandPrepareEx(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(null, connection);

                // Create and prepare an SQL statement.
                command.CommandText =
                    "INSERT INTO Region (RegionID, RegionDescription) " +
                    "VALUES (@id, @desc)";
                SqlParameter idParam = new SqlParameter("@id", SqlDbType.Int, 0);
                SqlParameter descParam = 
                    new SqlParameter("@desc", SqlDbType.Text, 100);
                idParam.Value = 20;
                descParam.Value = "First Region";
                command.Parameters.Add(idParam);
                command.Parameters.Add(descParam);

                // Call Prepare after setting the Commandtext and Parameters.
                command.Prepare();
                command.ExecuteNonQuery();

                // Change parameter values and call ExecuteNonQuery.
                command.Parameters[0].Value = 21;
                command.Parameters[1].Value = "Second Region";
                command.ExecuteNonQuery();
            }
        }
        // </Snippet1>
    }
}

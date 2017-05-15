// <Snippet1>
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;

class Program
{
    private static SqlCommand m_rCommand;

    public static SqlCommand Command
    {
        get { return m_rCommand; }
        set { m_rCommand = value; }
    }

    public static void Thread_Cancel()
    {
        Command.Cancel();
    }

    static void Main()
    {
        string connectionString = GetConnectionString();
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                Command = connection.CreateCommand();
                Command.CommandText = "DROP TABLE TestCancel";
                try
                {
                    Command.ExecuteNonQuery();
                }
                catch { }

                Command.CommandText = "CREATE TABLE TestCancel(co1 int, co2 char(10))";
                Command.ExecuteNonQuery();
                Command.CommandText = "INSERT INTO TestCancel VALUES (1, '1')";
                Command.ExecuteNonQuery();

                Command.CommandText = "SELECT * FROM TestCancel";
                SqlDataReader reader = Command.ExecuteReader();

                Thread rThread2 = new Thread(new ThreadStart(Thread_Cancel));
                rThread2.Start();
                rThread2.Join();

                reader.Read();
                System.Console.WriteLine(reader.FieldCount);
                reader.Close();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    static private string GetConnectionString()
    {
        // To avoid storing the connection string in your code, 
        // you can retrieve it from a configuration file.
        return "Data Source=(local);Initial Catalog=AdventureWorks;"
            + "Integrated Security=SSPI";
    }
}
// </Snippet1>

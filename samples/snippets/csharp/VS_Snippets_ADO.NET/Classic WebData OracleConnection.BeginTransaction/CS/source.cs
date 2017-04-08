using System;
using System.Data;
using System.Data.OracleClient;

class Class1
{
    static void Main()
    {
    }

    // <Snippet1>
    public void RunOracleTransaction(string connectionString)
    {
        using (OracleConnection connection = new OracleConnection(connectionString))
        {
            connection.Open();

            OracleCommand command = connection.CreateCommand();
            OracleTransaction transaction;

            // Start a local transaction
            transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
            // Assign transaction object for a pending local transaction
            command.Transaction = transaction;

            try
            {
                command.CommandText = 
                    "INSERT INTO Dept (DeptNo, Dname, Loc) values (50, 'TECHNOLOGY', 'DENVER')";
                command.ExecuteNonQuery();
                command.CommandText = 
                    "INSERT INTO Dept (DeptNo, Dname, Loc) values (60, 'ENGINEERING', 'KANSAS CITY')";
                command.ExecuteNonQuery();
                transaction.Commit();
                Console.WriteLine("Both records are written to database.");
            }
            catch (Exception e)
            {
                transaction.Rollback();
                Console.WriteLine(e.ToString());
                Console.WriteLine("Neither record was written to database.");
            }
        }
    }
    // </Snippet1>
}



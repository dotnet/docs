using System.Data;
using System.Data.OleDb;

namespace ca2100
{
    //<snippet1>
    public class OleDbQueries
    {
        public object UnsafeQuery(
           string connection, string name, string password)
        {
            using OleDbConnection someConnection = new(connection);
            using OleDbCommand someCommand = new();
            someCommand.Connection = someConnection;

            someCommand.CommandText = "SELECT AccountNumber FROM Users " +
               "WHERE Username='" + name +
               "' AND Password='" + password + "'";

            someConnection.Open();
            object accountNumber = someCommand.ExecuteScalar();
            someConnection.Close();
            return accountNumber;
        }

        public object SaferQuery(
           string connection, string name, string password)
        {
            using OleDbConnection someConnection = new(connection);
            using OleDbCommand someCommand = new();
            someCommand.Connection = someConnection;

            someCommand.Parameters.Add(
               "@username", OleDbDbType.NChar).Value = name;
            someCommand.Parameters.Add(
               "@password", OleDbDbType.NChar).Value = password;
            someCommand.CommandText = "SELECT AccountNumber FROM Users " +
               "WHERE Username=@username AND Password=@password";

            someConnection.Open();
            object accountNumber = someCommand.ExecuteScalar();
            someConnection.Close();
            return accountNumber;
        }
    }

    class MaliciousCode
    {
        static void Main2100(string[] args)
        {
            OleDbQueries queries = new OleDbQueries();
            queries.UnsafeQuery(args[0], "' OR 1=1 --", "[PLACEHOLDER]");
            // Resultant query (which is always true):
            // SELECT AccountNumber FROM Users WHERE Username='' OR 1=1

            queries.SaferQuery(args[0], "' OR 1=1 --", "[PLACEHOLDER]");
            // Resultant query (notice the additional single quote character):
            // SELECT AccountNumber FROM Users WHERE Username=''' OR 1=1 --'
            //                                   AND Password='[PLACEHOLDER]'
        }
    }
    //</snippet1>
}

using System.Data;
using System.Data.SqlClient;

namespace ca2100
{
    //<snippet1>
    public class SqlQueries
    {
        public object UnsafeQuery(
           string connection, string name, string password)
        {
            SqlConnection someConnection = new SqlConnection(connection);
            SqlCommand someCommand = new SqlCommand();
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
            SqlConnection someConnection = new SqlConnection(connection);
            SqlCommand someCommand = new SqlCommand();
            someCommand.Connection = someConnection;

            someCommand.Parameters.Add(
               "@username", SqlDbType.NChar).Value = name;
            someCommand.Parameters.Add(
               "@password", SqlDbType.NChar).Value = password;
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
            SqlQueries queries = new SqlQueries();
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

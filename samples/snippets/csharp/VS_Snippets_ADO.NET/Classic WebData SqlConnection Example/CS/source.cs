// <Snippet1>
using System;
using System.Data;

namespace IDbConnectionSample {
   class Program {
      static void Main(string[] args) {
         IDbConnection connection;

         // First use a SqlClient connection
         connection = new System.Data.SqlClient.SqlConnection(@"Server=(localdb)\V11.0");
         Console.WriteLine("SqlClient\r\n{0}", GetServerVersion(connection));
         connection = new System.Data.SqlClient.SqlConnection(@"Server=(local);Integrated Security=true");
         Console.WriteLine("SqlClient\r\n{0}", GetServerVersion(connection));

         // Call the same method using ODBC
         // NOTE: LocalDB requires the SQL Server 2012 Native Client ODBC driver
         connection = new System.Data.Odbc.OdbcConnection(@"Driver={SQL Server Native Client 11.0};Server=(localdb)\v11.0");
         Console.WriteLine("ODBC\r\n{0}", GetServerVersion(connection));
         connection = new System.Data.Odbc.OdbcConnection(@"Driver={SQL Server Native Client 11.0};Server=(local);Trusted_Connection=yes");
         Console.WriteLine("ODBC\r\n{0}", GetServerVersion(connection));

         // Call the same method using OLE DB
         connection = new System.Data.OleDb.OleDbConnection(@"Provider=SQLNCLI11;Server=(localdb)\v11.0;Trusted_Connection=yes;");
         Console.WriteLine("OLE DB\r\n{0}", GetServerVersion(connection));
         connection = new System.Data.OleDb.OleDbConnection(@"Provider=SQLNCLI11;Server=(local);Trusted_Connection=yes;");
         Console.WriteLine("OLE DB\r\n{0}", GetServerVersion(connection));
         }

      public static string GetServerVersion(IDbConnection connection) {
         // Ensure that the connection is opened (otherwise executing the command will fail)
         ConnectionState originalState = connection.State;
         if (originalState != ConnectionState.Open)
            connection.Open();
         try {
            // Create a command to get the server version
            // NOTE: The query's syntax is SQL Server specific
            IDbCommand command = connection.CreateCommand();
            command.CommandText = "SELECT @@version";
            return (string)command.ExecuteScalar();
         }
         finally {
            // Close the connection if that's how we got it
            if (originalState == ConnectionState.Closed)
               connection.Close();
         }
      }
   }
}
// </Snippet1>
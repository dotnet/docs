// <Snippet1>
using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.Odbc;

class Program {
   static void Main(string[] args) {

      // string connectionTypeName = "SqlClient";
      // string connectionString = @"Data Source=(local);Initial Catalog=AdventureWorks;Integrated Security=SSPI";

      // string connectionTypeName = "Odbc";
      // string connectionString = @"Driver={SQL Server Native Client 11.0};Server=(local);Database=AdventureWorks2012;Trusted_Connection=Yes";

      string connectionTypeName = "OleDb";
      string connectionString = @"Provider=SQLNCLI11;Data Source=(local);Initial Catalog=AdventureWorks;Integrated Security=SSPI";

      using (IDbConnection connection = DatabaseConnectionFactory.GetConnection(connectionTypeName, connectionString)) {
         IDbCommand command = connection.CreateCommand();
         command.Connection = connection;

         // these 2 queries are executed as a single batch and return 2 separate results
         command.CommandText = "SELECT CountryRegionCode, Name FROM Person.CountryRegion;" + "SELECT CountryRegionCode, StateProvinceCode, Name, StateProvinceID FROM Person.StateProvince;";

         connection.Open();

         using (IDataReader reader = command.ExecuteReader()) {

            // process the first result
            displayCountryRegions(reader);

            // use NextResult to move to the second result and verify it is returned
            if (!reader.NextResult())
               throw new InvalidOperationException("Expected second result (StateProvinces) but only one was returned");

            // process the second result
            displayStateProvinces(reader);

            reader.Close();
         }

         connection.Close();
      }
   }

   static void displayCountryRegions(IDataReader reader) {
      if (reader.FieldCount != 2)
         throw new InvalidOperationException("First resultset (CountryRegions) must contain exactly 2 columns");

      while (reader.Read()) {
         Console.WriteLine("CountryRegionCode={0}, Name={1}"
             , reader.GetString(reader.GetOrdinal("CountryRegionCode"))
             , reader.GetString(reader.GetOrdinal("Name")));
      }
   }

   static void displayStateProvinces(IDataReader reader) {
      if (reader.FieldCount != 4)
         throw new InvalidOperationException("Second resultset (StateProvinces) must contain exactly 4 columns");

      while (reader.Read()) {
         Console.WriteLine("CountryRegionCode={0}, StateProvinceCode={1}, Name={2}, StateProvinceID={3}"
             , reader.GetString(reader.GetOrdinal("CountryRegionCode"))
             , reader.GetString(reader.GetOrdinal("StateProvinceCode"))
             , reader.GetString(reader.GetOrdinal("Name"))
             , reader.GetInt32(reader.GetOrdinal("StateProvinceID")));
      }
   }

   class DatabaseConnectionFactory {
      static SqlConnection GetSqlConnection(string connectionString) {
         return new SqlConnection(connectionString);
      }

      static OdbcConnection GetOdbcConnection(string connectionString) {
         return new OdbcConnection(connectionString);
      }

      static OleDbConnection GetOleDbConnection(string connectionString) {
         return new OleDbConnection(connectionString);
      }

      public static IDbConnection GetConnection(string connectionTypeName, string connectionString) {
         switch (connectionTypeName) {
            case "SqlClient":
               return GetSqlConnection(connectionString);
            case "Odbc":
               return GetOdbcConnection(connectionString);
            case "OleDb":
               return GetOleDbConnection(connectionString);
            default:
               throw new ArgumentException("Value must be SqlClient, Odbc or OleDb", "connectionTypeName");
         }
      }
   }
}
// </Snippet1>
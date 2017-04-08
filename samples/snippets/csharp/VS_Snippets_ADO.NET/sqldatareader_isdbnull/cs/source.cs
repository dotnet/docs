// <Snippet1>
using System;
using System.Data;
using System.Data.SqlClient;

class Program {
   static void Main(string[] args) {

      using (var connection = new SqlConnection(@"Data Source=(local);Initial Catalog=AdventureWorks2012;Integrated Security=SSPI")) {
         var command = new SqlCommand("SELECT p.FirstName, p.MiddleName, p.LastName FROM HumanResources.Employee AS e" +
                                 " JOIN Person.Person AS p ON e.BusinessEntityID = p.BusinessEntityID;", connection);
         connection.Open();
         var reader = command.ExecuteReader();
         while (reader.Read()) {
            Console.Write(reader.GetString(reader.GetOrdinal("FirstName")));
            // display middle name only of not null
            if (!reader.IsDBNull(reader.GetOrdinal("MiddleName")))
               Console.Write(" {0}", reader.GetString(reader.GetOrdinal("MiddleName")));
            Console.WriteLine(" {0}", reader.GetString(reader.GetOrdinal("LastName")));
         }
         connection.Close();
      }
   }
}
// </Snippet1>
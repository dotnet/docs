using System;
using System.Data;
using System.Data.OleDb;

class Class1
{
   static void Main()
   {
      string x = "Provider=SQLOLEDB;Data Source=dschwart3;Initial Catalog=AdventureWorks;"
          + "Integrated Security=SSPI";
      OpenConnection(x);
      ChangeDatabaseConnection(x);
      Console.ReadLine();
   }

   // <Snippet1>
   static void OpenConnection(string connectionString)
   {
      using (OleDbConnection connection = new OleDbConnection(connectionString))
      {
         try
         {
            connection.Open();
            Console.WriteLine("ServerVersion: {0} \nDatabase: {1}",
                connection.ServerVersion, connection.Database);
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex.Message);
         }
         // The connection is automatically closed when the
         // code exits the using block.
      }
   }
   // </Snippet1>

   // <Snippet2>
   static void ChangeDatabaseConnection(string connectionString)
   {
      using (OleDbConnection connection = new OleDbConnection(connectionString))
      {
         try
         {
            connection.Open();
            Console.WriteLine("ServerVersion: {0} \nDatabase: {1}",
                connection.ServerVersion, connection.Database);
            
            connection.ChangeDatabase("Northwind");
            Console.WriteLine("ServerVersion: {0} \nDatabase: {1}",
               connection.ServerVersion, connection.Database);

         }
         catch (Exception ex)
         {
            Console.WriteLine(ex.Message);
         }
         // The connection is automatically closed when the
         // code exits the using block.
      }
   }
   // </Snippet2>
}
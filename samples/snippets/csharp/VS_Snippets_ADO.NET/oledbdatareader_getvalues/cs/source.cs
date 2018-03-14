// <Snippet1>
using System;
using System.Data;
using System.Data.OleDb;

class Class1 {
   public static void Main() {
      using (OleDbConnection connection =
         new OleDbConnection("Provider=SQLOLEDB;Data Source=(local);Integrated Security=SSPI;Initial Catalog=Northwind")) {

         object[] meta = new object[10];
         bool read;

         OleDbCommand command = new OleDbCommand("select * from Region", connection);

         connection.Open();
         OleDbDataReader reader = command.ExecuteReader();

         if (reader.Read() == true) {
            do {
               int NumberOfColums = reader.GetValues(meta);

               for (int i = 0; i < NumberOfColums; i++)
                  Console.Write("{0} ", meta[i].ToString());

               Console.WriteLine();
               read = reader.Read();
            } while (read == true);
         }
         reader.Close();
      }
   }
}
// </Snippet1>
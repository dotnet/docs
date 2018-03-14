// <Snippet1>
using System;
using System.Data;
using System.Data.Odbc;

class Class1 {
   public static void Main() {

      using (OdbcConnection connection =
         new OdbcConnection("Driver={Microsoft Access Driver (*.mdb)};DBQ=C:\\Northwind.mdb")) {

         object[] meta = new object[10];
         bool read;

         OdbcCommand command = new OdbcCommand("select * from Shippers", connection);
         connection.Open();
         OdbcDataReader reader = command.ExecuteReader();

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
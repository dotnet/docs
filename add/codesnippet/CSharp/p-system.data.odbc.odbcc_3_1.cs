 public void CreateOdbcConnection() 
 {
     string connectionString = "Driver={SQL Native Client};Server=(local);Trusted_Connection=Yes;Database=AdventureWorks;";

     using (OdbcConnection connection = new OdbcConnection(connectionString))
     {
         connection.Open();
         Console.WriteLine("ServerVersion: " + connection.ServerVersion
             + "\nDatabase: " + connection.Database);

         // The connection is automatically closed at 
         // the end of the Using block.
     }
 }
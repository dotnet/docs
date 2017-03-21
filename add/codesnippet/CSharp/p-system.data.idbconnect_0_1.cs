 public void CreateOleDbConnection(){
    OleDbConnection connection = new OleDbConnection();
    connection.ConnectionString = 
        "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Northwind.mdb";
    Console.WriteLine("Connection State: " + connection.State.ToString());
 }
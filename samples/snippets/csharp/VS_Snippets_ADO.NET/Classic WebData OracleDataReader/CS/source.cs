using System;
using System.Data;
using System.Data.OracleClient;

class Class1
{
    static void Main()
    {
    }

    // <Snippet1>
    public void ReadData(string connectionString)
    {
       string queryString = "SELECT EmpNo, EName FROM Emp";
       using (OracleConnection connection = new OracleConnection(connectionString))
       {
          OracleCommand command = new OracleCommand(queryString, connection);
          connection.Open();
          using(OracleDataReader reader = command.ExecuteReader())
          {
	         // Always call Read before accessing data.
        	 while (reader.Read())
        	 {
            	Console.WriteLine(reader.GetInt32(0) + ", " + reader.GetString(1));
        	 }
          }
       }
    }
    // </Snippet1>
}





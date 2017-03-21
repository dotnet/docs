[Microsoft.SqlServer.Server.SqlProcedure]
public static void CreateNewRecord()
{

   // Variables.
   SqlDataRecord record;    
      
   // Create a new record with the column metadata. The constructor is 
   // able to accept a variable number of parameters. 
   record = new SqlDataRecord(new SqlMetaData[] { new SqlMetaData("Column1", SqlDbType.NVarChar, 12), 
                                                  new SqlMetaData("Column2", SqlDbType.Int), 
                                                  new SqlMetaData("Column3", SqlDbType.DateTime) });

   // Set the record fields.
   record.SetString(0, "Hello World!");
   record.SetInt32(1, 42);
   record.SetDateTime(2, DateTime.Now);

   // Send the record to the calling program.
   SqlContext.Pipe.Send(record);
}
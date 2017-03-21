[Microsoft.SqlServer.Server.SqlProcedure]
public static void CreateNewRecord()
{
   // Variables.
   SqlMetaData column1Info;
   SqlMetaData column2Info;
   SqlMetaData column3Info;
   SqlDataRecord record;

   // Create the column metadata.
   column1Info = new SqlMetaData("Column1", SqlDbType.NVarChar, 12);
   column2Info = new SqlMetaData("Column2", SqlDbType.Int);
   column3Info = new SqlMetaData("Column3", SqlDbType.DateTime);
      
   // Create a new record with the column metadata.      
   record = new SqlDataRecord(new SqlMetaData[] { column1Info, 
                                                  column2Info, 
                                                  column3Info });

   // Set the record fields.
   record.SetString(0, "Hello World!");
   record.SetInt32(1, 42);
   record.SetDateTime(2, DateTime.Now);

   // Send the record to the calling program.
   SqlContext.Pipe.Send(record);
}
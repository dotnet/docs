using System;
using System.Data;
using System.Data.Sql;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;



public sealed partial class SqlDataRecordTester
{
   private SqlDataRecordTester()
   {
   }

[Microsoft.SqlServer.Server.SqlProcedure]
public static void CallTestMethods()
{
   CreateNewRecord();
   CreateNewRecord1();

}

//<Snippet1>
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
//</Snippet1>

//
public static void CreateNewRecord1()
{

//<Snippet2>
// Variables.
SqlMetaData column1Info;
SqlMetaData column2Info;
SqlDataRecord record;

// Create the column metadata.
column1Info = new SqlMetaData("Column1", SqlDbType.NVarChar, 12);
column2Info = new SqlMetaData("Column2", SqlDbType.Int);

// Create a new record with the column metadata.      
record = new SqlDataRecord(new SqlMetaData[] { column1Info, 
                                                  column2Info });
//</Snippet2>

// Set the record fields.
record.SetString(0, "Hello World!");
record.SetInt32(1, 42);

// Send the record to the calling program.
SqlContext.Pipe.Send(record);
   
}
//



}

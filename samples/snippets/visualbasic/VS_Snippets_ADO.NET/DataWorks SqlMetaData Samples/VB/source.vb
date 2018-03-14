Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.SqlServer.Server

Partial Public Class StoredProcedures

' <Snippet1>
<Microsoft.SqlServer.Server.SqlProcedure()> _
Public Shared Sub CreateNewRecord()

   ' Variables.
   Dim column1Info As SqlMetaData 
   Dim column2Info As SqlMetaData
   Dim column3Info As SqlMetaData
   Dim record As SqlDataRecord

   ' Create the column metadata.
   column1Info = new SqlMetaData("Column1", SqlDbType.NVarChar, 12)
   column2Info = new SqlMetaData("Column2", SqlDbType.Int)
   column3Info = new SqlMetaData("Column3", SqlDbType.DateTime)

   ' Create a new record with the column metadata.      
   record = new SqlDataRecord(new SqlMetaData() { column1Info, _
                                                  column2Info, _
                                                  column3Info })

   ' Set the record fields.
   record.SetString(0, "Hello World!")
   record.SetInt32(1, 42)
   record.SetDateTime(2, DateTime.Now)

   ' Send the record to the calling program.
   SqlContext.Pipe.Send(record)

End Sub
'</Snippet1>

'<Snippet2>
Public Shared Sub CreateSqlMetaData1()

   Dim columnInfo As SqlMetaData
   columnInfo = new SqlMetaData("ColumnName", SqlDbType.NVarChar, 12)

End Sub
'</Snippet2>

'<Snippet3>
Public Shared Sub CreateSqlMetaData2()

   Dim columnInfo As SqlMetaData
   columnInfo = new SqlMetaData("ColumnName", SqlDbType.Int)

End Sub
'</Snippet3>

End Class
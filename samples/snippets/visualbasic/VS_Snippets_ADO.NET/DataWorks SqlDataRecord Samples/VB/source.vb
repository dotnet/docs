Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.SqlServer.Server

Partial Public Class SqlDataRecordTester

<Microsoft.SqlServer.Server.SqlProcedure()> _
Public Shared Sub CallTestMethods()

   CreateNewRecord()
   CreateNewRecord1()

End Sub

' <Snippet1>
<Microsoft.SqlServer.Server.SqlProcedure()> _
Public Shared Sub CreateNewRecord()

   ' Variables.
   Dim record As SqlDataRecord
   
   ' Create a new record with the column metadata.  The constructor is 
   ' able to accept a variable number of parameters.     
   record = New SqlDataRecord(New SqlMetaData() {New SqlMetaData("Column1", SqlDbType.NVarChar, 12), _
                                                 New SqlMetaData("Column2", SqlDbType.Int), _
                                                 New SqlMetaData("Column3", SqlDbType.DateTime)})

   ' Set the record fields.
   record.SetString(0, "Hello World!")
   record.SetInt32(1, 42)
   record.SetDateTime(2, DateTime.Now)

   ' Send the record to the calling program.
   SqlContext.Pipe.Send(record)

End Sub
'</Snippet1>


Public Shared Sub CreateNewRecord1()

'<Snippet2>
' Variables.
Dim column1Info As SqlMetaData 
Dim column2Info As SqlMetaData
Dim record As SqlDataRecord

' Create the column metadata.
column1Info = new SqlMetaData("Column1", SqlDbType.NVarChar, 12)
column2Info = new SqlMetaData("Column2", SqlDbType.Int)

' Create a new record with the column metadata.      
record = new SqlDataRecord(new SqlMetaData() { column1Info, _
                                               column2Info })
'</Snippet2>

' Set the record fields.
record.SetString(0, "Hello World!")
record.SetInt32(1, 42)

' Send the record to the calling program.
SqlContext.Pipe.Send(record)

End Sub




End Class
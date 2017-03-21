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
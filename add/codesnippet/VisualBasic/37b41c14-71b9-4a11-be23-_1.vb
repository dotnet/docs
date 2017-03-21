    Public Overrides Function PrepareRecord(ByVal log As LogRecord) As Boolean 
        
        ' Check the validity of the record.
        If log Is Nothing Then
            Return True
        End If
        Dim record As [Object]() = log.Record
        
        If record Is Nothing Then
            Return True
        End If
        If record.Length <> 2 Then
            Return True
        End If 
        ' The record is valid.
        receivedPrepareRecord = True
        Return False
    
    End Function 'PrepareRecord
    
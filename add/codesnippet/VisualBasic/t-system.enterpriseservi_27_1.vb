    Public Overrides Function AbortRecord(ByVal log As LogRecord) As Boolean 
        
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
        ' Extract old account data from the record.
        Dim filename As String = CStr(record(0))
        Dim balance As Integer = Fix(record(1))
        
        ' Restore the old state of the account.
        AccountManager.WriteAccountBalance(filename, balance)
        
        Return False
    
    End Function 'AbortRecord
    
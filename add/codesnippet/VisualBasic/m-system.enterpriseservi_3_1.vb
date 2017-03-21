    Public Overrides Function EndPrepare() As Boolean 
        ' Allow the transaction to proceed onlyif we have received a prepare record.
        If receivedPrepareRecord Then
            Return True
        Else
            Return False
        End If
    
    End Function 'EndPrepare
    
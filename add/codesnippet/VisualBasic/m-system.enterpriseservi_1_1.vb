        ' Create a record of previous account status, and deliver it to the clerk.
        Dim balance As Integer = AccountManager.ReadAccountBalance(Filenam)
        
        Dim record(1) As [Object]
        record(0) = filename
        record(1) = balance
        
        clerk.WriteLogRecord(record)
        clerk.ForceLog()
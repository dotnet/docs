        ' Commit or abort the transaction 
        If commit Then
            ContextUtil.SetComplete()
        Else
            ContextUtil.SetAbort()
        End If
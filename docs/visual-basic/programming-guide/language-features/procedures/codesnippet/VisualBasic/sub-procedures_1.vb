    Sub tellOperator(ByVal task As String)
        Dim stamp As Date
        stamp = TimeOfDay()
        MsgBox("Starting " & task & " at " & CStr(stamp))
    End Sub
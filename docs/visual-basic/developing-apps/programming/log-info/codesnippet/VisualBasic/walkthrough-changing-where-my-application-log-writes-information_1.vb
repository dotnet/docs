    Public Sub DisplayStrongName()
        Dim t As Type = GetType(Logging.FileLogTraceListener)
        MsgBox(t.FullName & ", " & t.Assembly.FullName)
    End Sub
    Public Sub DisplaySimpleListenerStrongName()
        Dim t As Type = GetType(SimpleListener)
        MsgBox(t.FullName & ", " & t.Assembly.FullName)
    End Sub
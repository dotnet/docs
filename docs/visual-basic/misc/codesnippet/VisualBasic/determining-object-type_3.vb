    Sub CheckType(ByVal InParam As Object)
        ' Both If statements evaluate to True when an
        ' Integer is passed to this procedure.
        If TypeOf InParam Is Object Then
            MsgBox("InParam is an Object")
        End If
        If TypeOf InParam Is Integer Then
            MsgBox("InParam is an Integer")
        End If
    End Sub
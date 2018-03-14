        Dim o1, o2 As New Object
        If Not o1 Is o2 Then MsgBox("o1 and o2 do not refer to the same instance.")
        If o1 IsNot o2 Then MsgBox("o1 and o2 do not refer to the same instance.")
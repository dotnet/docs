    Dim n() As Long = {10, 20, 30, 40}
    Call increase(n)
    MsgBox("After increase(n): " & CStr(n(0)) & ", " & 
        CStr(n(1)) & ", " & CStr(n(2)) & ", " & CStr(n(3)))
    Call replace(n)
    MsgBox("After replace(n): " & CStr(n(0)) & ", " & 
        CStr(n(1)) & ", " & CStr(n(2)) & ", " & CStr(n(3)))
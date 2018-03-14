Dim objA, objB, objC As Object
objA = My.User
objB = New ApplicationServices.User
objC = My.User
MsgBox("objA different from objB? " & CStr(objA IsNot objB))
MsgBox("objA identical to objC? " & CStr(objA Is objC))
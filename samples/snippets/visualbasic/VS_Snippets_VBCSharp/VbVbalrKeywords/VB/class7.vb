

' * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
Module Module1

    Sub Main()


    End Sub

'<Snippet13>
Function runningTotal(ByVal num As Integer) As Integer
    Static applesSold As Integer
    applesSold = applesSold + num
    Return applesSold
End Function
'</Snippet13>

Sub IdenticalReferences
'<Snippet14>
Dim objA, objB, objC As Object
objA = My.User
objB = New ApplicationServices.User
objC = My.User
MsgBox("objA different from objB? " & CStr(objA IsNot objB))
MsgBox("objA identical to objC? " & CStr(objA Is objC))
'</Snippet14>
End Sub
End Module


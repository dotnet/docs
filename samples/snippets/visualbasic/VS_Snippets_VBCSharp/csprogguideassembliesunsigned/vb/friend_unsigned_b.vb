Imports Microsoft.VisualBasic
'<Snippet2>
' friend_unsigned_B.vb
' Compile with: 
' Vbc /r:friend_unsigned_A.dll friend_unsigned_B.vb
Module Module1
    Sub Main()
        ' Access a Friend type.
        Dim inst1 As New Class1()
        inst1.Test()

        Dim inst2 As New Class2()
        ' Access a Friend member of a public type.
        inst2.Test()

        System.Console.ReadLine()
    End Sub
End Module
'</Snippet2>
Imports Microsoft.VisualBasic
'<Snippet1>
' friend_unsigned_A.vb
' Compile with: 
' Vbc /target:library friend_unsigned_A.vb
Imports System.Runtime.CompilerServices
Imports System

<Assembly: InternalsVisibleTo("friend_unsigned_B")> 

' Friend type.
Friend Class Class1
    Public Sub Test()
        Console.WriteLine("Class1.Test")
    End Sub
End Class

' Public type with Friend member.
Public Class Class2
    Friend Sub Test()
        Console.WriteLine("Class2.Test")
    End Sub
End Class
'</Snippet1>
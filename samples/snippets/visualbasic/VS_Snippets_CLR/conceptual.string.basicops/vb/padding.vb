Option Strict On

' <snippet2>
Imports System

Class Example
    Public Shared Sub Main()
        PadLeft()
        PadRight()
    End Sub

    Public Shared Sub PadLeft()
        ' <snippet3>
        Dim MyString As String = "Hello World!"
        Console.WriteLine(MyString.PadLeft(20, "-"c))
        ' </snippet3>
    End Sub

    Public Shared Sub PadRight()
        ' <snippet4>
        Dim MyString As String = "Hello World!"
        Console.WriteLine(MyString.PadRight(20, "-"c))
        ' </snippet4>
    End Sub
End Class
' </snippet2>

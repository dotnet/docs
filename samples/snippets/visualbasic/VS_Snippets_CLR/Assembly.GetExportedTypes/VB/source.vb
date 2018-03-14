'<Snippet1>
Imports System
Imports System.Reflection

Public Class Example
    Public Shared Sub Main()
        For Each t As Type In GetType(Example).Assembly.GetExportedTypes()
            Console.WriteLine(t)
        Next
    End Sub
End Class

Public Class PublicClass
    Public Class PublicNestedClass
    End Class

    Protected Class ProtectedNestedClass
    End Class

    Friend Class FriendNestedClass
    End Class

    Private Class PrivateNestedClass
    End Class
End Class

Friend Class FriendClass
    Public Class PublicNestedClass
    End Class

    Protected Class ProtectedNestedClass
    End Class

    Friend Class FriendNestedClass
    End Class

    Private Class PrivateNestedClass
    End Class
End Class
'</Snippet1>

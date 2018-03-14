' <Snippet1>
Imports System
Imports System.Reflection
Imports Microsoft.VisualBasic

Public MustInherit Class dtype

    Public MustInherit Class MyClassA
        Public MustOverride Function m() As Integer
    End Class

    Public MustInherit Class MyClassB
        Inherits MyClassA
    End Class

    Public Shared Sub Main()
        Console.WriteLine("The declaring type of m is {0}.", _
           GetType(MyClassB).GetMethod("m").DeclaringType)
    End Sub
End Class
' </Snippet1>
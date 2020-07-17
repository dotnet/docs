' Visual Basic .NET Document
Option Strict On

' <Snippet25>
<Assembly: CLSCompliant(True)>

Public Class Group
    Private members() As String

    Public Sub New(ParamArray memberList() As String)
        members = memberList
    End Sub

    Public Overrides Function ToString() As String
        Return String.Join(", ", members)
    End Function
End Class

Module Example
    Public Sub Main()
        Dim gp As New Group("Matthew", "Mark", "Luke", "John")
        Console.WriteLine(gp.ToString())
    End Sub
End Module
' The example displays the following output:
'       Matthew, Mark, Luke, John
' </Snippet25>

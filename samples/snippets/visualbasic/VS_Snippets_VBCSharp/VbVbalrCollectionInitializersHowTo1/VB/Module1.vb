Imports System.Collections.Generic
'<Snippet2>
Imports System.Runtime.CompilerServices

Module Module1

    <Extension()>
    Sub Add(ByVal list As List(Of Employee), ByVal id As Integer,
                                             ByVal name As String)
        list.Add(New Employee With {.Id = id, .Name = name})
    End Sub

End Module
'</Snippet2>

Module Module2
    '<Snippet3>
    Sub Main()
        Dim employees = New List(Of Employee) From {{1, "Adams, Ellen"},
                                                    {2, "Hamilton, James R."},
                                                    {3, "Ihrig, Ryan"}}
    End Sub
    '</Snippet3>
End Module

'<Snippet1>
Public Class Employee
    Public Property Id() As Integer
    Public Property Name() As String
End Class
'</Snippet1>


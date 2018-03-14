'<Snippet1>
Imports System
Imports System.Management


Public Class Sample
    Public Overloads Shared Function _
        Main(ByVal args() As String) As Integer

        Dim q As New RelatedObjectQuery( _
            "Win32_Service=""TCP/IP""")
        q.RelationshipClass = "Win32_DependentService"

    End Function
End Class
'</Snippet1>
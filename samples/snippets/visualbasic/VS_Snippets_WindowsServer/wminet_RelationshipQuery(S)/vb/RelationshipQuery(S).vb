'<Snippet1>
Imports System
Imports System.Management


Public Class Sample
    Public Overloads Shared Function _
        Main(ByVal args() As String) As Integer

        ' Full query string is specified
        ' to the constructor
        Dim q As New RelationshipQuery( _
            "references of {Win32_ComputerSystem.Name='mymachine'}")

        ' Only the object of interest is
        ' specified to the constructor
        Dim query As New RelationshipQuery( _
            "Win32_Service.Name='Alerter'")

    End Function
End Class
'</Snippet1>
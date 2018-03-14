'<Snippet1>
Imports System
Imports System.Management

Public Class Sample

    Public Shared Function Main(ByVal args() _
        As String) As Integer

        Dim c As New ManagementClass("Win32_LogicalDisk")
        Dim s As String
        For Each s In c.Derivation
            Console.WriteLine("Further derived from : " & s)
        Next

        Return 0
    End Function
End Class
'</Snippet1>
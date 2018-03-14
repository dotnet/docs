'<Snippet1>
Imports System
Imports System.Management

Public Class Sample

    Public Shared Function Main(ByVal args() _
        As String) As Integer

        Dim c As New ManagementClass("Win32_LogicalDisk")
        Dim r As ManagementClass

        For Each r In c.GetRelatedClasses()
            Console.WriteLine( _
                "Instances of {0} may have relationships " _
                & "to this class", r("__CLASS"))
        Next r
        Return 0
    End Function
End Class
'</Snippet1>
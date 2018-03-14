'<Snippet1>
Imports System
Imports System.Management


Public Class Sample
    Public Overloads Shared Function _
        Main(ByVal args() As String) As Integer

        Dim s As New SelectQuery( _
            "SELECT * FROM Win32_LogicalDisk")

        'output is : SELECT * FROM Win32_LogicalDisk
        Console.WriteLine(s.QueryString)

        s.ClassName = "Win32_Process"

        'output is : SELECT * FROM Win32_Process
        Console.WriteLine(s.QueryString)

    End Function
End Class
'</Snippet1>
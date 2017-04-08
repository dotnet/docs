'<Snippet1>
Imports System
Imports System.Management


Class Sample
    Public Overloads Shared Function _
        Main(ByVal args() As String) As Integer

        Dim c As New ManagementClass("Win32_Process")
        Dim o As ManagementObject
        For Each o In c.GetInstances()
            Console.WriteLine( _
                "Next instance of Win32_Process : {0}", o("Name"))
        Next o

    End Function
End Class
'</Snippet1>
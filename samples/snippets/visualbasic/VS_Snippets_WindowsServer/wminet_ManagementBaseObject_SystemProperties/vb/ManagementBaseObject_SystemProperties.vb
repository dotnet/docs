'<Snippet1>
Imports System
Imports System.Management


Class Sample
    Public Overloads Shared Function _
        Main(ByVal args() As String) As Integer

        ' Get the WMI class
        Dim processClass As New ManagementClass( _
            "Win32_Process")

        ' Get the system properties for the class
        Dim properties As PropertyDataCollection
        properties = processClass.SystemProperties

        For Each p As PropertyData In properties

            Console.WriteLine(p.Name)
            Console.WriteLine(p.Value)
            Console.WriteLine()

        Next
    End Function
End Class
'</Snippet1>
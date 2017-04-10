'<Snippet1>
Imports System
Imports System.Management


Public Class EventSample
    Public Overloads Shared Function _
        Main(ByVal args() As String) As Integer

        '' Full query string specified to the constructor
        Dim q As New WqlEventQuery( _
            "SELECT * FROM Win32_ComputerShutdownEvent ")

        ' Only relevant event class name specified to the constructor
        ' Results in the same query as above   
        Dim query As New WqlEventQuery("Win32_ComputerShutdownEvent ")

        MessageBox.Show(query.QueryString)

    End Function 'Main
End Class 'EventSample
'</Snippet1>
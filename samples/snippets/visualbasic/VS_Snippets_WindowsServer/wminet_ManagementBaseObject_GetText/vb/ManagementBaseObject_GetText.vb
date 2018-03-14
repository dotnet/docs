'<Snippet1>
Imports System
Imports System.Management


Class Sample
    Public Overloads Shared Function _
        Main(ByVal args() As String) As Integer

        ' Get the WMI class
        Dim processClass As New ManagementClass( _
            "Win32_Process")
        processClass.Options.UseAmendedQualifiers = True

        Console.WriteLine( _
            processClass.GetText( _
            TextFormat.Mof))

    End Function
End Class
'</Snippet1>
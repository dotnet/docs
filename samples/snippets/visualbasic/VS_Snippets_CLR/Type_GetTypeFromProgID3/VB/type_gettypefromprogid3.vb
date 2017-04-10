' <Snippet1>
Imports System
Class MainApp
    Public Shared Sub Main()
        Try
            ' Use ProgID localhost\HKEY_CLASSES_ROOT\DirControl.DirList.1.
            Dim theProgramID As String = "DirControl.DirList.1"
            ' Use Server name localhost.
            Dim theServer As String = "localhost"
            ' Make a call to the method to get the type information for the given ProgID.
            Dim myType As Type = Type.GetTypeFromProgID(theProgramID, theServer)
            If myType Is Nothing Then
                Throw New Exception("Invalid ProgID or server.")
            End If
            Console.WriteLine("GUID for ProgID DirControl.DirList.1 is {0}.", myType.GUID.ToString())
        Catch e As Exception
            Console.WriteLine("An exception occurred.")
            Console.WriteLine("Source: {0}.", e.Source.ToString())
            Console.WriteLine("Message: {0}.", e.Message.ToString())
        End Try
    End Sub 'Main
End Class 'MainApp
' </Snippet1>

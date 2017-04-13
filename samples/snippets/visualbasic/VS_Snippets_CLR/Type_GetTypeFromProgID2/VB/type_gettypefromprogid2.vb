' <Snippet1>
Imports System
Class MainApp
    Public Shared Sub Main()
        Try
            ' Use the ProgID HKEY_CLASSES_ROOT\DirControl.DirList.1.
            Dim myString1 As String = "DIRECT.ddPalette.3"
            ' Use a nonexistent ProgID WrongProgID.
            Dim myString2 As String = "WrongProgID"
            ' Make a call to the method to get the type information of the given ProgID.
            Dim myType1 As Type = Type.GetTypeFromProgID(myString1, True)
            Console.WriteLine("GUID for ProgID DirControl.DirList.1 is {0}.", myType1.GUID.ToString())
            ' Throw an exception because the ProgID is invalid and the throwOnError 
            ' parameter is set to True.
            Dim myType2 As Type = Type.GetTypeFromProgID(myString2, True)
        Catch e As Exception
            Console.WriteLine("An exception occurred.")
            Console.WriteLine("Source: {0}", e.Source.ToString())
            Console.WriteLine("Message: {0}", e.Message.ToString())
        End Try
    End Sub 'Main 
End Class 'MainApp
' </Snippet1>

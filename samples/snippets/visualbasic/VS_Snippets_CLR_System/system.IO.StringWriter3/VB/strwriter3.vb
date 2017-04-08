' <Snippet1>
Imports System
Imports System.IO
Imports System.Text

Public Class StrWriter

    Shared Sub Main()
        Dim strBuilder As New StringBuilder( _
            "file path characters are: ")
        Dim strWriter As New StringWriter(strBuilder)

        strWriter.Write( _
            Path.InvalidPathChars, 0, Path.InvalidPathChars.Length)

        ' <Snippet2>
        strWriter.Close()

        ' Since the StringWriter is closed, an exception will 
        ' be thrown if the Write method is called. However, 
        ' the StringBuilder can still manipulate the string.
        strBuilder.Insert(0, "Invalid ")
        Console.WriteLine(strWriter.ToString())
        ' </Snippet2>
    End Sub

End Class
' </Snippet1>
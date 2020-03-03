' <Snippet1>
Imports System.Text

Class UnicodeEncodingExample

    Public Shared Sub Main()
        Dim uni As New UnicodeEncoding()
        Dim encodingName As String = uni.EncodingName
        Console.WriteLine("Encoding name: " & encodingName)
    End Sub
End Class
' </Snippet1>

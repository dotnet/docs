' <Snippet1>
Imports System
Imports System.Text

Class ASCIIEncodingExample   
    Public Shared Sub Main()
        Dim ascii As New ASCIIEncoding()
        Dim encodingName As String = ascii.EncodingName
        Console.WriteLine("Encoding name: " & encodingName)
    End Sub
End Class
' </Snippet1>

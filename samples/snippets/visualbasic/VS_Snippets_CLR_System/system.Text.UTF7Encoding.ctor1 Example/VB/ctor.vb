' <Snippet1>
Imports System
Imports System.Text

Class UTF7EncodingExample
    
    Public Shared Sub Main()
        Dim utf7 As New UTF7Encoding()
        Dim encodingName As String = utf7.EncodingName
        Console.WriteLine("Encoding name: " & encodingName)
    End Sub 'Main
End Class 'UTF7EncodingExample
' </Snippet1>

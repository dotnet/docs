' <Snippet1>
Imports System
Imports System.Text

Class UTF8EncodingExample
    
    Public Shared Sub Main()
        Dim bytes() As Byte = { _
            85,  84,  70,  56,  32,  69, 110, _
            99, 111, 100, 105, 110, 103,  32, _
            69, 120,  97, 109, 112, 108, 101 _
        }
        
        Dim utf8 As New UTF8Encoding()
        Dim charCount As Integer = utf8.GetCharCount(bytes, 2, 8)
        Console.WriteLine("{0} characters needed to decode bytes.", charCount)
    End Sub 'Main
End Class 'UTF8EncodingExample
' </Snippet1>

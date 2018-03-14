'<snippet2>
Imports System
Imports System.Text

Class BaseTypeEncoding
    Public Shared Sub Main()
        SnippetA()
        SnippetB()
    End Sub

    Public Shared Sub SnippetA()
        '<snippet3>
        Dim MyString As String = "Encoding String."
        Dim AE As New ASCIIEncoding()
        Dim ByteArray() As Byte = AE.GetBytes(MyString)
        For x As Integer = 0 To ByteArray.Length - 1
            Console.Write("{0} ", ByteArray(x))
        Next x
        '</snippet3>
    End Sub

    Public Shared Sub SnippetB()
        '<snippet4>
        Dim AE As New ASCIIEncoding()
        Dim ByteArray() As Byte = {69, 110, 99, 111, 100, 105, 110, 103, _
            32, 83, 116, 114, 105, 110, 103, 46 }
        Dim CharArray() As Char = AE.GetChars(ByteArray)
        For x As Integer = 0 To ByteArray.Length - 1
            Console.Write(CharArray(x))
        Next x
        '</snippet4>
    End Sub
End Class
'</snippet2>

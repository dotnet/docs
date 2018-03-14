' <Snippet1>
Imports System
Imports System.Text

Class UTF8EncodingExample
    
    Public Shared Sub Main()
        ' Many ways to instantiate a UTF8 encoding.
        Dim UTF8a As New UTF8Encoding()
        Dim UTF8b As Encoding = Encoding.UTF8
        Dim UTF8c = New UTF8Encoding(True, True)
        Dim UTF8d = New UTF8Encoding(False, False)
        
        ' But not all are the same.
        Console.WriteLine(UTF8a.GetHashCode())
        Console.WriteLine(UTF8b.GetHashCode())
        Console.WriteLine(UTF8c.GetHashCode())
        Console.WriteLine(UTF8d.GetHashCode())
    End Sub 'Main
End Class 'UTF8EncodingExample
' </Snippet1>

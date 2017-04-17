' <Snippet4>
Imports System
Imports System.Globalization

Public Class ParseInt32
    Public Shared Sub Main()
        SnippetA()
        SnippetB()
        SnippetC()
    End Sub

    Public Shared Sub SnippetA()
        ' <Snippet5>
        Dim MyString As String = "12345"
        Dim MyInt As Integer = Integer.Parse(MyString)
        MyInt += 1
        Console.WriteLine(MyInt)
        ' The result is "12346".
        ' </Snippet5>
    End Sub

    Public Shared Sub SnippetB()
        ' <Snippet6>
        Dim MyCultureInfo As New CultureInfo("en-US")
        Dim MyString As String = "123,456"
        Dim MyInt As Integer = Integer.Parse(MyString, MyCultureInfo)
        Console.WriteLine(MyInt)
        ' Raises System.Format exception.
        ' </Snippet6>
    End Sub

    Public Shared Sub SnippetC()
        ' <Snippet7>
        Dim MyCultureInfo As new CultureInfo("en-US")
        Dim MyString As String = "123,456"
        Dim MyInt As Integer = Integer.Parse(MyString, _
            NumberStyles.AllowThousands, MyCultureInfo)
        Console.WriteLine(MyInt)
        ' The result is "123456".
        ' </Snippet7>
    End Sub
End Class
' </Snippet4>

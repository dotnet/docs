' <snippet15>
Class Example
    Public Shared Sub Main()
        Trim()
        TrimEnd1()
        TrimEnd2()
        TrimStart()
        Remove()
    End Sub

    Public Shared Sub Trim()
        ' <Snippet17>
        Dim MyString As String = " Big   "
        Console.WriteLine("Hello{0}World!", MyString)
        Dim TrimString As String = MyString.Trim()
        Console.WriteLine("Hello{0}World!", TrimString)
        ' The example displays the following output:
        '       Hello Big   World!
        '       HelloBigWorld!        
        ' </Snippet17>
    End Sub


    Public Shared Sub TrimEnd1()
        ' <snippet18>
        Dim MyString As String = "Hello World!"
        Dim MyChar() As Char = {"r","o","W","l","d","!"," "}
        Dim NewString As String = MyString.TrimEnd(MyChar)
        Console.WriteLine(NewString)
        ' </snippet18>
    End Sub

    Public Shared Sub TrimEnd2()
        ' <snippet19>
        Dim MyString As String = "Hello, World!"
        Dim MyChar() As Char = {"r","o","W","l","d","!"," "}
        Dim NewString As String = MyString.TrimEnd(MyChar)
        Console.WriteLine(NewString)
        ' </snippet19>
    End Sub

    Public Shared Sub TrimStart()
        ' <snippet20>
        Dim MyString As String = "Hello World!"
        Dim MyChar() As Char = {"e","H","l","o"," " }
        Dim NewString As String = MyString.TrimStart(MyChar)
        Console.WriteLine(NewString)
        ' </snippet20>
    End Sub

    Public Shared Sub Remove()
        ' <snippet21>
        Dim MyString As String = "Hello Beautiful World!"
        Console.WriteLine(MyString.Remove(5,10))
        ' The example displays the following output:
        '         Hello World!        
        ' </snippet21>
    End Sub
End Class
'</snippet15>

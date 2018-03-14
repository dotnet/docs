'<snippet5>
Class Example
    Public Shared Sub Main()
        Compare()
        CompareOrdinal()
        CompareTo()
        Equals1()
        Equals2()
        StartsWith()
        EndsWith()
        IndexOf()
        LastIndexOf()
    End Sub

    Public Shared Sub Compare()
        '<snippet6>
        Dim string1 As String = "Hello World!"
        Console.WriteLine(String.Compare(string1, "Hello World?"))
        '</snippet6>
    End Sub

    Public Shared Sub CompareOrdinal()
        '<snippet7>
        Dim string1 As String = "Hello World!"
        Console.WriteLine(String.CompareOrdinal(string1, "hello world!"))
        '</snippet7>
    End Sub

    Public Shared Sub CompareTo()
        '<snippet8>
        Dim string1 As String = "Hello World"
        Dim string2 As String = "Hello World!"
        Dim MyInt As Integer = string1.CompareTo(string2)
        Console.WriteLine(MyInt)
        '</snippet8>
    End Sub

    Public Shared Sub Equals1()
        '<snippet9>
        Dim string1 As String = "Hello World"
        Console.WriteLine(string1.Equals("Hello World"))
        '</snippet9>
    End Sub

    Public Shared Sub Equals2()
        '<snippet10>
        Dim string1 As String = "Hello World"
        Dim string2 As String = "Hello World"
        Console.WriteLine(String.Equals(string1, string2))
        '</snippet10>
    End Sub

    Public Shared Sub StartsWith()
        '<snippet11>
        Dim string1 As String = "Hello World!"
        Console.WriteLine(string1.StartsWith("Hello"))
        '</snippet11>
    End Sub

    Public Shared Sub EndsWith()
        '<snippet12>
        Dim string1 As String = "Hello World!"
        Console.WriteLine(string1.EndsWith("Hello"))
        '</snippet12>
    End Sub

    Public Shared Sub IndexOf()
        '<snippet13>
        Dim string1 As String = "Hello World!"
        Console.WriteLine(string1.IndexOf("l"))
        '</snippet13>
    End Sub

    Public Shared Sub LastIndexOf()
        '<snippet14>
        Dim string1 As String = "Hello World!"
        Console.WriteLine(string1.LastIndexOf("l"))
        '</snippet14>
    End Sub
End Class
'</snippet5>

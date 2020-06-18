
Imports System.Text.RegularExpressions

Module Example
    Public Sub Main()
        Console.WriteLine(Regex.IsMatch("aa", "(?<2>\w)\k<1>"))
        ' Throws an ArgumentException.
    End Sub
End Module


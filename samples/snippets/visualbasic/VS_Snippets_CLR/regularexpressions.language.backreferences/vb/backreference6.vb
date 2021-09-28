
Imports System.Text.RegularExpressions

Module Example
    Public Sub Main()
        Console.WriteLine(Regex.IsMatch("aa", "(?<char>\w)\k<1>"))
        ' Displays "True".
    End Sub
End Module


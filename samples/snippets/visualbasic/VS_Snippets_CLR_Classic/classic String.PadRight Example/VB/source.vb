Imports System

Public Class Sample
Public Shared Sub Main()
'<snippet1>
Dim str As String
str = "BBQ and Slaw"

Console.Write("|")
Console.Write(str.PadRight(15))
Console.WriteLine("|") ' Displays "|BBQ and Slaw   |".

Console.Write("|")
Console.Write(str.PadRight(5))
Console.WriteLine("|") ' Displays "|BBQ and Slaw|".
'</snippet1>
End Sub
End Class
' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Text.RegularExpressions

Module Example
    Public Sub Main()
        Dim delimited As String = "\G(.+)[\t\u007c](.+)\r?\n"
        Dim input As String = "Mumbai, India|13,922,125" + vbCrLf + _
                              "Shanghai, China" + vbTab + "13,831,900" + vbCrLf + _
                              "Karachi, Pakistan|12,991,000" + vbCrLf + _
                              "Delhi, India" + vbTab + "12,259,230" + vbCrLf + _
                              "Istanbul, Türkiye|11,372,613" + vbCrLf
        Console.WriteLine("Population of the World's Largest Cities, 2009")
        Console.WriteLine()
        Console.WriteLine("{0,-20} {1,10}", "City", "Population")
        Console.WriteLine()
        For Each match As Match In Regex.Matches(input, delimited)
            Console.WriteLine("{0,-20} {1,10}", match.Groups(1).Value, _
                                               match.Groups(2).Value)
        Next
    End Sub
End Module
' The example displays the following output:
'       Population of the World's Largest Cities, 2009
'       
'       City                 Population
'       
'       Mumbai, India        13,922,125
'       Shanghai, China      13,831,900
'       Karachi, Pakistan    12,991,000
'       Delhi, India         12,259,230
'       Istanbul, Türkiye     11,372,613
' </Snippet1>

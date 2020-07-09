' Visual Basic .NET Document
Option Strict On
' <Snippet10>
Imports System.Text

Module Example
    Public Sub Main()
        Dim sb As New StringBuilder()
        Dim flag As Boolean = True
        Dim spellings() As String = {"recieve", "receeve", "receive"}
        sb.AppendFormat("Which of the following spellings is {0}:", flag)
        sb.AppendLine()
        For ctr As Integer = 0 To spellings.GetUpperBound(0)
            sb.AppendFormat("   {0}. {1}", ctr, spellings(ctr))
            sb.AppendLine()
        Next
        sb.AppendLine()
        Console.WriteLine(sb.ToString())
    End Sub
End Module
' The example displays the following output:
'       Which of the following spellings is True:
'          0. recieve
'          1. receeve
'          2. receive
' </Snippet10>

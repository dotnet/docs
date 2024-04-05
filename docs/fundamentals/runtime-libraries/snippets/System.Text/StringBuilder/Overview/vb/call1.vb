' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Imports System.Text

Module Example2
    Public Sub Main()
        Dim sb As New StringBuilder()
        sb.Append("This is the beginning of a sentence, ")
        sb.Replace("the beginning of ", "")
        sb.Insert(sb.ToString().IndexOf("a ") + 2, "complete ")
        sb.Replace(",", ".")
        Console.WriteLine(sb.ToString())
    End Sub
End Module
' The example displays the following output:
'       This is a complete sentence.
' </Snippet4>

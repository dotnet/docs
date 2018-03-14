' Visual Basic .NET Document
Option Strict On

' <Snippet5>
Imports System.Text

Module Example
   Public Sub Main()
      Dim sb As New StringBuilder("This is the beginning of a sentence, ")
      sb.Replace("the beginning of ", "").Insert(sb.ToString().IndexOf("a ") + 2, _
                                                 "complete ").Replace(", ", ".")
      Console.WriteLine(sb.ToString())
   End Sub
End Module
' The example displays the following output:
'       This is a complete sentence.
' </Snippet5>

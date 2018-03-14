' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Text

Module Example
   Public Sub Main()
      Dim sb As New StringBuilder(15, 15)
      sb.Append("Substring #1 ")
      Try
         sb.Insert(0, "Substring #2 ", 1)
      Catch e As OutOfMemoryException
         Console.WriteLine("Out of Memory: {0}", e.Message)
      End Try
   End Sub
End Module
' The example displays the following output:
'   Out of Memory: Insufficient memory to continue the execution of the program.
' </Snippet1>

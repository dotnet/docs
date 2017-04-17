' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Module Example
   Public Sub Main()
      If Not Console.IsInputRedirected Then
         Console.WriteLine("This example requires that input be redirected from a file.")
         Exit Sub 
      End If

      Console.WriteLine("About to call Console.ReadLine in a loop.")
      Console.WriteLine("----")
      Dim s As String
      Dim ctr As Integer
      Do
         ctr += 1
         s = Console.ReadLine()
         Console.WriteLine("Line {0}: {1}", ctr, s)
      Loop While s IsNot Nothing
      Console.WriteLine("---")
   End Sub
End Module
' The example displays the following output:
'       About to call Console.ReadLine in a loop.
'       ----
'       Line 1: This is the first line.
'       Line 2: This is the second line.
'       Line 3: This is the third line.
'       Line 4: This is the fourth line.
'       Line 5:
'       ---
' </Snippet3>

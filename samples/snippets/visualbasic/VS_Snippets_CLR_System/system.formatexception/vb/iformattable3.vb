' Visual Basic .NET Document
Option Strict On

' <Snippet9>
Module Example
   Public Sub Main()
      Dim guidString As String = "ba748d5c-ae5f-4cca-84e5-1ac5291c38cb"
      Console.WriteLine(Guid.ParseExact(guidString, "G"))
   End Sub
End Module
' The example displays the following output:
'    Unhandled Exception: System.FormatException: 
'       Format String can be only "D", "d", "N", "n", "P", "p", "B", "b", "X" or "x".
'       at System.Guid.ParseExact(String input, String format)
'       at Example.Main()
' </Snippet9>

' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module StringParsing
   Public Sub Main()
      TryToParse(Nothing)
      TryToParse("160519")
      TryToParse("9432.0")
      TryToParse("16,667")
      TryToParse("   -322   ")
      TryToParse("+4302")
      TryToParse("(100)")
      TryToParse("01FA")
   End Sub
   
   Private Sub TryToParse(value As String)
      Dim number As Long
      Dim result As Boolean = Int64.TryParse(value, number)
      If result Then
         Console.WriteLine("Converted '{0}' to {1}.", value, number)
      Else
         If value Is Nothing Then value = "" 
         Console.WriteLine("Attempted conversion of '{0}' failed.", value)
      End If     
   End Sub
End Module
' The example displays the following output to the console:
'       Attempted conversion of '' failed.
'       Converted '160519' to 160519.
'       Attempted conversion of '9432.0' failed.
'       Attempted conversion of '16,667' failed.
'       Converted '   -322   ' to -322.
'       Converted '+4302' to 4302.
'       Attempted conversion of '(100)' failed.
'       Attempted conversion of '01FA' failed.
' </Snippet1>

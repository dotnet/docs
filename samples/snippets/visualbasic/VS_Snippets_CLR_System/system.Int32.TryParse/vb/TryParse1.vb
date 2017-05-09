' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim values() As String = { Nothing, "160519", "9432.0", "16,667",
                                 "   -322   ", "+4302", "(100);", 
                                 "01FA" }

      For Each value In values
         Dim number As Integer
    
         Dim result As Boolean = Int32.TryParse(value, number)
         If result Then
            Console.WriteLine("Converted '{0}' to {1}.", value, number)
         Else
            Console.WriteLine("Attempted conversion of '{0}' failed.", 
                              If(value Is Nothing, "<null>", value))
         End If     
      Next
   End Sub
End Module
' The example displays the following output to the console:
'       Attempted conversion of '<null>' failed.
'       Converted '160519' to 160519.
'       Attempted conversion of '9432.0' failed.
'       Attempted conversion of '16,667' failed.
'       Converted '   -322   ' to -322.
'       Converted '+4302' to 4302.
'       Attempted conversion of '(100)' failed.
'       Attempted conversion of '01FA' failed.
' </Snippet1>

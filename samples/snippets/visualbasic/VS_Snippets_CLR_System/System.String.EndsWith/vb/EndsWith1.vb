' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim strings() As String = { "This is a string.", "Hello!", 
                                  "Nothing.", "Yes.", "randomize" }
      For Each value In strings
         Dim endsInPeriod As Boolean = value.EndsWith(".")
         Console.WriteLine("'{0}' ends in a period: {1}", 
                           value, endsInPeriod)
      Next                            
   End Sub
End Module
' The example displays the following output:
'       'This is a string.' ends in a period: True
'       'Hello!' ends in a period: False
'       'Nothing.' ends in a period: True
'       'Yes.' ends in a period: True
'       'randomize' ends in a period: False
' </Snippet1>

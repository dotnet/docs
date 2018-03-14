' Visual Basic .NET Document
Option Strict On

' <Snippet10>
Module Example
   Public Sub Main()
      Dim guidString As String = "ba748d5c-ae5f-4cca-84e5-1ac5291c38cb"
      Console.WriteLine(Guid.Parse(guidString))
   End Sub
End Module
' The example displays the following output:
'   ba748d5c-ae5f-4cca-84e5-1ac5291c38cb
' </Snippet10>

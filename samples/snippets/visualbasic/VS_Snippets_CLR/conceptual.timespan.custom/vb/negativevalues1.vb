' Visual Basic .NET Document
Option Strict On

' <Snippet29>
Module Example
   Public Sub Main()
      Dim result As TimeSpan = New DateTime(2010, 01, 01) - Date.Now 
      Dim fmt As String = If(result < TimeSpan.Zero, "\-", "") + "dd\.hh\:mm"
      
      Console.WriteLine(result.ToString(fmt))
      Console.WriteLine("Interval: {0:" + fmt + "}", result)
   End Sub
End Module
' The example displays output like the following:
'       -1291.10:54
'       Interval: -1291.10:54
' </Snippet29>

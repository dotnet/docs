' Visual Basic .NET Document
Option Strict On

Module Example
   Public Sub Main()
      ' <Snippet3>
      Dim value As String = "000000006"
      Dim interval As TimeSpan
      If TimeSpan.TryParse(value, interval) Then
         Console.WriteLine("{0} --> {1}", value, interval)
      Else
         Console.WriteLine("Unable to parse '{0}'", value)
      End If
      ' Output from .NET Framework 3.5 and earlier versions:
      '       000000006 --> 6.00:00:00
      ' Output from .NET Framework 4:
      '       Unable to parse '000000006'
      ' </Snippet3>
   End Sub
End Module


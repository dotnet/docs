' Visual Basic .NET Document
Option Strict On

Module Example
   Public Sub Main()
      ' <Snippet15>
      Dim date1 As Date = #6/15/2009 13:45#
      Dim fmt As String = "h \h m \m"

      Console.WriteLine("{0} ({1}) -> {2}", date1, fmt, date1.ToString(fmt))
      ' The example displays the following output:
      '       6/15/2009 1:45:00 PM (h \h m \m) -> 1 h 45 m      
      ' </Snippet15>
   End Sub
End Module


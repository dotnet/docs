' Visual Basic .NET Document
Option Strict On

Module Example
   Public Sub Main()
      ' <Snippet28>
      Dim interval As New TimeSpan(0, 32, 45)
      ' Escape literal characters in a format string.
      Dim fmt As String = "mm\:ss\ \m\i\n\u\t\e\s"
      Console.WriteLine(interval.ToString(fmt))
      ' Delimit literal characters in a format string with the ' symbol.
      fmt = "mm':'ss' minutes'"
      Console.WriteLine(interval.ToString(fmt))
      ' The example displays the following output: 
      '       32:45 minutes      
      '       32:45 minutes      
      ' </Snippet28>
   End Sub
End Module


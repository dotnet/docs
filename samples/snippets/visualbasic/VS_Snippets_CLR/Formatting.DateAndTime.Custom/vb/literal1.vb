' Visual Basic .NET Document
Option Strict On

Module Example
   Public Sub Main()
      ' <Snippet16>
      Dim dat1 As Date = #6/15/2009 1:45PM#
      
      Console.WriteLine("'{0:%h}'", dat1)
      Console.WriteLine("'{0: h}'", dat1)
      Console.WriteLine("'{0:h }'", dat1)
      ' The example displays the following output:
      '       '1'
      '       ' 1'
      '       '1 '
      ' </Snippet16>
   End Sub
End Module


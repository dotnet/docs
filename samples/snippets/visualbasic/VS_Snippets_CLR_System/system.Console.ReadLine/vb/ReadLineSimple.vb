' Visual Basic .NET Document
Option Strict On

' <Snippet6>
Module Example
   Public Sub Main()
      Console.Clear()

      Dim dat As Date = Date.Now

      Console.WriteLine()
      Console.WriteLine("Today is {0:d} at {0:T}.", dat)
      Console.WriteLine()
      Console.Write("Press any key to continue... ")
      Console.ReadLine()
   End Sub
End Module
' The example displays output like the following:
'     Today is 10/26/2015 at 12:22:22 PM.
'     
'     Press any key to continue...
' </Snippet6>
  
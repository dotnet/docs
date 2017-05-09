' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Module Example
   Public Sub Main()
      Dim startWork As New TimeSpan(08,00,00)
      Dim endWork As New TimeSpan(18,30,00)
      Dim lunchBreak As New TimeSpan(1, 0, 0)
      Dim breaks As New TimeSpan(0, 30, 0)
      
      Console.WriteLine("Length of work day: {0}", 
                        endWork - startWork)
      Console.WriteLine("Actual time worked: {0}",
                        endwork - startwork - (lun\chBreak + breaks))                  
   End Sub
End Module
' The example displays the following output:
'     Length of work day: 10:30:00
'     Actual time worked: 09:00:00
' </Snippet2>

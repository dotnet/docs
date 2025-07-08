' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Module Example
   Public Sub Main()
      Dim raining As Boolean = False
      Dim busLate As Boolean = True

      Console.WriteLine("It is raining: {0}", 
                        If(raining, "Yes", "No"))
      Console.WriteLine("The bus is late: {0}", 
                        If(busLate, "Yes", "No"))
   End Sub
End Module
' The example displays the following output:
'       It is raining: No
'       The bus is late: Yes
' </Snippet4>
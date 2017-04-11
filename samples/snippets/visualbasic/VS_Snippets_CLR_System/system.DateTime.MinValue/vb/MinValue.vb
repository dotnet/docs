' Visual Basic .NET Document
Option Strict On

Module Example
   Public Sub Main()
      ' <Snippet1>
      ' Define an uninitialized date.
      Dim date1 As Date
      Console.Write(date1)
      If date1.Equals(Date.MinValue) Then _
         Console.WriteLine("  (Equals Date.MinValue)")
      ' The example displays the following output:
      '    1/1/0001 12:00:00 AM  (Equals Date.MinValue)
      ' </Snippet1>         

      ' <Snippet2>
      ' Attempt to assign an out-of-range value to a DateTime constructor.
      Dim numberOfTicks As Long = Int64.MaxValue
      Dim validDate As Date
      
      ' Validate the value.
      If numberOfTicks >= Date.MinValue.Ticks And _
         numberOfTicks <= Date.MaxValue.Ticks Then
         validDate = New Date(numberOfTicks)
      ElseIf numberOfTicks < Date.MinValue.Ticks Then
         Console.WriteLine("{0:N0} is less than {1:N0} ticks.", 
                           numberOfTicks, 
                           DateTime.MinValue.Ticks)      
      Else                                                   
         Console.WriteLine("{0:N0} is greater than {1:N0} ticks.", 
                           numberOfTicks, 
                           DateTime.MaxValue.Ticks)     
      End If
      ' The example displays the following output:
      '   9,223,372,036,854,775,807 is greater than 3,155,378,975,999,999,999 ticks.      
      ' </Snippet2>
   End Sub
End Module


' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Module Example
   Public Sub Main()
      Dim number1 As Long = 1635429
      Dim number2 As Integer = 16203
      Dim number3 As Double = 1639.41
      Dim number4 As Long = 193685412
      
      ' Get the type of number1.
      Dim t As Type = number1.GetType()
      
      ' Compare types of all objects with number1.
      Console.WriteLine("Type of number1 and number2 are equal: {0}",
                        Object.ReferenceEquals(t, number2.GetType()))
      Console.WriteLine("Type of number1 and number3 are equal: {0}",
                        Object.ReferenceEquals(t, number3.GetType()))
      Console.WriteLine("Type of number1 and number4 are equal: {0}",
                        Object.ReferenceEquals(t, number4.GetType()))
   End Sub
End Module
' The example displays the following output:
'       Type of number1 and number2 are equal: False
'       Type of number1 and number3 are equal: False
'       Type of number1 and number4 are equal: True
' </Snippet3>

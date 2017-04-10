' Visual Basic .NET Document
Option Strict On
      
' <Snippet3>
Module Example
   Public Sub Main()
      Dim value As String
      Dim number As Double
      
      value = Double.MinValue.ToString()
      If Double.TryParse(value, number) Then
         Console.WriteLine(number)
      Else
         Console.WriteLine("{0} is outside the range of a Double.", _
                           value)
      End If
      
      value = Double.MaxValue.ToString()
      If Double.TryParse(value, number) Then
         Console.WriteLine(number)
      Else
         Console.WriteLine("{0} is outside the range of a Double.", _
                           value)
      End If
   End Sub
End Module
' The example displays the following output:
'    -1.79769313486232E+308 is outside the range of the Double type.
'    1.79769313486232E+308 is outside the range of the Double type.            
' </Snippet3>


' Visual Basic .NET Document
Option Strict On

Module Example
   Public Sub Main()
      ' <Snippet3>
      Dim value As String
      
      value = Double.MinValue.ToString()
      Try
         Console.WriteLine(Double.Parse(value))
      Catch e As OverflowException
         Console.WriteLine("{0} is outside the range of the Double type.", _
                           value)
      End Try
      
      value = Double.MaxValue.ToString()
      Try
         Console.WriteLine(Double.Parse(value))
      Catch e As OverflowException
         Console.WriteLine("{0} is outside the range of the Double type.", _
                           value)
      End Try
      ' The example displays the following output:
      '    -1.79769313486232E+308 is outside the range of the Double type.
      '    1.79769313486232E+308 is outside the range of the Double type.            
      ' </Snippet3>
   End Sub
End Module


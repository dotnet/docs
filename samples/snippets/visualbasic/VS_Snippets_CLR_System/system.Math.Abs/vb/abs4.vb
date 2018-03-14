' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Module Example
   Public Sub Main()
      Dim values() As Integer = { Int32.MaxValue, 16921, 0, -804128, Int32.MinValue }
      For Each value As Integer In values
         Try
            Console.WriteLine("Abs({0}) = {1}", value, Math.Abs(value))
         Catch e As OverflowException
            Console.WriteLine("Unable to calculate the absolute value of {0}.", _
                              value)
         End Try   
      Next
   End Sub
End Module
' The example displays the following output:
'       Abs(2147483647) = 2147483647
'       Abs(16921) = 16921
'       Abs(0) = 0
'       Abs(-804128) = 804128
'       Unable to calculate the absolute value of -2147483648.
' </Snippet4>


' Visual Basic .NET Document
Option Strict On

' <Snippet5>
Module Example
   Public Sub Main()
      Dim values() As Long = { Int64.MaxValue, 109013, 0, -6871982, Int64.MinValue }
      For Each value As Long In values
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
'       Abs(9223372036854775807) = 9223372036854775807
'       Abs(109013) = 109013
'       Abs(0) = 0
'       Abs(-6871982) = 6871982
'       Unable to calculate the absolute value of -9223372036854775808.
' </Snippet5>   

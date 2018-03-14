' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Module Example
   Public Sub Main()
      Dim values() As Short = { Int16.MaxValue, 10328, 0, -1476, Int16.MinValue }
      For Each value As Short In values
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
'       Abs(32767) = 32767
'       Abs(10328) = 10328
'       Abs(0) = 0
'       Abs(-1476) = 1476
'       Unable to calculate the absolute value of -32768.
' </Snippet3>



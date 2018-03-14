' Visual Basic .NET Document
Option Strict On

' <Snippet6>
Module Example
   Public Sub Main()
      Dim values() As SByte = { SByte.MaxValue, 98, 0, -32, SByte.MinValue }
      For Each value As SByte In values
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
'       Abs(127) = 127
'       Abs(98) = 98
'       Abs(0) = 0
'       Abs(-32) = 32
'       Unable to calculate the absolute value of -128.
' </Snippet6>   

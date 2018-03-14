' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module modMain
   Public Sub Main()
      Dim dividend, divisor As Integer
      Dim result As Tuple(Of Integer, Integer)
      
      dividend = 136945 : divisor = 178
      result = IntegerDivide(dividend, divisor)
      If result IsNot Nothing Then
         Console.WriteLine("{0} \ {1} = {2}, remainder {3}", 
                           dividend, divisor, result.Item1, result.Item2)
      Else
         Console.WriteLine("{0} \ {1} = <Error>", dividend, divisor)
      End If
                        
      dividend = Int32.MaxValue : divisor = -2073
      result = IntegerDivide(dividend, divisor)
      If result IsNot Nothing Then
         Console.WriteLine("{0} \ {1} = {2}, remainder {3}", 
                           dividend, divisor, result.Item1, result.Item2)
      Else
         Console.WriteLine("{0} \ {1} = <Error>", dividend, divisor)
      End If
   End Sub
   
   Private Function IntegerDivide(dividend As Integer, divisor As Integer) As Tuple(Of Integer, Integer)
      Try
         Dim remainder As Integer
         Dim quotient As Integer = Math.DivRem(dividend, divisor, remainder)
         Return New Tuple(Of Integer, Integer)(quotient, remainder)
      Catch e As DivideByZeroException
         Return Nothing
      End Try      
   End Function
End Module
' The example displays the following output:
'       136945 \ 178 = 769, remainder 63
'       2147483647 \ -2073 = -1035930, remainder 757
' </Snippet1>

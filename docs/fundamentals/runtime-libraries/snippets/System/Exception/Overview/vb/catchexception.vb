'<Snippet1>
Class ExceptionTestClass
   
   Public Shared Sub Main()
      Dim x As Integer = 0
      Try
         Dim y As Integer = 100 / x
      Catch e As ArithmeticException
         Console.WriteLine("ArithmeticException Handler: {0}", e.ToString())
      Catch e As Exception
         Console.WriteLine("Generic Exception Handler: {0}", e.ToString())
      End Try
   End Sub
End Class
'
'This code example produces the following results:
'
'ArithmeticException Handler: System.OverflowException: Arithmetic operation resulted in an overflow.
'   at ExceptionTestClass.Main()
'
'</Snippet1>
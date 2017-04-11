' Visual Basic .NET Document
Option Strict On

Module Example
   Public Sub Main()
      ' <Snippet1>
      Dim value As Integer = 780000000
      Try
         ' Square the original value.
         Dim square As Integer = value * value 
         Console.WriteLine("{0} ^ 2 = {1}", value, square)
      Catch e As OverflowException
         Dim square As Double = Math.Pow(value, 2)
         Console.WriteLine("Exception: {0} > {1:E}.", _
                           square, Int32.MaxValue)
      End Try
      ' The example displays the following output:
      '       Exception: 6.084E+17 > 2.147484E+009.
      ' </Snippet1>
      
      Cast()
   End Sub
   
   Private Sub Cast()
      ' <Snippet2>
      Dim value As Byte = 241
      Try
         Dim newValue As SByte = (CSByte(value))
         Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.", _
                           value.GetType().Name, value, _
                           newValue.GetType().Name, newValue)
      Catch e As OverflowException
         Console.WriteLine("Exception: {0} > {1}.", value, SByte.MaxValue)
      End Try                            
      ' The example displays the following output:
      '       Exception: 241 > 127.
      ' </Snippet2>
   End Sub
End Module


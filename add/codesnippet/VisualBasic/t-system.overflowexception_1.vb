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
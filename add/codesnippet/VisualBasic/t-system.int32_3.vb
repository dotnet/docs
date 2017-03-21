      Dim lNumber As Long = 163245617
      Try
         Dim number1 As Integer = CInt(lNumber)
         Console.WriteLine(number1)
      Catch e As OverflowException
         Console.WriteLine("{0} is out of range of an Int32.", lNumber)
      End Try
      
      Dim dbl2 As Double = 35901.997
      Try
         Dim number2 As Integer = CInt(dbl2)
         Console.WriteLine(number2)
      Catch e As OverflowException
         Console.WriteLine("{0} is out of range of an Int32.", dbl2)
      End Try
         
      Dim bigNumber As BigInteger = 132451
      Try
         Dim number3 As Integer = CInt(bigNumber)
         Console.WriteLine(number3)
      Catch e As OverflowException
         Console.WriteLine("{0} is out of range of an Int32.", bigNumber)
      End Try    
      ' The example displays the following output:
      '       163245617
      '       35902
      '       132451
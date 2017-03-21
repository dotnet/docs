      Dim ulNumber As ULong = 163245617943825
      Try
         Dim number1 As Long = CLng(ulNumber)
         Console.WriteLine(number1)
      Catch e As OverflowException
         Console.WriteLine("{0} is out of range of an Int64.", ulNumber)
      End Try
      
      Dim dbl2 As Double = 35901.997
      Try
         Dim number2 As Long = CLng(dbl2)
         Console.WriteLine(number2)
      Catch e As OverflowException
         Console.WriteLine("{0} is out of range of an Int64.", dbl2)
      End Try
         
      Dim bigNumber As BigInteger = 1.63201978555e30
      Try
         Dim number3 As Long = CLng(bigNumber)
         Console.WriteLine(number3)
      Catch e As OverflowException
         Console.WriteLine("{0:N0} is out of range of an Int64.", bigNumber)
      End Try    
      ' The example displays the following output:
      '    163245617943825
      '    35902
      '    1,632,019,785,549,999,969,612,091,883,520 is out of range of an Int64.
      Dim int1 As Integer = 128
      Try
         Dim value1 As Byte = CByte(int1)
         Console.WriteLine(value1)
      Catch e As OverflowException
         Console.WriteLine("{0} is out of range of a byte.", int1)
      End Try
      
      Dim dbl2 As Double = 3.997
      Try
         Dim value2 As Byte = CByte(dbl2)
         Console.WriteLine(value2)
      Catch e As OverflowException
         Console.WriteLine("{0} is out of range of a byte.", dbl2)
      End Try   
      ' The example displays the following output:
      '       128
      '       4
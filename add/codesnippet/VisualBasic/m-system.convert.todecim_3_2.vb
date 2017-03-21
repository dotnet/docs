      Dim numbers() As Single = { Single.MinValue, -3e10, -1093.54, 0, 1e-03, _
                                  1034.23, Single.MaxValue }
      Dim result As Decimal
      
      For Each number As Single In numbers
         Try
            result = Convert.ToDecimal(number)
            Console.WriteLine("Converted the Single value {0} to {1}.", number, result)
         Catch e As OverflowException
            Console.WriteLine("{0} is out of range of the Decimal type.", number)
         End Try
      Next                                  
      ' The example displays the following output:
      '       -3.402823E+38 is out of range of the Decimal type.
      '       Converted the Single value -3E+10 to -30000000000.
      '       Converted the Single value -1093.54 to -1093.54.
      '       Converted the Single value 0 to 0.
      '       Converted the Single value 0.001 to 0.001.
      '       Converted the Single value 1034.23 to 1034.23.
      '       3.402823E+38 is out of range of the Decimal type.
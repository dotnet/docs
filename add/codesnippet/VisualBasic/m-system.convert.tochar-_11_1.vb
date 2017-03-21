      Dim numbers() As SByte = { SByte.MinValue, -1, 40, 80, 120, SByte.MaxValue }
      Dim result As Char
      For Each number As SByte In numbers
         Try
            result = Convert.ToChar(number)
            Console.WriteLine("{0} converts to '{1}'.", number, result)
         Catch e As OverflowException
            Console.WriteLine("{0} is outside the range of the Char data type.", _
                              number)
         End Try
      Next
      ' The example displays the following output:
      '       -128 is outside the range of the Char data type.
      '       -1 is outside the range of the Char data type.
      '       40 converts to '('.
      '       80 converts to 'P'.
      '       120 converts to 'x'.
      '       127 converts to '⌂'.
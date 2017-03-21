      Dim values() As Object = { "r"c, "s", "word", CByte(83), 77, 109324, _
                                 335812911, #3/10/2009#, CUInt(1934), _ 
                                 CSByte(-17), 169.34, 175.6d, Nothing }
      Dim result As Char
      
      For Each value As Object In values
         Try
            result = Convert.ToChar(value)
            Console.WriteLine("The {0} value {1} converts to {2}.", _ 
                              value.GetType().Name, value, result)
         Catch e As FormatException
            Console.WriteLine(e.Message)
         Catch e As InvalidCastException
            Console.WriteLine("Conversion of the {0} value {1} to a Char is not supported.", _
                              value.GetType().Name, value)
         Catch e As OverflowException
            Console.WriteLine("The {0} value {1} is outside the range of the Char data type.", _
                              value.GetType().Name, value)
         Catch e As NullReferenceException
            Console.WriteLine("Cannot convert a null reference to a Char.")
         End Try
      Next
      ' The example displays the following output:
      '       The Char value r converts to r.
      '       The String value s converts to s.
      '       String must be exactly one character long.
      '       The Byte value 83 converts to S.
      '       The Int32 value 77 converts to M.
      '       The Int32 value 109324 is outside the range of the Char data type.
      '       The Int32 value 335812911 is outside the range of the Char data type.
      '       Conversion of the DateTime value 3/10/2009 12:00:00 AM to a Char is not supported.
      '       The UInt32 value 1934 converts to ?.
      '       The SByte value -17 is outside the range of the Char data type.
      '       Conversion of the Double value 169.34 to a Char is not supported.
      '       Conversion of the Decimal value 175.6 to a Char is not supported.
      '       Cannot convert a null reference to a Char.      
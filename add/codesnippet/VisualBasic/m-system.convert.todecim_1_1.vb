      Dim values() As Object = { True, "a"c, 123, 1.764e32, "9.78", "1e-02", _
                                 1.67e03, "A100", "1,033.67", Date.Now, _
                                 Double.MaxValue }   
      Dim result As Decimal
      
      For Each value As Object In values
         Try
            result = Convert.ToDecimal(value)
            Console.WriteLine("Converted the {0} value {1} to {2}.", _
                              value.GetType().Name, value, result)
         Catch e As OverflowException
            Console.WriteLine("The {0} value {1} is out of range of the Decimal type.", _
                              value.GetType().Name, value)
         Catch e As FormatException
            Console.WriteLine("The {0} value {1} is not recognized as a valid Decimal value.", _
                              value.GetType().Name, value)
         Catch e As InvalidCastException
            Console.WriteLine("Conversion of the {0} value {1} to a Decimal is not supported.", _
                              value.GetType().Name, value)
         End Try                     
      Next
      ' The example displays the following output:
      '    Converted the Boolean value True to 1.
      '    Conversion of the Char value a to a Decimal is not supported.
      '    Converted the Int32 value 123 to 123.
      '    The Double value 1.764E+32 is out of range of the Decimal type.
      '    Converted the String value 9.78 to 9.78.
      '    The String value 1e-02 is not recognized as a valid Decimal value.
      '    Converted the Double value 1670 to 1670.
      '    The String value A100 is not recognized as a valid Decimal value.
      '    Converted the String value 1,033.67 to 1033.67.
      '    Conversion of the DateTime value 10/15/2008 05:40:42 PM to a Decimal is not supported.
      '    The Double value 1.79769313486232E+308 is out of range of the Decimal type.      
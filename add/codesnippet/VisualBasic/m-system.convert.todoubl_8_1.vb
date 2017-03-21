      Dim values() As Object = { True, "a"c, 123, CSng(1.764e32), "9.78", "1e-02", _
                                 CSng(1.67e03), "A100", "1,033.67", Date.Now, _
                                 Decimal.MaxValue }   
      Dim result As Double
      
      For Each value As Object In values
         Try
            result = Convert.ToDouble(value)
            Console.WriteLine("Converted the {0} value {1} to {2}.", _
                              value.GetType().Name, value, result)
         Catch e As FormatException
            Console.WriteLine("The {0} value {1} is not recognized as a valid Double value.", _
                              value.GetType().Name, value)
         Catch e As InvalidCastException
            Console.WriteLine("Conversion of the {0} value {1} to a Double is not supported.", _
                              value.GetType().Name, value)
         End Try                     
      Next
      ' The example displays the following output:
      '    Converted the Boolean value True to 1.
      '    Conversion of the Char value a to a Double is not supported.
      '    Converted the Int32 value 123 to 123.
      '    Converted the Single value 1.764E+32 to 1.76399995098587E+32.
      '    Converted the String value 9.78 to 9.78.
      '    Converted the String value 1e-02 to 0.01.
      '    Converted the Single value 1670 to 1670.
      '    The String value A100 is not recognized as a valid Double value.
      '    Converted the String value 1,033.67 to 1033.67.
      '    Conversion of the DateTime value 10/21/2008 07:12:12 AM to a Double is not supported.
      '    Converted the Decimal value 79228162514264337593543950335 to 7.92281625142643E+28.      
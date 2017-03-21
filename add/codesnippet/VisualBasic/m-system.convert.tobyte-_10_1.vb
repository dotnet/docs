      Dim values() As Object = { True, -12, 163, 935, "x"c, "104", "103.0", "-1", _
                                 "1.00e2", "One", 1.00e2}
      Dim result As Byte
      For Each value As Object In values
         Try
            result = Convert.ToByte(value)
            Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.", _
                              value.GetType().Name, value, _
                              result.GetType().Name, result)
         Catch e As OverflowException
            Console.WriteLine("The {0} value {1} is outside the range of the Byte type.", _
                              value.GetType().Name, value)
         Catch e As FormatException
            Console.WriteLine("The {0} value {1} is not in a recognizable format.", _
                              value.GetType().Name, value)
         Catch e As InvalidCastException
            Console.WriteLine("No conversion to a Byte exists for the {0} value {1}.", _
                              value.GetType().Name, value)
                              
         End Try
      Next                           
      ' The example displays the following output:
      '       Converted the Boolean value True to the Byte value 1.
      '       The Int32 value -12 is outside the range of the Byte type.
      '       Converted the Int32 value 163 to the Byte value 163.
      '       The Int32 value 935 is outside the range of the Byte type.
      '       Converted the Char value x to the Byte value 120.
      '       Converted the String value 104 to the Byte value 104.
      '       The String value 103.0 is not in a recognizable format.
      '       The String value -1 is outside the range of the Byte type.
      '       The String value 1.00e2 is not in a recognizable format.
      '       The String value One is not in a recognizable format.
      '       Converted the Double value 100 to the Byte value 100.      
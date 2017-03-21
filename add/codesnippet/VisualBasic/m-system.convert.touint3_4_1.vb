      Dim values() As String = { "One", "1.34e28", "-26.87", "-18", "-6.00", _
                                 " 0", "137", "1601.9", Int32.MaxValue.ToString() }
      Dim result As UInteger
      
      For Each value As String In values
         Try
            result = Convert.ToUInt32(value)
            Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", _
                              value.GetType().Name, value, result.GetType().Name, result)
         Catch e As OverflowException
            Console.WriteLine("The {0} value {1} is outside the range of the UInt32 type.", _
                              value.GetType().Name, value)
         Catch e As FormatException
            Console.WriteLine("The {0} value '{1}' is not in a recognizable format.", _
                              value.GetType().Name, value)
         End Try   
      Next                                 
      ' The example displays the following output:
      '    The String value 'One' is not in a recognizable format.
      '    The String value '1.34e28' is not in a recognizable format.
      '    The String value '-26.87' is not in a recognizable format.
      '    The String value -18 is outside the range of the UInt32 type.
      '    The String value '-6.00' is not in a recognizable format.
      '    Converted the String value ' 0' to the UInt32 value 0.
      '    Converted the String value '137' to the UInt32 value 137.
      '    The String value '1601.9' is not in a recognizable format.
      '    Converted the String value '2147483647' to the UInt32 value 2147483647.
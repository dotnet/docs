      Dim values() As Double = { Double.MinValue, -1.38e10, -1023.299, -12.98, _
                                 0, 9.113e-16, 103.919, 17834.191, Double.MaxValue }
      Dim result As ULong
      
      For Each value As Double In values
         Try
            result = Convert.ToUInt64(value)
            Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", _
                              value.GetType().Name, value, _
                              result.GetType().Name, result)
         Catch e As OverflowException
            Console.WriteLine("The {0} value {1} is outside the range of the UInt64 type.", _
                              value.GetType().Name, value)
         End Try   
      Next                                 
      ' The example displays the following output:
      '    The Double value -1.79769313486232E+308 is outside the range of the UInt64 type.
      '    The Double value -13800000000 is outside the range of the UInt64 type.
      '    The Double value -1023.299 is outside the range of the UInt64 type.
      '    The Double value -12.98 is outside the range of the UInt64 type.
      '    Converted the Double value '0' to the UInt64 value 0.
      '    Converted the Double value '9.113E-16' to the UInt64 value 0.
      '    Converted the Double value '103.919' to the UInt64 value 104.
      '    Converted the Double value '17834.191' to the UInt64 value 17834.
      '    The Double value 1.79769313486232E+308 is outside the range of the UInt64 type.
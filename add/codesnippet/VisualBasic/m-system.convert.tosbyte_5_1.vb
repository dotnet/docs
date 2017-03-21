      Dim numbers() As Double = { Double.MinValue, -129.5, -12.7, 0, 16, _
                                  103.6, 255.0, 1.63509e17, Double.MaxValue}
      Dim result As SByte
      
      For Each number As Double In numbers
         Try
            result = Convert.ToSByte(number)
            Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.", _
                              number.GetType().Name, number, _
                              result.GetType().Name, result)
         Catch e As OverflowException
            Console.WriteLine("The {0} value {1} is outside the range of the SByte type.", _
                              number.GetType().Name, number)
         End Try
      Next                                  
      ' The example displays the following output:
      '    The Double value -1.79769313486232E+308 is outside the range of the SByte type.
      '    The Double value -129.5 is outside the range of the SByte type.
      '    Converted the Double value -12.7 to the SByte value -13.
      '    Converted the Double value 0 to the SByte value 0.
      '    Converted the Double value 16 to the SByte value 16.
      '    Converted the Double value 103.6 to the SByte value 104.
      '    The Double value 255 is outside the range of the SByte type.
      '    The Double value 1.63509E+17 is outside the range of the SByte type.
      '    The Double value 1.79769313486232E+308 is outside the range of the SByte type.
      Dim values() As Decimal = { Decimal.MinValue, -1034.23d, -12d, 0d, 147d, _
                                  9214.16d, Decimal.MaxValue }
      Dim result As UShort
      
      For Each value As Decimal In values
         Try
            result = Convert.ToUInt16(value)
            Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", _
                              value.GetType().Name, value, _
                              result.GetType().Name, result)
         Catch e As OverflowException
            Console.WriteLine("{0} is outside the range of the UInt16 type.", _
                              value)
         End Try   
      Next                                  
      ' The example displays the following output:
      '    -79228162514264337593543950335 is outside the range of the UInt16 type.
      '    -1034.23 is outside the range of the UInt16 type.
      '    -12 is outside the range of the UInt16 type.
      '    Converted the Decimal value '0' to the UInt16 value 0.
      '    Converted the Decimal value '147' to the UInt16 value 147.
      '    Converted the Decimal value '9214.16' to the UInt16 value 9214.
      '    79228162514264337593543950335 is outside the range of the UInt16 type.
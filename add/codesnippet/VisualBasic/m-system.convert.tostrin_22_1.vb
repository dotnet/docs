      Dim values() As Object = { False, 12.63d, #06/01/2009 6:32:15#, 16.09e-12, _
                                 "Z"c, 15.15322, SByte.MinValue, Int32.MaxValue}
      Dim result As String
      
      For Each value As Object In values
         result = Convert.ToString(value)
         Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.", _
                              value.GetType().Name, value, _
                              result.GetType().Name, result)
      Next
      ' The example displays the following output:
      '    Converted the Boolean value False to the String value False.
      '    Converted the Decimal value 12.63 to the String value 12.63.
      '    Converted the DateTime value 6/1/2009 06:32:15 AM to the String value 6/1/2009 06:32:15 AM.
      '    Converted the Double value 1.609E-11 to the String value 1.609E-11.
      '    Converted the Char value Z to the String value Z.
      '    Converted the Double value 15.15322 to the String value 15.15322.
      '    Converted the SByte value -128 to the String value -128.
      '    Converted the Int32 value 2147483647 to the String value 2147483647.      
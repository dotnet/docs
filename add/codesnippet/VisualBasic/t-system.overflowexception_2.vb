      Dim value As Byte = 241
      Try
         Dim newValue As SByte = (CSByte(value))
         Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.", _
                           value.GetType().Name, value, _
                           newValue.GetType().Name, newValue)
      Catch e As OverflowException
         Console.WriteLine("Exception: {0} > {1}.", value, SByte.MaxValue)
      End Try                            
      ' The example displays the following output:
      '       Exception: 241 > 127.
      Dim value As String
      Dim number As Short
      
      value = " 12603 "
      Try
         number = Short.Parse(value)
         Console.WriteLine("Converted '{0}' to {1}.", value, number)
      Catch e As FormatException
         Console.WriteLine("Unable to convert '{0}' to a 16-bit signed integer.", _
                           value)
      End Try
      
      value = " 16,054"
      Try
         number = Short.Parse(value)
         Console.WriteLine("Converted '{0}' to {1}.", value, number)
      Catch e As FormatException
         Console.WriteLine("Unable to convert '{0}' to a 16-bit signed integer.", _
                           value)
      End Try
                              
      value = " -17264"
      Try
         number = Short.Parse(value)
         Console.WriteLine("Converted '{0}' to {1}.", value, number)
      Catch e As FormatException
         Console.WriteLine("Unable to convert '{0}' to a 16-bit signed integer.", _
                           value)
      End Try
      ' The example displays the following output to the console:
      '       Converted ' 12603 ' to 12603.
      '       Unable to convert ' 16,054' to a 16-bit signed integer.
      '       Converted ' -17264' to -17264.      
      Dim value As String
      Dim style As NumberStyles
      Dim number As Byte
      
      ' Parse value with no styles allowed.
      style = NumberStyles.None
      value = " 241 "
      Try
         number = Byte.Parse(value, style)
         Console.WriteLine("Converted '{0}' to {1}.", value, number)
      Catch e As FormatException
         Console.WriteLine("Unable to parse '{0}'.", value)   
      End Try
        
      ' Parse value with trailing sign.
      style = NumberStyles.Integer Or NumberStyles.AllowTrailingSign
      value = " 163+"
      number = Byte.Parse(value, style)
      Console.WriteLine("Converted '{0}' to {1}.", value, number)
      
      ' Parse value with leading sign.
      value = "   +253  "
      number = Byte.Parse(value, style)
      Console.WriteLine("Converted '{0}' to {1}.", value, number)
      ' This example displays the following output to the console:
      '       Unable to parse ' 241 '.
      '       Converted ' 163+' to 163.
      '       Converted '   +253  ' to 253.            
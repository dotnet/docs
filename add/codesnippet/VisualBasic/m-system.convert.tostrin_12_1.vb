      Dim dates() As Date = { #07/14/2009#, #6:32PM#, #02/12/2009 7:16AM#}
      Dim result As String
      
      For Each dateValue As Date In dates
         result = Convert.ToString(dateValue)
         Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.", _
                              dateValue.GetType().Name, dateValue, _
                              result.GetType().Name, result)
      Next
      ' The example displays the following output:
      '    Converted the DateTime value 7/14/2009 12:00:00 AM to a String value 7/14/2009 12:00:00 AM.
      '    Converted the DateTime value 1/1/0001 06:32:00 PM to a String value 1/1/0001 06:32:00 PM.
      '    Converted the DateTime value 2/12/2009 07:16:00 AM to a String value 2/12/2009 07:16:00 AM.
      Dim dateString, format As String  
      Dim result As DateTimeOffset
      Dim provider As CultureInfo = CultureInfo.InvariantCulture
      
      ' Parse date-only value with invariant culture and assume time is UTC.
      dateString = "06/15/2008"
      format = "d"
      Try
         result = DateTimeOffset.ParseExact(dateString, format, provider, _
                                            DateTimeStyles.AssumeUniversal)
         Console.WriteLine("'{0}' converts to {1}.", dateString, result.ToString())
      Catch e As FormatException
         Console.WriteLine("'{0}' is not in the correct format.", dateString)
      End Try 
      
      ' Parse date-only value with leading white space.
      ' Should throw a FormatException because only trailing whitespace is  
      ' specified in method call.
      dateString = " 06/15/2008"
      Try
         result = DateTimeOffset.ParseExact(dateString, format, provider, _
                                            DateTimeStyles.AllowTrailingWhite)
         Console.WriteLine("'{0}' converts to {1}.", dateString, result.ToString())
      Catch e As FormatException
         Console.WriteLine("'{0}' is not in the correct format.", dateString)
      End Try 

      ' Parse date and time value, and allow all white space.
      dateString = " 06/15/   2008  15:15    -05:00"
      format = "MM/dd/yyyy H:mm zzz"
      Try
         result = DateTimeOffset.ParseExact(dateString, format, provider, _
                                            DateTimeStyles.AllowWhiteSpaces)
         Console.WriteLine("'{0}' converts to {1}.", dateString, result.ToString())
      Catch e As FormatException
         Console.WriteLine("'{0}' is not in the correct format.", dateString)
      End Try 
      
      ' Parse date and time and convert to UTC.
      dateString = "  06/15/2008 15:15:30 -05:00"   
      format = "MM/dd/yyyy H:mm:ss zzz"       
      Try
         result = DateTimeOffset.ParseExact(dateString, format, provider, _
                                            DateTimeStyles.AllowWhiteSpaces Or _
                                            DateTimeStyles.AdjustToUniversal)
         Console.WriteLine("'{0}' converts to {1}.", dateString, result.ToString())
      Catch e As FormatException
         Console.WriteLine("'{0}' is not in the correct format.", dateString)
      End Try 
      ' The example displays the following output:
      '    '06/15/2008' converts to 6/15/2008 12:00:00 AM +00:00.
      '    ' 06/15/2008' is not in the correct format.
      '    ' 06/15/   2008  15:15    -05:00' converts to 6/15/2008 3:15:00 PM -05:00.
      '    '  06/15/2008 15:15:30 -05:00' converts to 6/15/2008 8:15:30 PM +00:00.
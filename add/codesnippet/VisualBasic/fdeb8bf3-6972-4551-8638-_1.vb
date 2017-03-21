      Dim dateString, format As String  
      Dim result As DateTimeOffset
      Dim provider As CultureInfo = CultureInfo.InvariantCulture
      
      ' Parse date-only value with invariant culture.
      dateString = "06/15/2008"
      format = "d"
      Try
         result = DateTimeOffset.ParseExact(dateString, format, provider)
         Console.WriteLine("{0} converts to {1}.", dateString, result.ToString())
      Catch e As FormatException
         Console.WriteLine("{0} is not in the correct format.", dateString)
      End Try 
      
      ' Parse date-only value without leading zero in month using "d" format.
      ' Should throw a FormatException because standard short date pattern of 
      ' invariant culture requires two-digit month.
      dateString = "6/15/2008"
      Try
         result = DateTimeOffset.ParseExact(dateString, format, provider)
         Console.WriteLine("{0} converts to {1}.", dateString, result.ToString())
      Catch e As FormatException
         Console.WriteLine("{0} is not in the correct format.", dateString)
      End Try 

      ' Parse date and time with custom specifier.
      dateString = "Sun 15 Jun 2008 8:30 AM -06:00"
      format = "ddd dd MMM yyyy h:mm tt zzz"        
      Try
         result = DateTimeOffset.ParseExact(dateString, format, provider)
         Console.WriteLine("{0} converts to {1}.", dateString, result.ToString())
      Catch e As FormatException
         Console.WriteLine("{0} is not in the correct format.", dateString)
      End Try 
      
      ' Parse date and time with offset without offset's minutes.
      ' Should throw a FormatException because "zzz" specifier requires leading  
      ' zero in hours.
      dateString = "Sun 15 Jun 2008 8:30 AM -06"
      Try
         result = DateTimeOffset.ParseExact(dateString, format, provider)
         Console.WriteLine("{0} converts to {1}.", dateString, result.ToString())
      Catch e As FormatException
         Console.WriteLine("{0} is not in the correct format.", dateString)
      End Try 
      ' The example displays the following output:
      '    06/15/2008 converts to 6/15/2008 12:00:00 AM -07:00.
      '    6/15/2008 is not in the correct format.
      '    Sun 15 Jun 2008 8:30 AM -06:00 converts to 6/15/2008 8:30:00 AM -06:00.
      '    Sun 15 Jun 2008 8:30 AM -06 is not in the correct format.                     
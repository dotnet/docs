      Dim dateString As String
      Dim parsedDate As DateTimeOffset

      dateString = "05/01/2008 6:00:00"
      ' Assume time is local 
      If DateTimeOffset.TryParse(dateString, Nothing, _
                                 DateTimeStyles.AssumeLocal, _
                                 parsedDate) Then
         Console.WriteLine("'{0}' was converted to to {1}.", _
                           dateString, parsedDate.ToString())
      Else
         Console.WriteLine("Unable to parse '{0}'.", dateString)    
      End If
      
      ' Assume time is UTC
      If DateTimeOffset.TryParse(dateString, Nothing, _
                                 DateTimeStyles.AssumeUniversal, _
                                 parsedDate) Then
         Console.WriteLine("'{0}' was converted to to {1}.", _
                           dateString, parsedDate.ToString())
      Else
         Console.WriteLine("Unable to parse '{0}'.", dateString)    
      End If

      ' Parse and convert to UTC 
      dateString = "05/01/2008 6:00:00AM +5:00"
      If DateTimeOffset.TryParse(dateString, Nothing, _
                                 DateTimeStyles.AdjustToUniversal, _
                                 parsedDate) Then
         Console.WriteLine("'{0}' was converted to to {1}.", _
                           dateString, parsedDate.ToString())
      Else
         Console.WriteLine("Unable to parse '{0}'.", dateString)    
      End If
      ' The example displays the following output to the console:
      '    '05/01/2008 6:00:00' was converted to to 5/1/2008 6:00:00 AM -07:00.
      '    '05/01/2008 6:00:00' was converted to to 5/1/2008 6:00:00 AM +00:00.
      '    '05/01/2008 6:00:00AM +5:00' was converted to to 5/1/2008 1:00:00 AM +00:00.      
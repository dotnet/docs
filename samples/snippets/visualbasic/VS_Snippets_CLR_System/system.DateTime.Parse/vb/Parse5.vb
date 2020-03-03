
Imports System.Globalization

Public Module Class1
   Public Sub Main()
      ' <Snippet5>
      Dim formattedDates() = { "2008-09-15T09:30:41.7752486-07:00", 
                                 "2008-09-15T09:30:41.7752486Z",  
                                 "2008-09-15T09:30:41.7752486",  
                                 "2008-09-15T09:30:41.7752486-04:00", 
                                 "Mon, 15 Sep 2008 09:30:41 GMT" }
      For Each formattedDate In formattedDates
         Console.WriteLine(formattedDate)
         Dim roundtripDate = DateTime.Parse(formattedDate, Nothing,  
                                            DateTimeStyles.RoundtripKind)                        
         Console.WriteLine($"   With RoundtripKind flag: {roundtripDate} {roundtripDate.Kind} time.")                                          
         Dim noRoundtripDate = DateTime.Parse(formattedDate, Nothing,                                                                                                  DateTimeStyles.None)
         Console.WriteLine($"   Without RoundtripKind flag: {noRoundtripDate} {noRoundtripDate.Kind} time.")
      Next         
      ' The example displays the following output:
      '       2008-09-15T09:30:41.7752486-07:00
      '          With RoundtripKind flag: 9/15/2008 9:30:41 AM Local time.
      '          Without RoundtripKind flag: 9/15/2008 9:30:41 AM Local time.
      '       2008-09-15T09:30:41.7752486Z
      '          With RoundtripKind flag: 9/15/2008 9:30:41 AM Utc time.
      '          Without RoundtripKind flag: 9/15/2008 2:30:41 AM Local time.
      '       2008-09-15T09:30:41.7752486
      '          With RoundtripKind flag: 9/15/2008 9:30:41 AM Unspecified time.
      '          Without RoundtripKind flag: 9/15/2008 9:30:41 AM Unspecified time.
      '       2008-09-15T09:30:41.7752486-04:00
      '          With RoundtripKind flag: 9/15/2008 6:30:41 AM Local time.
      '          Without RoundtripKind flag: 9/15/2008 6:30:41 AM Local time.
      '       Mon, 15 Sep 2008 09:30:41 GMT
      '          With RoundtripKind flag: 9/15/2008 9:30:41 AM Utc time.
      '          Without RoundtripKind flag: 9/15/2008 2:30:41 AM Local time.      
      ' </Snippet5>
   End Sub
End Module

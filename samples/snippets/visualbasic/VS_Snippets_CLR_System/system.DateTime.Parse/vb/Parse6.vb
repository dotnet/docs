
Public Module Strings
   Public Sub Main()
      Dim dateInfo() As (dateAsString As String, description As String) = 
                     { ("08/18/2018 07:22:16", "String with a date and time component"),
                       ("08/18/2018", "String with a date component only"),
                       ("8/2018", "String with a month and year component only"),
                       ("8/18", "String with a month and day component only"),
                       ("07:22:16", "String with a time component only"),
                       ("7 PM", "String with an hour and AM/PM designator only"),
                       ("2018-08-18T07:22:16.0000000Z", "UTC string that conforms to ISO 8601"),   
                       ("2018-08-18T07:22:16.0000000-07:00", "Non-UTC string that conforms to ISO 8601"),
                       ("Sat, 18 Aug 2018 07:22:16 GMT", "String that conforms to RFC 1123"),
                       ("08/18/2018 07:22:16 -5:00", "String with date, time, and time zone information" ) }
   
      Console.WriteLine($"Today is {Date.Now:d}{vbCrLf}")
      
      For Each item in dateInfo
         Console.WriteLine($"{item.description + ":",-52} '{item.dateAsString}' --> {DateTime.Parse(item.dateAsString)}")        
      Next
   End Sub
End Module
' The example displays output like the following:
'   Today is 2/22/2018
'   
'   String with a date and time component:               '08/18/2018 07:22:16' --> 8/18/2018 7:22:16 AM
'   String with a date component only:                   '08/18/2018' --> 8/18/2018 12:00:00 AM
'   String with a month and year component only:         '8/2018' --> 8/1/2018 12:00:00 AM
'   String with a month and day component only:          '8/18' --> 8/18/2018 12:00:00 AM
'   String with a time component only:                   '07:22:16' --> 2/22/2018 7:22:16 AM
'   String with an hour and AM/PM designator only:       '7 PM' --> 2/22/2018 7:00:00 PM
'   UTC string that conforms to ISO 8601:                '2018-08-18T07:22:16.0000000Z' --> 8/18/2018 12:22:16 AM
'   Non-UTC string that conforms to ISO 8601:            '2018-08-18T07:22:16.0000000-07:00' --> 8/18/2018 7:22:16 AM
'   String that conforms to RFC 1123:                    'Sat, 18 Aug 2018 07:22:16 GMT' --> 8/18/2018 12:22:16 AM
'   String with date, time, and time zone information:   '08/18/2018 07:22:16 -5:00' --> 8/18/2018 5:22:16 AM


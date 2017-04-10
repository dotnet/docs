' Visual Basic .NET Document
Option Strict On

Imports System.Globalization

<Assembly: CLSCompliant(True)>
Module modMain
   Public Sub Main()
      ' <Snippet5>
         Dim formattedDates() As String = { "2008-09-15T09:30:41.7752486-07:00", _
                                            "2008-09-15T09:30:41.7752486Z", _ 
                                            "2008-09-15T09:30:41.7752486", _ 
                                            "2008-09-15T09:30:41.7752486-04:00", _
                                            "Mon, 15 Sep 2008 09:30:41 GMT" }
         For Each formattedDate As String In formattedDates
            Console.WriteLine(formattedDate)
            Dim roundtripDate As Date = Date.Parse(formattedDate, Nothing, _
                                                DateTimeStyles.RoundtripKind)                        
            Console.WriteLine("   With RoundtripKind flag: {0} {1} time.", _
                              roundtripDate, roundtripDate.Kind)                                          
            Dim noRoundtripDate As Date = Date.Parse(formattedDate, Nothing, _
                                                DateTimeStyles.None)
            Console.WriteLine("   Without RoundtripKind flag: {0} {1} time.", _
                               noRoundtripDate, noRoundtripDate.Kind)                                          
         Next         
      ' The example displays the following output:
      '       2008-09-15T09:30:41.7752486-07:00
      '          With RounndtripKind flag: 9/15/2008 9:30:41 AM Local time.
      '          Without RoundtripKind flag: 9/15/2008 9:30:41 AM Local time.
      '       2008-09-15T09:30:41.7752486Z
      '          With RounndtripKind flag: 9/15/2008 9:30:41 AM Utc time.
      '          Without RoundtripKind flag: 9/15/2008 2:30:41 AM Local time.
      '       2008-09-15T09:30:41.7752486
      '          With RounndtripKind flag: 9/15/2008 9:30:41 AM Unspecified time.
      '          Without RoundtripKind flag: 9/15/2008 9:30:41 AM Unspecified time.
      '       2008-09-15T09:30:41.7752486-04:00
      '          With RounndtripKind flag: 9/15/2008 6:30:41 AM Local time.
      '          Without RoundtripKind flag: 9/15/2008 6:30:41 AM Local time.
      '       Mon, 15 Sep 2008 09:30:41 GMT
      '          With RounndtripKind flag: 9/15/2008 9:30:41 AM Utc time.
      '          Without RoundtripKind flag: 9/15/2008 2:30:41 AM Local time.      
      ' </Snippet5>
   End Sub
End Module


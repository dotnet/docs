' Visual Basic .NET Document
Option Strict On

Imports System.Globalization
Imports System.IO

Module modMain

   Public Sub Main()
      ParseExact1()
      Console.WriteLine()
      ParseExact2()
      Console.WriteLine()
      ParseExact3()
   End Sub
   
   Private Sub ParseExact1()
      ' <Snippet1>
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
      ' </Snippet1>
   End Sub

   Private Sub ParseExact2()
      ' <Snippet2>
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
      ' </Snippet2>
   End Sub

   Private Sub ParseExact3()
      ' <Snippet3>
      Dim conIn As TextReader = Console.In
      Dim conOut As TextWriter = Console.Out
      Dim tries As Integer = 0
      Dim input As String = String.Empty
      Dim formats() As String = {"M/dd/yyyy HH:m zzz", "MM/dd/yyyy HH:m zzz", _
                                 "M/d/yyyy HH:m zzz", "MM/d/yyyy HH:m zzz", _
                                 "M/dd/yy HH:m zzz", "MM/dd/yy HH:m zzz", _
                                 "M/d/yy HH:m zzz", "MM/d/yy HH:m zzz", _                                 
                                 "M/dd/yyyy H:m zzz", "MM/dd/yyyy H:m zzz", _
                                 "M/d/yyyy H:m zzz", "MM/d/yyyy H:m zzz", _
                                 "M/dd/yy H:m zzz", "MM/dd/yy H:m zzz", _
                                 "M/d/yy H:m zzz", "MM/d/yy H:m zzz", _                               
                                 "M/dd/yyyy HH:mm zzz", "MM/dd/yyyy HH:mm zzz", _
                                 "M/d/yyyy HH:mm zzz", "MM/d/yyyy HH:mm zzz", _
                                 "M/dd/yy HH:mm zzz", "MM/dd/yy HH:mm zzz", _
                                 "M/d/yy HH:mm zzz", "MM/d/yy HH:mm zzz", _                                 
                                 "M/dd/yyyy H:mm zzz", "MM/dd/yyyy H:mm zzz", _
                                 "M/d/yyyy H:mm zzz", "MM/d/yyyy H:mm zzz", _
                                 "M/dd/yy H:mm zzz", "MM/dd/yy H:mm zzz", _
                                 "M/d/yy H:mm zzz", "MM/d/yy H:mm zzz"}   
      Dim provider As IFormatProvider = CultureInfo.InvariantCulture.DateTimeFormat
      Dim result As DateTimeOffset
     
      Do 
         conOut.WriteLine("Enter a date, time, and offset (MM/DD/YYYY HH:MM +/-HH:MM),")
         conOut.Write("Then press Enter: ")
         input = conIn.ReadLine()
         conOut.WriteLine() 
         Try
            result = DateTimeOffset.ParseExact(input, formats, provider, _
                                               DateTimeStyles.AllowWhiteSpaces)
            Exit Do
         Catch e As FormatException
            Console.WriteLine("Unable to parse {0}.", input)      
            tries += 1
         End Try
      Loop While tries < 3
      If tries >= 3 Then
         Console.WriteLine("Exiting application without parsing {0}", input)
      Else
         Console.WriteLine("{0} was converted to {1}", input, result.ToString())                                                     
      End If 
      ' Some successful sample interactions with the user might appear as follows:
      '    Enter a date, time, and offset (MM/DD/YYYY HH:MM +/-HH:MM),
      '    Then press Enter: 12/08/2007 6:54 -6:00
      '    
      '    12/08/2007 6:54 -6:00 was converted to 12/8/2007 6:54:00 AM -06:00         
      '    
      '    Enter a date, time, and offset (MM/DD/YYYY HH:MM +/-HH:MM),
      '    Then press Enter: 12/8/2007 06:54 -06:00
      '    
      '    12/8/2007 06:54 -06:00 was converted to 12/8/2007 6:54:00 AM -06:00
      '    
      '    Enter a date, time, and offset (MM/DD/YYYY HH:MM +/-HH:MM),
      '    Then press Enter: 12/5/07 6:54 -6:00
      '    
      '    12/5/07 6:54 -6:00 was converted to 12/5/2007 6:54:00 AM -06:00 
      ' </Snippet3>
   End Sub
End Module


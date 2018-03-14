' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim intervalString, format As String
      Dim interval As TimeSpan
      Dim culture As CultureInfo = Nothing
      
      ' Parse hour:minute value with custom format specifier.
      intervalString = "17:14"
      format = "h\:mm"
      culture = CultureInfo.CurrentCulture
      Try
         interval = TimeSpan.ParseExact(intervalString, format, 
                                        culture, TimeSpanStyles.AssumeNegative)
         Console.WriteLine("'{0}' ({1}) --> {2}", intervalString, format, interval)
      Catch e As FormatException
         Console.WriteLine("'{0}': Bad Format for '{1}'", intervalString, format)
      Catch e As OverflowException
         Console.WriteLine("'{0}': Overflow", intervalString)
      End Try      
      
      ' Parse hour:minute:second value with "g" specifier.
      intervalString = "17:14:48"
      format = "g"
      culture = CultureInfo.InvariantCulture
      Try
         interval = TimeSpan.ParseExact(intervalString, format, 
                                        culture, TimeSpanStyles.AssumeNegative)
         Console.WriteLine("'{0}' ({1}) --> {2}", intervalString, format, interval)
      Catch e As FormatException
         Console.WriteLine("'{0}': Bad Format for '{1}'", intervalString, format)
      Catch e As OverflowException
         Console.WriteLine("'{0}': Overflow", intervalString)
      End Try 
      
      ' Parse hours:minute.second value with custom format specifier.     
      intervalString = "17:14:48.153"
      format = "h\:mm\:ss\.fff"
      culture = Nothing
      Try
         interval = TimeSpan.ParseExact(intervalString, format, 
                                        culture, TimeSpanStyles.AssumeNegative)
         Console.WriteLine("'{0}' ({1}) --> {2}", intervalString, format, interval)
      Catch e As FormatException
         Console.WriteLine("'{0}': Bad Format for '{1}'", intervalString, format)
      Catch e As OverflowException
         Console.WriteLine("'{0}': Overflow", intervalString)
      End Try 

      ' Parse days:hours:minute.second value with "G" specifier 
      ' and current (en-US) culture.     
      intervalString = "3:17:14:48.153"
      format = "G"
      culture = CultureInfo.CurrentCulture
      Try
         interval = TimeSpan.ParseExact(intervalString, format, 
                                        culture, TimeSpanStyles.AssumeNegative)
         Console.WriteLine("'{0}' ({1}) --> {2}", intervalString, format, interval)
      Catch e As FormatException
         Console.WriteLine("'{0}': Bad Format for '{1}'", intervalString, format)
      Catch e As OverflowException
         Console.WriteLine("'{0}': Overflow", intervalString)
      End Try 
            
      ' Parse days:hours:minute.second value with a custom format specifier.     
      intervalString = "3:17:14:48.153"
      format = "d\:hh\:mm\:ss\.fff"
      culture = Nothing
      Try
         interval = TimeSpan.ParseExact(intervalString, format, 
                                        culture, TimeSpanStyles.AssumeNegative)
         Console.WriteLine("'{0}' ({1}) --> {2}", intervalString, format, interval)
      Catch e As FormatException
         Console.WriteLine("'{0}': Bad Format for '{1}'", intervalString, format)
      Catch e As OverflowException
         Console.WriteLine("'{0}': Overflow", intervalString)
      End Try 
      
      ' Parse days:hours:minute.second value with "G" specifier 
      ' and fr-FR culture.     
      intervalString = "3:17:14:48,153"
      format = "G"
      culture = New CultureInfo("fr-FR")
      Try
         interval = TimeSpan.ParseExact(intervalString, format, 
                                        culture, TimeSpanStyles.AssumeNegative)
         Console.WriteLine("'{0}' ({1}) --> {2}", intervalString, format, interval)
      Catch e As FormatException
         Console.WriteLine("'{0}': Bad Format for '{1}'", intervalString, format)
      Catch e As OverflowException
         Console.WriteLine("'{0}': Overflow", intervalString)
      End Try 

      ' Parse a single number using the "c" standard format string. 
      intervalString = "12"
      format = "c"
      Try
         interval = TimeSpan.ParseExact(intervalString, format, 
                                        Nothing, TimeSpanStyles.AssumeNegative)
         Console.WriteLine("'{0}' ({1}) --> {2}", intervalString, format, interval)
      Catch e As FormatException
         Console.WriteLine("'{0}': Bad Format for '{1}'", intervalString, format)
      Catch e As OverflowException
         Console.WriteLine("'{0}': Overflow", intervalString)
      End Try 
      
      ' Parse a single number using the "%h" custom format string. 
      format = "%h"
      Try
         interval = TimeSpan.ParseExact(intervalString, format, 
                                        Nothing, TimeSpanStyles.AssumeNegative)
         Console.WriteLine("'{0}' ({1}) --> {2}", intervalString, format, interval)
      Catch e As FormatException
         Console.WriteLine("'{0}': Bad Format for '{1}'", intervalString, format)
      Catch e As OverflowException
         Console.WriteLine("'{0}': Overflow", intervalString)
      End Try 
      
      ' Parse a single number using the "%s" custom format string. 
      format = "%s"
      Try
         interval = TimeSpan.ParseExact(intervalString, format, 
                                        Nothing, TimeSpanStyles.AssumeNegative)
         Console.WriteLine("'{0}' ({1}) --> {2}", intervalString, format, interval)
      Catch e As FormatException
         Console.WriteLine("'{0}': Bad Format for '{1}'", intervalString, format)
      Catch e As OverflowException
         Console.WriteLine("'{0}': Overflow", intervalString)
      End Try 
   End Sub
End Module
' The example displays the following output:
'    '17:14' (h\:mm) --> -17:14:00
'    '17:14:48' (g) --> 17:14:48
'    '17:14:48.153' (h\:mm\:ss\.fff) --> -17:14:48.1530000
'    '3:17:14:48.153' (G) --> 3.17:14:48.1530000
'    '3:17:14:48.153' (d\:hh\:mm\:ss\.fff) --> -3.17:14:48.1530000
'    '3:17:14:48,153' (G) --> 3.17:14:48.1530000
'    '12' (c) --> 12.00:00:00
'    '12' (%h) --> -12:00:00
'    '12' (%s) --> -00:00:12
' </Snippet2>

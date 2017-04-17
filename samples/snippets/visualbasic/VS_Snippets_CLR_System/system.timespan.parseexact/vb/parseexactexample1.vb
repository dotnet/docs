' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim intervalString, format As String
      Dim interval As TimeSpan
      Dim culture As CultureInfo
      
      ' Parse hour:minute value with "g" specifier current culture.
      intervalString = "17:14"
      format = "g"
      culture = CultureInfo.CurrentCulture
      Try
         interval = TimeSpan.ParseExact(intervalString, format, culture)
         Console.WriteLine("'{0}' --> {1}", intervalString, interval)
      Catch e As FormatException
         Console.WriteLine("'{0}': Bad Format for '{1}'", intervalString, format)
      Catch e As OverflowException
         Console.WriteLine("'{0}': Overflow", intervalString)
      End Try      
      
      ' Parse hour:minute:second value with "G" specifier.
      intervalString = "17:14:48"
      format = "G"
      culture = CultureInfo.InvariantCulture
      Try
         interval = TimeSpan.ParseExact(intervalString, format, culture)
         Console.WriteLine("'{0}' --> {1}", intervalString, interval)
      Catch e As FormatException
         Console.WriteLine("'{0}': Bad Format for '{1}'", intervalString, format)
      Catch e As OverflowException
         Console.WriteLine("'{0}': Overflow", intervalString)
      End Try 
      
      ' Parse hours:minute.second value with "G" specifier 
      ' and current (en-US) culture.     
      intervalString = "17:14:48.153"
      format = "G"
      culture = CultureInfo.CurrentCulture
      Try
         interval = TimeSpan.ParseExact(intervalString, format, culture)
         Console.WriteLine("'{0}' --> {1}", intervalString, interval)
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
         interval = TimeSpan.ParseExact(intervalString, format, culture)
         Console.WriteLine("'{0}' --> {1}", intervalString, interval)
      Catch e As FormatException
         Console.WriteLine("'{0}': Bad Format for '{1}'", intervalString, format)
      Catch e As OverflowException
         Console.WriteLine("'{0}': Overflow", intervalString)
      End Try 
            
      ' Parse days:hours:minute.second value with "G" specifier 
      ' and fr-FR culture.     
      intervalString = "3:17:14:48.153"
      format = "G"
      culture = New CultureInfo("fr-FR")
      Try
         interval = TimeSpan.ParseExact(intervalString, format, culture)
         Console.WriteLine("'{0}' --> {1}", intervalString, interval)
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
         interval = TimeSpan.ParseExact(intervalString, format, culture)
         Console.WriteLine("'{0}' --> {1}", intervalString, interval)
      Catch e As FormatException
         Console.WriteLine("'{0}': Bad Format for '{1}'", intervalString, format)
      Catch e As OverflowException
         Console.WriteLine("'{0}': Overflow", intervalString)
      End Try 

      ' Parse a single number using the "c" standard format string. 
      intervalString = "12"
      format = "c"
      Try
         interval = TimeSpan.ParseExact(intervalString, format, Nothing)
         Console.WriteLine("'{0}' --> {1}", intervalString, interval)
      Catch e As FormatException
         Console.WriteLine("'{0}': Bad Format for '{1}'", intervalString, format)
      Catch e As OverflowException
         Console.WriteLine("'{0}': Overflow", intervalString)
      End Try 
      
      ' Parse a single number using the "%h" custom format string. 
      format = "%h"
      Try
         interval = TimeSpan.ParseExact(intervalString, format, Nothing)
         Console.WriteLine("'{0}' --> {1}", intervalString, interval)
      Catch e As FormatException
         Console.WriteLine("'{0}': Bad Format for '{1}'", intervalString, format)
      Catch e As OverflowException
         Console.WriteLine("'{0}': Overflow", intervalString)
      End Try 
      
      ' Parse a single number using the "%s" custom format string. 
      format = "%s"
      Try
         interval = TimeSpan.ParseExact(intervalString, format, Nothing)
         Console.WriteLine("'{0}' --> {1}", intervalString, interval)
      Catch e As FormatException
         Console.WriteLine("'{0}': Bad Format for '{1}'", intervalString, format)
      Catch e As OverflowException
         Console.WriteLine("'{0}': Overflow", intervalString)
      End Try 
   End Sub
End Module
' The example displays the following output:
'       '17:14' --> 17:14:00
'       '17:14:48': Bad Format for 'G'
'       '17:14:48.153': Bad Format for 'G'
'       '3:17:14:48.153' --> 3.17:14:48.1530000
'       '3:17:14:48.153': Bad Format for 'G'
'       '3:17:14:48,153' --> 3.17:14:48.1530000
'       '12' --> 12.00:00:00
'       '12' --> 12:00:00
'       '12' --> 00:00:12
' </Snippet1>

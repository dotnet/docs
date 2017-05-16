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
      If TimeSpan.TryParseExact(intervalString, format, culture, interval) Then
         Console.WriteLine("'{0}' --> {1}", intervalString, interval)
      Else
         Console.WriteLine("Unable to parse {0}", intervalString)
      End If
      
      ' Parse hour:minute:second value with "G" specifier.
      intervalString = "17:14:48"
      format = "G"
      culture = CultureInfo.InvariantCulture
      If TimeSpan.TryParseExact(intervalString, format, culture, interval) Then
         Console.WriteLine("'{0}' --> {1}", intervalString, interval)
      Else
         Console.WriteLine("Unable to parse {0}", intervalString)
      End If

      ' Parse hours:minute.second value with "G" specifier 
      ' and current (en-US) culture.     
      intervalString = "17:14:48.153"
      format = "G"
      culture = CultureInfo.CurrentCulture
      If TimeSpan.TryParseExact(intervalString, format, culture, interval) Then
         Console.WriteLine("'{0}' --> {1}", intervalString, interval)
      Else
         Console.WriteLine("Unable to parse {0}", intervalString)
      End If

      ' Parse days:hours:minute.second value with "G" specifier 
      ' and current (en-US) culture.     
      intervalString = "3:17:14:48.153"
      format = "G"
      culture = CultureInfo.CurrentCulture
      If TimeSpan.TryParseExact(intervalString, format, culture, interval) Then
         Console.WriteLine("'{0}' --> {1}", intervalString, interval)
      Else
         Console.WriteLine("Unable to parse {0}", intervalString)
      End If
            
      ' Parse days:hours:minute.second value with "G" specifier 
      ' and fr-FR culture.     
      intervalString = "3:17:14:48.153"
      format = "G"
      culture = New CultureInfo("fr-FR")
      If TimeSpan.TryParseExact(intervalString, format, culture, interval) Then
         Console.WriteLine("'{0}' --> {1}", intervalString, interval)
      Else
         Console.WriteLine("Unable to parse {0}", intervalString)
      End If
      
      ' Parse days:hours:minute.second value with "G" specifier 
      ' and fr-FR culture.     
      intervalString = "3:17:14:48,153"
      format = "G"
      culture = New CultureInfo("fr-FR")
      If TimeSpan.TryParseExact(intervalString, format, culture, interval) Then
         Console.WriteLine("'{0}' --> {1}", intervalString, interval)
      Else
         Console.WriteLine("Unable to parse {0}", intervalString)
      End If

      ' Parse a single number using the "c" standard format string. 
      intervalString = "12"
      format = "c"
      If TimeSpan.TryParseExact(intervalString, format, Nothing, interval)
         Console.WriteLine("'{0}' --> {1}", intervalString, interval)
      Else
         Console.WriteLine("Unable to parse {0}", intervalString)
      End If
      
      ' Parse a single number using the "%h" custom format string. 
      format = "%h"
      If TimeSpan.TryParseExact(intervalString, format, Nothing, interval)
         Console.WriteLine("'{0}' --> {1}", intervalString, interval)
      Else
         Console.WriteLine("Unable to parse {0}", intervalString)
      End If
      
      ' Parse a single number using the "%s" custom format string. 
      format = "%s"
      If TimeSpan.TryParseExact(intervalString, format, Nothing, interval) Then
         Console.WriteLine("'{0}' --> {1}", intervalString, interval)
      Else
         Console.WriteLine("Unable to parse {0}", intervalString)
      End If
   End Sub
End Module
' The example displays the following output:
'       '17:14' --> 17:14:00
'       Unable to parse 17:14:48
'       Unable to parse 17:14:48.153
'       '3:17:14:48.153' --> 3.17:14:48.1530000
'       Unable to parse 3:17:14:48.153
'       '3:17:14:48,153' --> 3.17:14:48.1530000
'       '12' --> 12.00:00:00
'       '12' --> 12:00:00
'       '12' --> 00:00:12
' </Snippet1>

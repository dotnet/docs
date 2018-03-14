' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim minutes() As Double = {.01667, .08333, .16667, .25, .33333, 
                                 .5, .66667, 1, 2, 15, 30, 17, 45, 
                                 60, 180, 60 * 24 }
      Dim dateValue As Date = #9/15/2013 12:00#
      
      For Each minute As Double In minutes
         Console.WriteLine("{0} + {1} minute(s) = {2}", dateValue, 
                           minute, dateValue.AddMinutes(minute))
      Next                             
   End Sub
End Module
' The example displays the following output on a system whose current culture is en-US:
'    9/15/2013 12:00:00 PM + 0.01667 minute(s) = 9/15/2013 12:00:01 PM
'    9/15/2013 12:00:00 PM + 0.08333 minute(s) = 9/15/2013 12:00:05 PM
'    9/15/2013 12:00:00 PM + 0.16667 minute(s) = 9/15/2013 12:00:10 PM
'    9/15/2013 12:00:00 PM + 0.25 minute(s) = 9/15/2013 12:00:15 PM
'    9/15/2013 12:00:00 PM + 0.33333 minute(s) = 9/15/2013 12:00:20 PM
'    9/15/2013 12:00:00 PM + 0.5 minute(s) = 9/15/2013 12:00:30 PM
'    9/15/2013 12:00:00 PM + 0.66667 minute(s) = 9/15/2013 12:00:40 PM
'    9/15/2013 12:00:00 PM + 1 minute(s) = 9/15/2013 12:01:00 PM
'    9/15/2013 12:00:00 PM + 2 minute(s) = 9/15/2013 12:02:00 PM
'    9/15/2013 12:00:00 PM + 15 minute(s) = 9/15/2013 12:15:00 PM
'    9/15/2013 12:00:00 PM + 30 minute(s) = 9/15/2013 12:30:00 PM
'    9/15/2013 12:00:00 PM + 17 minute(s) = 9/15/2013 12:17:00 PM
'    9/15/2013 12:00:00 PM + 45 minute(s) = 9/15/2013 12:45:00 PM
'    9/15/2013 12:00:00 PM + 60 minute(s) = 9/15/2013 1:00:00 PM
'    9/15/2013 12:00:00 PM + 180 minute(s) = 9/15/2013 3:00:00 PM
'    9/15/2013 12:00:00 PM + 1440 minute(s) = 9/16/2013 12:00:00 PM
' </Snippet1>

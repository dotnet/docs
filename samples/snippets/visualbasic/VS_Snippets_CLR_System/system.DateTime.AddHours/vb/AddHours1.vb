' Visual Basic .NET Document
Option Strict On


' <Snippet1>
Module Example
   Public Sub Main()
      Dim hours() As Double = {.08333, .16667, .25, .33333, .5, .66667, 1, 2, _
                             29, 30, 31, 90, 365}
      Dim dateValue As Date = #3/1/2009 12:00#
      
      For Each hour As Double In hours
         Console.WriteLine("{0} + {1} hour(s) = {2}", dateValue, hour, _
                           dateValue.AddHours(hour))
      Next                             
   End Sub
End Module
' The example displays the following output on a system whose current
' culture is en-US:
' 3/1/2009 12:00:00 PM + 0.08333 hour(s) = 3/1/2009 12:04:59 PM
' 3/1/2009 12:00:00 PM + 0.16667 hour(s) = 3/1/2009 12:10:00 PM
' 3/1/2009 12:00:00 PM + 0.25 hour(s) = 3/1/2009 12:15:00 PM
' 3/1/2009 12:00:00 PM + 0.33333 hour(s) = 3/1/2009 12:19:59 PM
' 3/1/2009 12:00:00 PM + 0.5 hour(s) = 3/1/2009 12:30:00 PM
' 3/1/2009 12:00:00 PM + 0.66667 hour(s) = 3/1/2009 12:40:00 PM
' 3/1/2009 12:00:00 PM + 1 hour(s) = 3/1/2009 1:00:00 PM
' 3/1/2009 12:00:00 PM + 2 hour(s) = 3/1/2009 2:00:00 PM
' 3/1/2009 12:00:00 PM + 29 hour(s) = 3/2/2009 5:00:00 PM
' 3/1/2009 12:00:00 PM + 30 hour(s) = 3/2/2009 6:00:00 PM
' 3/1/2009 12:00:00 PM + 31 hour(s) = 3/2/2009 7:00:00 PM
' 3/1/2009 12:00:00 PM + 90 hour(s) = 3/5/2009 6:00:00 AM
' 3/1/2009 12:00:00 PM + 365 hour(s) = 3/16/2009 5:00:00 PM
' </Snippet1>

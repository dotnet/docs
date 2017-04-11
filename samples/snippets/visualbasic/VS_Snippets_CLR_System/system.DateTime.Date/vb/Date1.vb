' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim date1 As Date = #6/1/2008 7:47AM#
      Console.WriteLine(date1.ToString())
      
      ' Get date-only portion of date, without its time.
      Dim dateOnly As Date = date1.Date
      ' Display date using short date string.
      Console.WriteLine(dateOnly.ToString("d"))
      ' Display date using 24-hour clock.
      Console.WriteLine(dateOnly.ToString("g"))
      Console.WriteLine(dateOnly.ToString("MM/dd/yyyy HH:mm"))   
   End Sub
End Module
' The example displays output like the following:
'       6/1/2008 7:47:00 AM                     
'       6/1/2008
'       6/1/2008 12:00 AM
'       06/01/2008 00:00
' </Snippet1>


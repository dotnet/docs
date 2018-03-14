' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Globalization
Imports System.Threading

Module Example
   Public Sub Main()
      Dim date1 As Date = #1/1/550#
      Dim dft As CultureInfo
      Dim arSY As New CultureInfo("ar-SY")
      arSY.DateTimeFormat.Calendar = New HijriCalendar()
      
      ' Change current culture to ar-SY.
      dft = Thread.CurrentThread.CurrentCulture
      Thread.CurrentThread.CurrentCulture = arSY
      
      ' Display the date using the current culture's calendar.            
      Try
         Console.WriteLine(date1.ToString())
      Catch e As ArgumentOutOfRangeException
         Console.WriteLine("{0} is earlier than {1} or later than {2}", _
                           date1.ToString("d", CultureInfo.InvariantCulture), _
                           arSY.DateTimeFormat.Calendar.MinSupportedDateTime.ToString("d", CultureInfo.InvariantCulture), _ 
                           arSY.DateTimeFormat.Calendar.MaxSupportedDateTime.ToString("d", CultureInfo.InvariantCulture)) 
      End Try
      
      ' Restore the default culture.
      Thread.CurrentThread.CurrentCulture = dft
   End Sub
End Module
' The example displays the following output:
'    01/01/0550 is earlier than 07/18/0622 or later than 12/31/9999
' </Snippet2>

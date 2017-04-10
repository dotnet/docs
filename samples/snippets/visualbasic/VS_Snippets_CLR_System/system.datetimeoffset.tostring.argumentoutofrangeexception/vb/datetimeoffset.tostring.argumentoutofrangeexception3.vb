' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.Globalization
Imports System.Threading

Module Example
   Public Sub Main()
      Dim date1 As New DateTimeOffset(#7/21/1550#, TimeSpan.Zero)
      Dim dft As CultureInfo
      Dim heIL As New CultureInfo("he-IL")
      heIL.DateTimeFormat.Calendar = New HebrewCalendar()
      
      ' Change current culture to he-IL.
      dft = Thread.CurrentThread.CurrentCulture
      Thread.CurrentThread.CurrentCulture = heIL
      
      ' Display the date using the current culture's calendar.            
      Try
         Console.WriteLine(date1.ToString("G"))
      Catch e As ArgumentOutOfRangeException
         Console.WriteLine("{0} is earlier than {1} or later than {2}", _
                           date1.ToString("d", CultureInfo.InvariantCulture), _
                           heIL.DateTimeFormat.Calendar.MinSupportedDateTime.ToString("d", CultureInfo.InvariantCulture), _ 
                           heIL.DateTimeFormat.Calendar.MaxSupportedDateTime.ToString("d", CultureInfo.InvariantCulture)) 
      End Try
      
      ' Restore the default culture.
      Thread.CurrentThread.CurrentCulture = dft
   End Sub
End Module
' The example displays the following output:
'    07/21/1550 is earlier than 01/01/1583 or later than 09/29/2239
' </Snippet3>

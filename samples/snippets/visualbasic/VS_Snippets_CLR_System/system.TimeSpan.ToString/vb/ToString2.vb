' Visual Basic .NET Document
Option Strict On

<Assembly: CLSCompliant(True)>
' <Snippet2>
Module ToString
   Public Sub Main()
      Dim span As TimeSpan
      
      ' Initialize a time span to zero.
      span = TimeSpan.Zero
      Console.WriteLine(FormatTimeSpan(span, True))
      
      ' Initialize a time span to 14 days.
      span = New TimeSpan(-14, 0, 0, 0, 0)
      Console.WriteLine(FormatTimeSpan(span, True))
     
      ' Initialize a time span to 1:02:03.
      span = New TimeSpan(1, 2, 3)
      Console.WriteLine(FormatTimeSpan(span, False))
      
      
      ' Initialize a time span to 250 milliseconds.
      span = New TimeSpan(0, 0, 0, 0, 250)
      Console.WriteLine(FormatTimeSpan(span, True))
      
      ' Initalize a time span to 99 days, 23 hours, 59 minutes, and 59.9999999 seconds.
      span = New TimeSpan(99, 23, 59, 59, 999)
      Console.WriteLine(FormatTimeSpan(span, False))

      ' Initalize a timespan to 25 milliseconds.
      span = New TimeSpan(0, 0, 0, 0, 25)
      Console.WriteLine(FormatTimeSpan(span, False))
   End Sub

   Private Function FormatTimeSpan(span As TimeSpan, showSign As Boolean) As String
      Dim sign As String = String.Empty
      If showSign And (span > TimeSpan.Zero) Then sign = "+"  
      
      Return sign & span.Days.ToString("00") & "." & _
             span.Hours.ToString("00") & ":" & _
             span.Minutes.ToString("00") & ":" & _
             span.Seconds.ToString("00") & "." & _
             span.Milliseconds.ToString("000")
   End Function
End Module
' The example displays the following output:
'       00.00:00:00.000
'       -14.00:00:00.000
'       00.01:02:03.000
'       +00.00:00:00.250
'       99.23:59:59.999
'       00.00:00:00.025
' </Snippet2>
 

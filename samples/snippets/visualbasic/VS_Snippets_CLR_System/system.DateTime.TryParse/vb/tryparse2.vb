Option Strict On

' <Snippet2>
Imports System.Globalization

Public Module Example
   Public Sub Main()
      Dim dateString As String
      Dim culture As CultureInfo
      Dim styles As DateTimeStyles 
      Dim dateResult As DateTime
      
      ' Parse a date and time with no styles.
      dateString = "03/01/2009 10:00 AM"
      culture = CultureInfo.CreateSpecificCulture("en-US")
      styles = DateTimeStyles.None
      If DateTime.TryParse(dateString, culture, styles, dateResult) Then
         Console.WriteLine("{0} converted to {1} {2}.", _
                           dateString, dateResult, dateResult.Kind)
      Else
         Console.WriteLine("Unable to convert {0} to a date and time.", dateString)
      End If      
      
      ' Parse the same date and time with the AssumeLocal style.
      styles = DateTimeStyles.AssumeLocal
      If DateTime.TryParse(dateString, culture, styles, dateResult)
         Console.WriteLine("{0} converted to {1} {2}.", _
                           dateString, dateResult, dateResult.Kind)
      Else
         Console.WriteLine("Unable to convert {0} to a date and time.", dateString)
      End If      
      
      ' Parse a date and time that is assumed to be local.
      ' This time is five hours behind UTC. The local system's time zone is 
      ' eight hours behind UTC.
      dateString = "2009/03/01T10:00:00-5:00"
      styles = DateTimeStyles.AssumeLocal
      If DateTime.TryParse(dateString, culture, styles, dateResult)
         Console.WriteLine("{0} converted to {1} {2}.", _
                           dateString, dateResult, dateResult.Kind)
      Else
         Console.WriteLine("Unable to convert {0} to a date and time.", dateString)
      End If      
      
      ' Attempt to convert a string in improper ISO 8601 format.
      dateString = "03/01/2009T10:00:00-5:00"
      If DateTime.TryParse(dateString, culture, styles, dateResult)
         Console.WriteLine("{0} converted to {1} {2}.", _
                           dateString, dateResult, dateResult.Kind)
      Else
         Console.WriteLine("Unable to convert {0} to a date and time.", dateString)
      End If      

      ' Assume a date and time string formatted for the fr-FR culture is the local 
      ' time and convert it to UTC.
      dateString = "2008-03-01 10:00"
      culture = CultureInfo.CreateSpecificCulture("fr-FR")
      styles = DateTimeStyles.AdjustToUniversal Or DateTimeStyles.AssumeLocal
      If DateTime.TryParse(dateString, culture, styles, dateResult)
         Console.WriteLine("{0} converted to {1} {2}.", _
                           dateString, dateResult, dateResult.Kind)
      Else
         Console.WriteLine("Unable to convert {0} to a date and time.", dateString)
      End If      
   End Sub
End Module
' The example displays the following output to the console:
'       03/01/2009 10:00 AM converted to 3/1/2009 10:00:00 AM Unspecified.
'       03/01/2009 10:00 AM converted to 3/1/2009 10:00:00 AM Local.
'       2009/03/01T10:00:00-5:00 converted to 3/1/2009 7:00:00 AM Local.
'       Unable to convert 03/01/2009T10:00:00-5:00 to a date and time.
'       2008-03-01 10:00 converted to 3/1/2008 6:00:00 PM Utc.
' </Snippet2>

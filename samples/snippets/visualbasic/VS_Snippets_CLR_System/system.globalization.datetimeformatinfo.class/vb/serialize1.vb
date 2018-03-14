' Visual Basic .NET Document
Option Strict On

' <Snippet17>
Imports System.Globalization
Imports System.IO

Module Example
   Public Sub Main()
      Dim sw As New StreamWriter(".\DateData.dat")
      ' Define a date and time to serialize.
      Dim originalDate As New Date(2014, 08, 18, 08, 16, 35)
      ' Display information on the date and time.
      Console.WriteLine("Date to serialize: {0:F}", originalDate)
      Console.WriteLine("Current Culture:   {0}", 
                        CultureInfo.CurrentCulture.Name)
      Console.WriteLine("Time Zone:         {0}", 
                        TimeZoneInfo.Local.DisplayName)
      ' Convert the date value to UTC.
      Dim utcDate As Date = originalDate.ToUniversalTime()
      ' Serialize the UTC value.
      sw.Write(utcDate.ToString("o", DateTimeFormatInfo.InvariantInfo))
      sw.Close()
   End Sub
End Module
' The example displays the following output:
'       Date to serialize: Monday, August 18, 2014 8:16:35 AM
'       Current Culture:   en-US
'       Time Zone:         (UTC-08:00) Pacific Time (US & Canada)
' </Snippet17>

' Visual Basic .NET Document
Option Strict On

' <Snippet18>
Imports System.Globalization
Imports System.IO

Module Example
   Public Sub Main()
      ' Open the file and retrieve the date string.
      Dim sr As New StreamReader(".\DateData.dat")             
      Dim dateValue As String = sr.ReadToEnd()
      
      ' Parse the date.
      Dim parsedDate As Date = Date.ParseExact(dateValue, "o", 
                               DateTimeFormatInfo.InvariantInfo)
      ' Convert it to local time.                             
      Dim restoredDate As Date = parsedDate.ToLocalTime()
      ' Display information on the date and time.
      Console.WriteLine("Deserialized date: {0:F}", restoredDate)
      Console.WriteLine("Current Culture:   {0}", 
                        CultureInfo.CurrentCulture.Name)
      Console.WriteLine("Time Zone:         {0}", 
                        TimeZoneInfo.Local.DisplayName)
   End Sub
End Module
' The example displays the following output:
'    Deserialized date: lundi 18 août 2014 17:16:35
'    Current Culture:   fr-FR
'    Time Zone:         (UTC+01:00) Brussels, Copenhagen, Madrid, Paris
' </Snippet18>

' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Globalization
Imports System.IO
Imports System.Threading

Module Example
   Private Const filename As String = ".\Dates.txt"

   Public Sub Main()
      If Not File.Exists(filename) Then
         SaveDates()
      Else
         RestoreDates()
      End If
   End Sub

   Private Sub SaveDates()
      Dim dates() As Date = { #6/14/2014 6:32AM#, #7/10/2014 11:49PM#, 
                              #1/10/2015 1:16AM#, #12/20/2014 9:45PM#,
                              #6/2/2014 3:14PM# }
      Dim output As String = Nothing
 
      Console.WriteLine("Current Time Zone: {0}",
                        TimeZoneInfo.Local.DisplayName)
      Console.WriteLine("The dates on an {0} system:", 
                        Thread.CurrentThread.CurrentCulture.Name)
      For ctr As Integer = 0 To dates.Length - 1 
         Console.WriteLine(dates(ctr).ToString("f"))
         output += dates(ctr).ToUniversalTime().ToString("O", CultureInfo.InvariantCulture) + 
                                       If(ctr <> dates.Length - 1, "|", "")
      Next
      Dim sw As New StreamWriter(filename)
      sw.Write(output)
      sw.Close()
      Console.WriteLine("Saved dates...")
   End Sub

   Private Sub RestoreDates()
      TimeZoneInfo.ClearCachedData()
      Console.WriteLine("Current Time Zone: {0}",
                        TimeZoneInfo.Local.DisplayName)
      Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB")
      Dim sr As New StreamReader(filename)
      Dim inputValues() As String = sr.ReadToEnd().Split( {"|"c} , StringSplitOptions.RemoveEmptyEntries)
      sr.Close()
      Console.WriteLine("The dates on an {0} system:", 
                        Thread.CurrentThread.CurrentCulture.Name)
      For Each inputValue In inputValues
         Dim dateValue As Date
         If DateTime.TryParseExact(inputValue, "O", CultureInfo.InvariantCulture, 
                              DateTimeStyles.RoundtripKind, dateValue) Then
            Console.WriteLine("'{0}' --> {1:f}", 
                              inputValue, dateValue.ToLocalTime())
         Else
            Console.WriteLine("Cannot parse '{0}'", inputValue)   
         End If
      Next
      Console.WriteLine("Restored dates...")   
   End Sub
End Module
' When saved on an en-US system, the example displays the following output:
'       Current Time Zone: (UTC-08:00) Pacific Time (US & Canada)
'       The dates on an en-US system:
'       Saturday, June 14, 2014 6:32 AM
'       Thursday, July 10, 2014 11:49 PM
'       Saturday, January 10, 2015 1:16 AM
'       Saturday, December 20, 2014 9:45 PM
'       Monday, June 02, 2014 3:14 PM
'       Saved dates...
'
' When restored on an en-GB system, the example displays the following output:
'       Current Time Zone: (UTC) Dublin, Edinburgh, Lisbon, London
'       The dates on an en-GB system:
'       '2014-06-14T13:32:00.0000000Z' --> 14 June 2014 14:32
'       '2014-07-11T06:49:00.0000000Z' --> 11 July 2014 07:49
'       '2015-01-10T09:16:00.0000000Z' --> 10 January 2015 09:16
'       '2014-12-21T05:45:00.0000000Z' --> 21 December 2014 05:45
'       '2014-06-02T22:14:00.0000000Z' --> 02 June 2014 23:14
'       Restored dates...
' </Snippet2>

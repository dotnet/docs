' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.IO
Imports System.Globalization
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Threading

Module Example
   Private Const filename As String = ".\Dates.bin"

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
      Dim fs As New FileStream(filename, FileMode.Create)
      Dim bin As New BinaryFormatter()
      
      Console.WriteLine("Current Time Zone: {0}",
                        TimeZoneInfo.Local.DisplayName)
      Console.WriteLine("The dates on an {0} system:", 
                        Thread.CurrentThread.CurrentCulture.Name)
      For ctr As Integer = 0 To dates.Length - 1 
         Console.WriteLine(dates(ctr).ToString("f"))
         dates(ctr) = dates(ctr).ToUniversalTime()
      Next
      bin.Serialize(fs, dates)
      fs.Close()
      Console.WriteLine("Saved dates...")
   End Sub

   Private Sub RestoreDates()
      TimeZoneInfo.ClearCachedData()
      Console.WriteLine("Current Time Zone: {0}",
                        TimeZoneInfo.Local.DisplayName)
      Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB")

      Dim fs As New FileStream(filename, FileMode.Open)
      Dim bin As New BinaryFormatter()
      Dim dates() As DateTime = DirectCast(bin.Deserialize(fs), Date())
      fs.Close()
      
      Console.WriteLine("The dates on an {0} system:", 
                        Thread.CurrentThread.CurrentCulture.Name)
      For Each value In dates
         Console.WriteLine(value.ToLocalTime().ToString("f"))
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
'       14 June 2014 14:32
'       11 July 2014 07:49
'       10 January 2015 09:16
'       21 December 2014 05:45
'       02 June 2014 23:14
'       Restored dates...
' </Snippet3>

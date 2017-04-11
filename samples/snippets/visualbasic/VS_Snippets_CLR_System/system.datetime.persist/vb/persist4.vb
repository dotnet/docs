' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Imports System.Globalization
Imports System.IO
Imports System.Threading

Module Example
   Private Const filename As String = ".\IntDates.bin"

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
 
      Console.WriteLine("Current Time Zone: {0}",
                        TimeZoneInfo.Local.DisplayName)
      Console.WriteLine("The dates on an {0} system:", 
                        Thread.CurrentThread.CurrentCulture.Name)
      Dim ticks(dates.Length - 1) As Long
      For ctr As Integer = 0 To dates.Length - 1 
         Console.WriteLine(dates(ctr).ToString("f"))
         ticks(ctr) = dates(ctr).ToUniversalTime().Ticks 
      Next
      Dim fs As New FileStream(filename, FileMode.Create)
      Dim bw As New BinaryWriter(fs)
      bw.Write(ticks.Length)
      For Each tick In ticks
         bw.Write(tick)
      Next
      bw.Close()
      Console.WriteLine("Saved dates...")
   End Sub

   Private Sub RestoreDates()
      TimeZoneInfo.ClearCachedData()
      Console.WriteLine("Current Time Zone: {0}",
                        TimeZoneInfo.Local.DisplayName)
      Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB")
      Dim fs As New FileStream(filename, FileMode.Open)
      Dim br As New BinaryReader(fs)
      Dim items As Integer
      Dim dates() As DateTime
      
      Try
         items = br.ReadInt32()
         ReDim dates(items - 1)

         For ctr As Integer = 0 To items - 1
            Dim ticks As Long = br.ReadInt64()
            dates(ctr) = New DateTime(Ticks).ToLocalTime()
         Next      
      Catch e As EndOfStreamException
         Console.WriteLine("File corruption detected. Unable to restore data...")
         Exit Sub
      Catch e As IOException
         Console.WriteLine("Unspecified I/O error. Unable to restore data...")
         Exit Sub
      Catch e As OutOfMemoryException     'Thrown in array initialization.
         Console.WriteLine("File corruption detected. Unable to restore data...")
         Exit Sub
      Finally
         br.Close()   
      End Try   
      
      Console.WriteLine("The dates on an {0} system:", 
                        Thread.CurrentThread.CurrentCulture.Name)
      For Each value In dates
         Console.WriteLine(value.ToString("f"))
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
' </Snippet4>

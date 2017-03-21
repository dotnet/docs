Imports DateTimeExtensions
Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary

Module Example
   Public Sub Main()
      Dim dates() As DateWithTimeZone = { New DateWithTimeZone(#8/9/2014 7:30PM#, 
                                              TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time")),
                                          New DateWithTimeZone(#8/15/2014 7:00PM#, 
                                              TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time")),  
                                          New DateWithTimeZone(#8/22/2014 7:30PM#, 
                                              TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time")),  
                                          New DateWithTimeZone(#8/28/2014 7:00PM#, 
                                              TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time")) }
      Dim fs As New FileStream(".\Schedule.bin", FileMode.Create)
      Dim formatter As New BinaryFormatter()
      Try
         formatter.Serialize(fs, dates)
      Catch e As SerializationException
         Console.WriteLine("Serialization failed. Reason: {0}", e.Message)
      Finally
         If fs IsNot Nothing Then fs.Close()
      End Try      
      ' Display dates.
      For Each dateInfo In dates
         Dim tz As TimeZoneInfo = dateInfo.TimeZone
         Console.WriteLine("{0} {1}", dateInfo.DateTime, 
                           If(tz.IsDaylightSavingTime(dateInfo.DateTime), 
                           tz.DaylightName, tz.StandardName))      
      Next
   End Sub
End Module
' The example displays the following output:
'       8/9/2014 7:30:00 PM Eastern Daylight Time
'       8/15/2014 7:00:00 PM Pacific Daylight Time
'       8/22/2014 7:30:00 PM Eastern Daylight Time
'       8/28/2014 7:00:00 PM Eastern Daylight Time
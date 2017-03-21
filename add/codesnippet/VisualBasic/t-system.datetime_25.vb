Imports DateTimeExtensions
Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary

Module Example
   Private Const filename As String = ".\Schedule.bin"

   Public Sub Main()
      Dim fs As FileStream
      If File.Exists(filename) Then
         fs = New FileStream(filename, FileMode.Open)
      Else
         Console.WriteLine("Unable to find file to deserialize.")
         Exit Sub
      End If
      
      Dim formatter As New BinaryFormatter()
      Dim dates() As DateWithTimeZone = Nothing
      Try
         dates = DirectCast(formatter.Deserialize(fs), DateWithTimeZone()) 
         ' Display dates.
         For Each dateInfo In dates
            Dim tz As TimeZoneInfo = dateInfo.TimeZone
            Console.WriteLine("{0} {1}", dateInfo.DateTime, 
                              If(tz.IsDaylightSavingTime(dateInfo.DateTime), 
                              tz.DaylightName, tz.StandardName))      
         Next
      Catch e As SerializationException
         Console.WriteLine("Deserialization failed. Reason: {0}", e.Message)
      Finally
         If fs IsNot Nothing Then fs.Close()
      End Try      
   End Sub
End Module
' The example displays the following output:
'       8/9/2014 7:30:00 PM Eastern Daylight Time
'       8/15/2014 7:00:00 PM Pacific Daylight Time
'       8/22/2014 7:30:00 PM Eastern Daylight Time
'       8/28/2014 7:00:00 PM Eastern Daylight Time
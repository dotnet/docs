' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module TimeZoneSerialization
   Dim serializedEst As String
   
   Public Sub Main()
      ' Retrieve Eastern Standard Time zone from registry
      Try
         Dim est As TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time")
         ' Create custom Eastern Time Zone for historical (pre-1918) conversions
         CreateTimeZone()
         ' Call conversion function with one current and one pre-1918 date and time
         Console.WriteLine(ConvertUtcTime(Date.UtcNow, est))
         Console.WriteLine(ConvertUtcTime(New Date(1900, 11, 15, 9, 32, 00, DateTimeKind.Utc), est))
      Catch e As TimeZoneNotFoundException
         Console.WriteLine("The Eastern Standard Time zone is not in the registry.")
      Catch e As InvalidTimeZoneException
         Console.WriteLine("Data on the Eastern Standard Time Zone in the registry is corrupted.")
      End Try   
   End Sub
   
   Private Sub CreateTimeZone()
      ' Create a simple Eastern Standard time zone 
      ' without adjustment rules for 1883-1918
      Dim earlyEstZone As TimeZoneInfo = TimeZoneInfo.CreateCustomTimeZone("Eastern Standard Time", _
                                      New TimeSpan(-5, 0, 0), _
                                      " (GMT-05:00) Eastern Time (United States)", _ 
                                      "Eastern Standard Time")
      serializedEst = earlyEstZone.ToSerializedString()                                
   End Sub
   
   Private Function ConvertUtcTime(utcDate As Date, tz As TimeZoneInfo) As Date
      ' Use time zone object from registry 
      If Year(utcDate) > 1917 Then
         Return TimeZoneInfo.ConvertTimeFromUtc(utcDate, tz)
      ' Handle dates before introduction of DST
      Else
         ' Restore serialized time zone object
         tz = TimeZoneInfo.FromSerializedString(serializedEst)
         Return TimeZoneInfo.ConvertTimeFromUtc(utcDate, tz)
      End If      
   End Function
End Module
' </Snippet1>

Public Class TZExamples
   
End Class


' Visual Basic .NET Document
Option Strict On

' <Snippet4>
<Serializable> Public Structure DateTimeTZI
  Dim [Date] As DateTime
  Dim TimeZone As TimeZoneInfo
   
  Public Sub New([date] As DateTime, tz As TimeZoneInfo)
     Me.[Date] = [date]
     Me.TimeZone = tz
  End Sub
  
  Public Overrides Function ToString() As String
     Return String.Format("{0:dd/MM/yyyy hh:mm:ss tt} {1}", 
                          [Date], TimeZone.StandardName)
  End Function
End Structure
' </Snippet4>

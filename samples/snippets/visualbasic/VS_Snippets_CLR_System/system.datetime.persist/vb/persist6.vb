' Visual Basic .NET Document
Option Strict On

' <Snippet6>
Namespace DateTimeExtensions
   <Serializable> Public Structure DateWithTimeZone
      Private tz As TimeZoneInfo
      Private dt As DateTime
      
      Public Sub New(dateValue As DateTime, timeZone As TimeZoneInfo)
         dt = dateValue
         If timeZone Is Nothing Then
            tz = TimeZoneInfo.Local
         Else
            tz = timeZone
         End If   
      End Sub   
      
      Public Property TimeZone As TimeZoneInfo
         Get
            Return tz
         End Get
         Set
            tz = value
         End Set
      End Property
      
      Public Property DateTime As Date
         Get
            Return dt
         End Get
         Set
            dt = value
         End Set
      End Property
   End Structure
End Namespace
' </Snippet6>

Module Example
   Public Sub Main()

   End Sub
End Module


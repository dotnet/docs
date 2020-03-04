' <Snippet6>
Namespace DateTimeExtensions
    <Serializable> Public Structure DateWithTimeZone
        Private tz As TimeZoneInfo
        Private dt As DateTime

        Public Sub New(dateValue As DateTime, timeZone As TimeZoneInfo)
            dt = dateValue
            tz = If(timeZone, TimeZoneInfo.Local)
        End Sub

        Public Property TimeZone As TimeZoneInfo
            Get
                Return tz
            End Get
            Set
                tz = Value
            End Set
        End Property

        Public Property DateTime As Date
            Get
                Return dt
            End Get
            Set
                dt = Value
            End Set
        End Property
    End Structure
End Namespace
' </Snippet6>


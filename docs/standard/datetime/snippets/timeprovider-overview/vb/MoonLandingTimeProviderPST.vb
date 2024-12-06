'<CustomProvider>
Public Class MoonLandingTimeProviderPST
    Inherits TimeProvider

    'July 20, 1969, at 20:17:40 UTC
    Private ReadOnly _specificDateTime As New DateTimeOffset(1969, 7, 20, 20, 17, 40, TimeZoneInfo.Utc.BaseUtcOffset)

    Public Overrides Function GetUtcNow() As DateTimeOffset
        Return _specificDateTime
    End Function

    Public Overrides ReadOnly Property LocalTimeZone As TimeZoneInfo
        Get
            Return TimeZoneInfo.FindSystemTimeZoneById("PST")
        End Get
    End Property

End Class
'</CustomProvider>

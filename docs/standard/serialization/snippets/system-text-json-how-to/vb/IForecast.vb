Namespace SystemTextJsonSamples

    Public Interface IForecast
        Property [Date] As DateTimeOffset
        Property TemperatureCelsius As Integer
        Property Summary As String
    End Interface

    Public Class Forecast
        Implements IForecast
        Public Property [Date] As DateTimeOffset Implements IForecast.[Date]
        Public Property TemperatureCelsius As Integer Implements IForecast.TemperatureCelsius
        Public Property Summary As String Implements IForecast.Summary
        Public Property WindSpeed As Integer
    End Class

    Public Class Forecasts
        Public Property Monday As IForecast
        Public Property Tuesday As Object
    End Class

End Namespace

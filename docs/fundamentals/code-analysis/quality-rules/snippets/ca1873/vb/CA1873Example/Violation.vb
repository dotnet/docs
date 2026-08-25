Imports Microsoft.Extensions.Logging

' <ViolationExample>
Class ViolationExample
    Private ReadOnly _logger As ILogger

    Public Sub New(logger As ILogger(Of ViolationExample))
        _logger = logger
    End Sub

    Public Sub ProcessData(data As Integer())
        ' Violation: expensive operation in logging argument.
        _logger.LogDebug($"Processing {String.Join(", ", data)} items")

        ' Violation: object creation in logging argument.
        _logger.LogTrace("Data: {Data}", New With {.Count = data.Length, .Items = data})
    End Sub
End Class
' </ViolationExample>

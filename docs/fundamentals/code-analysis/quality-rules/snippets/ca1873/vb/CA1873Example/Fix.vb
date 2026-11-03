Imports Microsoft.Extensions.Logging

' <FixExample>
Partial Class FixExample
    Private ReadOnly _logger As ILogger

    Public Sub New(logger As ILogger(Of FixExample))
        _logger = logger
    End Sub

    Public Sub ProcessData(data As Integer())
        ' Fixed: use source-generated logging.
        ' The data array is passed directly; no expensive operation executed unless log level is enabled.
        LogProcessingData(data)

        ' Fixed: use source-generated logging.
        LogTraceData(data.Length, data)
    End Sub

    <LoggerMessage(Level:=LogLevel.Debug, Message:="Processing {Data} items")>
    Private Partial Sub LogProcessingData(data As Integer())
    End Sub

    <LoggerMessage(Level:=LogLevel.Trace, Message:="Data: Count={Count}, Items={Items}")>
    Private Partial Sub LogTraceData(count As Integer, items As Integer())
    End Sub
End Class
' </FixExample>

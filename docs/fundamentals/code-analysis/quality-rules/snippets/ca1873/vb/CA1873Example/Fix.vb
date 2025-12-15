Imports Microsoft.Extensions.Logging

' <FixExample>
Partial Class FixExample
    Private ReadOnly _logger As ILogger

    Public Sub New(logger As ILogger(Of FixExample))
        _logger = logger
    End Sub

    Public Sub ProcessData(data As Integer())
        ' Fixed: use source-generated logging.
        LogProcessingData(String.Join(", ", data))

        ' Fixed: use source-generated logging.
        LogTraceData(data.Length, data)
    End Sub

    <LoggerMessage(Level:=LogLevel.Debug, Message:="Processing {Items} items")>
    Private Partial Sub LogProcessingData(items As String)
    End Sub

    <LoggerMessage(Level:=LogLevel.Trace, Message:="Data: Count={Count}, Items={Items}")>
    Private Partial Sub LogTraceData(count As Integer, items As Integer())
    End Sub
End Class
' </FixExample>

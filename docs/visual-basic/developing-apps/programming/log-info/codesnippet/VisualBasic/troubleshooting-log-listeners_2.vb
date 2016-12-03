    Function GetListeners(ByVal listeners As TraceListenerCollection) As String
        Dim ret As String = ""
        For Each listener As TraceListener In listeners
            ret &= listener.Name
            Dim listenerType As Type = listener.GetType
            If listenerType Is GetType(DefaultTraceListener) Then
                Dim tmp As DefaultTraceListener = 
                    DirectCast(listener, DefaultTraceListener)
                ret &= ": Writes to the debug output."
            ElseIf listenerType Is GetType(Logging.FileLogTraceListener) Then
                Dim tmp As Logging.FileLogTraceListener = 
                    DirectCast(listener, Logging.FileLogTraceListener)
                ret &= ": Log filename: " & tmp.FullLogFileName
            ElseIf listenerType Is GetType(EventLogTraceListener) Then
                Dim tmp As EventLogTraceListener = 
                    DirectCast(listener, EventLogTraceListener)
                ret &= ": Event log name: " & tmp.EventLog.Log
            ElseIf listenerType Is GetType(XmlWriterTraceListener) Then
                Dim tmp As Diagnostics.XmlWriterTraceListener = 
                    DirectCast(listener, XmlWriterTraceListener)
                ret &= ": XML log"
            ElseIf listenerType Is GetType(ConsoleTraceListener) Then
                Dim tmp As ConsoleTraceListener = 
                    DirectCast(listener, ConsoleTraceListener)
                ret &= ": Console log"
            ElseIf listenerType Is GetType(DelimitedListTraceListener) Then
                Dim tmp As DelimitedListTraceListener = 
                    DirectCast(listener, DelimitedListTraceListener)
                ret &= ": Delimited log"
            Else
                ret &= ": Unhandeled log type: " & 
                    listenerType.ToString
            End If
            ret &= vbCrLf
        Next

        Return ret
    End Function
            Dim frame As New StackFrame(1, True)
            Dim strace As New StackTrace(frame)            

            EventLog.WriteEntry(frame.GetMethod().Name, _
                                strace.ToString(), _
                                EventLogEntryType.Warning)
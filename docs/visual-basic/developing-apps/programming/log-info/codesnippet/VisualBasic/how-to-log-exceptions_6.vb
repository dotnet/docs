            My.Application.Log.WriteException(e.Exception,
                TraceEventType.Critical,
                "Application shut down at " &
                My.Computer.Clock.GmtTime.ToString)
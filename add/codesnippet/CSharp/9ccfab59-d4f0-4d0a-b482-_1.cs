    public class ErrorFilter : TraceFilter
    {
        override public bool ShouldTrace(TraceEventCache cache, string source,
            TraceEventType eventType, int id, string formatOrMessage,
            object[] args, object data, object[] dataArray)
        {
            return eventType == TraceEventType.Error;
        }
    }
using System;

namespace ca1008
{
    public enum TraceLevel
    {
        Off = 0,
        Error = 1,
        Warning = 2,
        Info = 3,
        Verbose = 4
    }

    [Flags]
    public enum TraceOptions
    {
        None = 0,
        CallStack = 0x01,
        LogicalStack = 0x02,
        DateTime = 0x04,
        Timestamp = 0x08,
    }

    [Flags]
    public enum BadTraceOptions
    {
        CallStack = 0,
        LogicalStack = 0x01,
        DateTime = 0x02,
        Timestamp = 0x04,
    }

    class UseBadTraceOptions
    {
        static void MainTrace()
        {
            // Set the flags.
            BadTraceOptions badOptions =
               BadTraceOptions.LogicalStack | BadTraceOptions.Timestamp;

            // Check whether CallStack is set.
            if ((badOptions & BadTraceOptions.CallStack) ==
                BadTraceOptions.CallStack)
            {
                // This 'if' statement is always true.
            }
        }
    }
}

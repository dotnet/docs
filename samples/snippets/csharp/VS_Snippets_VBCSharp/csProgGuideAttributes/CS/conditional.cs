//<Snippet31>
#define TRACE_ON
using System;
using System.Diagnostics;

public class Trace
{
    [Conditional("TRACE_ON")]
    public static void Msg(string msg)
    {
        Console.WriteLine(msg);
    }
}

public class ProgramClass
{
    static void Main()
    {
        Trace.Msg("Now in Main...");
        Console.WriteLine("Done.");
    }
}
//</Snippet31>

class TestDebug
{
    //<Snippet32>
    [Conditional("DEBUG")]
    static void DebugMethod()
    {
    }
    //</Snippet32>
//<Snippet33>
#if DEBUG
    void ConditionalMethod()
    {
    }
#endif
//</Snippet33>
}

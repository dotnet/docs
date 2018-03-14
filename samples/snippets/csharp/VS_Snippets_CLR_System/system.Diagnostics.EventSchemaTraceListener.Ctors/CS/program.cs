using System;
using System.Diagnostics;
namespace ctors
{
    class Program
    {
        static void Main(string[] args)
        {
            //<snippet1>
            TraceSource ts = new TraceSource("TestSource");
            ts.Listeners.Add(new EventSchemaTraceListener("TraceOutput.xml"));
            //</snippet1>
        }
        static void Main2(string[] args)
        {
            //<snippet2>
            TraceSource ts = new TraceSource("TestSource");
            ts.Listeners.Add(new EventSchemaTraceListener("TraceOutput.xml", "eventListener"));
            //</snippet2>
        }
        static void Main3(string[] args)
        {
            //<snippet3>
            TraceSource ts = new TraceSource("TestSource");
            ts.Listeners.Add(new EventSchemaTraceListener("TraceOutput.xml", "eventListener", 65536));
            //</snippet3>
        }
        static void Main4(string[] args)
        {
            //<snippet4>
            TraceSource ts = new TraceSource("TestSource");
            ts.Listeners.Add(new EventSchemaTraceListener("TraceOutput.xml", "eventListener", 65536, TraceLogRetentionOption.LimitedCircularFiles));
            //</snippet4>
        }
        static void Main5(string[] args)
        {
            //<snippet5>
            TraceSource ts = new TraceSource("TestSource");
            ts.Listeners.Add(new EventSchemaTraceListener("TraceOutput.xml", "eventListener", 65536, TraceLogRetentionOption.LimitedCircularFiles, 20480000));
            //</snippet5>
        }
      }
}

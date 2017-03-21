#define NOCONFIGFILE
using System;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using System.Diagnostics;

class testClass
{
    [STAThreadAttribute]
    static void Main()
    {
        File.Delete("TraceOutput.xml");
        TraceSource ts = new TraceSource("TestSource");
#if NOCONFIGFILE
        //ts.Listeners.Add(new EventSchemaTraceListener("TraceOutput.xml", "eventListener", 65536, TraceLogRetentionOption.LimitedCircularFiles, 20480000, 2));
        ts.Listeners.Add(new EventSchemaTraceListener("TraceOutput.xml", "eventListener"));
        ts.Listeners["eventListener"].TraceOutputOptions = TraceOptions.DateTime | TraceOptions.ProcessId | TraceOptions.Timestamp;
#endif
        ts.Switch.Level = SourceLevels.All;
        string testString = "<Test><InnerElement Val=\"1\" /><InnerElement Val=\"Data\"/><AnotherElement>11</AnotherElement></Test>";
        UnescapedXmlDiagnosticData unXData = new UnescapedXmlDiagnosticData(testString);
        ts.TraceData(TraceEventType.Error, 38, unXData);
        ts.TraceEvent(TraceEventType.Error, 38, testString);
        Trace.Listeners.Add(new EventSchemaTraceListener("TraceOutput.xml"));
        Trace.Write("test", "test");
        Trace.Flush();
        ts.Flush();
        ts.Close();
        DisplayProperties(ts);
        Process.Start("notepad.exe", "TraceOutput.xml");
        Console.WriteLine("Press the enter key to exit");
        Console.ReadLine();
    }
    private static void DisplayProperties(TraceSource ts)
    {
        Console.WriteLine("IsThreadSafe? " + ((EventSchemaTraceListener)ts.Listeners["eventListener"]).IsThreadSafe);
        Console.WriteLine("BufferSize =  " + ((EventSchemaTraceListener)ts.Listeners["eventListener"]).BufferSize);
        Console.WriteLine("MaximumFileSize =  " + ((EventSchemaTraceListener)ts.Listeners["eventListener"]).MaximumFileSize);
        Console.WriteLine("MaximumNumberOfFiles =  " + ((EventSchemaTraceListener)ts.Listeners["eventListener"]).MaximumNumberOfFiles);
        Console.WriteLine("Name =  " + ((EventSchemaTraceListener)ts.Listeners["eventListener"]).Name);
        Console.WriteLine("TraceLogRetentionOption =  " + ((EventSchemaTraceListener)ts.Listeners["eventListener"]).TraceLogRetentionOption);
        Console.WriteLine("TraceOutputOptions =  " + ((EventSchemaTraceListener)ts.Listeners["eventListener"]).TraceOutputOptions);
    }
}
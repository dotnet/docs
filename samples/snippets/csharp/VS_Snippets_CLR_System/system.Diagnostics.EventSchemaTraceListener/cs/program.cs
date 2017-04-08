//<Snippet1>
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
        //<Snippet2>
        //ts.Listeners.Add(new EventSchemaTraceListener("TraceOutput.xml", "eventListener", 65536, TraceLogRetentionOption.LimitedCircularFiles, 20480000, 2));
        ts.Listeners.Add(new EventSchemaTraceListener("TraceOutput.xml", "eventListener"));
        //</Snippet2>
        //<Snippet3>
        ts.Listeners["eventListener"].TraceOutputOptions = TraceOptions.DateTime | TraceOptions.ProcessId | TraceOptions.Timestamp;
        //</Snippet3>
#endif
        ts.Switch.Level = SourceLevels.All;
        //<Snippet11>
        string testString = "<Test><InnerElement Val=\"1\" /><InnerElement Val=\"Data\"/><AnotherElement>11</AnotherElement></Test>";
        UnescapedXmlDiagnosticData unXData = new UnescapedXmlDiagnosticData(testString);
        ts.TraceData(TraceEventType.Error, 38, unXData);
        //</Snippet11>
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
    //<Snippet12>
    private static void DisplayProperties(TraceSource ts)
    {
        //<Snippet4>
        Console.WriteLine("IsThreadSafe? " + ((EventSchemaTraceListener)ts.Listeners["eventListener"]).IsThreadSafe);
        //</Snippet4>
        //<Snippet5>
        Console.WriteLine("BufferSize =  " + ((EventSchemaTraceListener)ts.Listeners["eventListener"]).BufferSize);
        //</Snippet5>
        //<Snippet6>
        Console.WriteLine("MaximumFileSize =  " + ((EventSchemaTraceListener)ts.Listeners["eventListener"]).MaximumFileSize);
        //</Snippet6>
        //<Snippet7>
        Console.WriteLine("MaximumNumberOfFiles =  " + ((EventSchemaTraceListener)ts.Listeners["eventListener"]).MaximumNumberOfFiles);
        //</Snippet7>
        //<Snippet8>
        Console.WriteLine("Name =  " + ((EventSchemaTraceListener)ts.Listeners["eventListener"]).Name);
        //</Snippet8>
        //<Snippet9>
        Console.WriteLine("TraceLogRetentionOption =  " + ((EventSchemaTraceListener)ts.Listeners["eventListener"]).TraceLogRetentionOption);
        //</Snippet9>
        //<Snippet10>
        Console.WriteLine("TraceOutputOptions =  " + ((EventSchemaTraceListener)ts.Listeners["eventListener"]).TraceOutputOptions);
        //</Snippet10>
    }
    //</Snippet12>
}
//</Snippet1>

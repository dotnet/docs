//<Snippet1>
#define TRACE
#define ConfigFile
// The following configuration file can be used with this sample.
// When using a configuration file #define ConfigFile.
//<?xml version="1.0" encoding="utf-8"?>
//<configuration>
//  <system.diagnostics>
//    <sources>
//      <source name="TraceTest" switchName="TestSourceSwitch" switchType="Testing.MySourceSwitch, TraceSample" SecondTraceSourceAttribute="two">
//        <listeners>
//          <add name="console" />
//          <add name="file" />
//          <add name="fileBuilder" />
//        </listeners>
//      </source>
//    </sources>
//    <switches>
//      <add name="TestSourceSwitch" value="Error" customsourceSwitchattribute="5" />
//      <add name="TraceTest" value="Verbose" />
//      <add name="TraceSwitch" value="Warning" />
//      <add name="BoolSwitch" value="True" />
//    </switches>
//    <sharedListeners>
//      <add name="console" type="System.Diagnostics.ConsoleTraceListener, System, Version=1.2.3300.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" initializeData="false" />
//      <add name="file" type="System.Diagnostics.TextWriterTraceListener, System, Version=1.2.3300.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" initializeData="TextWriterOutput.log" traceOutputOptions="ProcessId, LogicalOperationStack, Timestamp, ThreadId, Callstack, DateTime" />
//      <add name="fileBuilder" type="System.Diagnostics.DelimitedListTraceListener, System, Version=1.2.3300.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" initializeData="DelimitedListOutput.log" traceOutputOptions="ProcessId, LogicalOperationStack, Timestamp, ThreadId, DateTime" />
//    </sharedListeners>
//    <trace autoflush="true" indentsize="4">
//      <listeners>
//        <add name="console" />
//        <add name="file" />
//        <add name="fileBuilder" />
//        <add name="testlistener" type="Testing.TestListener, TraceSample, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null" initializeData="5" />
//      </listeners>
//    </trace>
//  </system.diagnostics>
//</configuration>

using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.IO;
using System.Security.Permissions;

namespace Testing
{
    class TraceTest
    {
        const string TEXTFILE = "TextWriterOutput.log";
        const string DELIMITEDFILE = "DelimitedListOutput.log";
        const string TESTLISTENERFILE = "C:\\Temp\\TestListener.txt";
        //<Snippet2>
        public static TraceSwitch traceSwitch = new TraceSwitch("TraceSwitch", "Verbose");
        public static BooleanSwitch boolSwitch = new BooleanSwitch("BoolSwitch", "True");
        public static SourceSwitch sourceSwitch = new SourceSwitch("SourceSwitch", "Verbose");
        //</Snippet2>
        static void Main()
        {

            try
            {
                // Initialize trace switches.
                //<Snippet3>
#if(!ConfigFile)
                TraceSwitch traceSwitch = new TraceSwitch("TraceSwitch", "Verbose");
#endif
                //</Snippet3>
                //<Snippet4>
                Console.WriteLine(traceSwitch.Level);
                //</Snippet4>
                //<Snippet5>
#if(!ConfigFile)
                BooleanSwitch boolSwitch = new BooleanSwitch("BoolSwitch", "True");
#endif
                //</Snippet5>
                //<Snippet6>
                Console.WriteLine(boolSwitch.Enabled);
                //</Snippet6>
                //<Snippet7>
#if(!ConfigFile)
                SourceSwitch sourceSwitch = new SourceSwitch("SourceSwitch", "Verbose");
#endif
                //</Snippet7>
                //<Snippet8>
                Console.WriteLine(sourceSwitch.Level);
                //</Snippet8>
                // Initialize trace source.
                //<Snippet9>
                MyTraceSource ts = new MyTraceSource("TraceTest");
                //</Snippet9>
                //<Snippet10>
                Console.WriteLine(ts.Switch.DisplayName);
                //</Snippet10>
                //<Snippet11>
                Console.WriteLine(ts.Switch.Level);
                //</Snippet11>
                //<Snippet12>
                SwitchAttribute[] switches = SwitchAttribute.GetAll(typeof(TraceTest).Assembly);
                for (int i = 0; i < switches.Length; i++)
                {
                    Console.Write(switches[i].SwitchName);
                    Console.Write("\t");
                    Console.WriteLine(switches[i].SwitchType);
                }
                //</Snippet12>
                //<Snippet13>
                // Display the SwitchLevelAttribute for the BooleanSwitch.
                Object[] attribs = typeof(BooleanSwitch).GetCustomAttributes(typeof(SwitchLevelAttribute), false);
                if (attribs.Length == 0)
                    Console.WriteLine("Error, couldn't find SwitchLevelAttribute on BooleanSwitch.");
                else
                    Console.WriteLine(((SwitchLevelAttribute)attribs[0]).SwitchLevelType.ToString());
                //</Snippet13>
#if(ConfigFile)
                //<Snippet14>
                // Get the custom attributes for the TraceSource.
                Console.WriteLine(ts.Attributes.Count);
                foreach (DictionaryEntry de in ts.Attributes)
                    Console.WriteLine(de.Key + "  " + de.Value);
                //</Snippet14>
                //<Snippet15>
                // Get the custom attributes for the trace source switch.
                foreach (DictionaryEntry de in ts.Switch.Attributes)
                    Console.WriteLine(de.Key + "  " + de.Value);
                //</Snippet15>
#endif
                //<Snippet16>
                ts.Listeners["console"].TraceOutputOptions |= TraceOptions.Callstack;
                //</Snippet16>
                //<Snippet17>
                ts.TraceEvent(TraceEventType.Warning, 1);
                //</Snippet17>
                ts.Listeners["console"].TraceOutputOptions = TraceOptions.DateTime;
                //<Snippet18>
                // Issue file not found message as a warning.
                ts.TraceEvent(TraceEventType.Warning, 1, "File Test not found");
                //</Snippet18>
                System.Threading.Thread.Sleep(1000);
                //<Snippet19>
                Console.WriteLine(ts.Listeners.Count);
                //</Snippet19>
                //<Snippet20>
                ts.Listeners.Add(new TestListener(TESTLISTENERFILE, "TestListener"));
                //</Snippet20>
                Console.WriteLine(ts.Listeners.Count);
                //<Snippet22>
                foreach (TraceListener traceListener in ts.Listeners)
                {
                    Console.Write(traceListener.Name + "\t");
                    // The following output can be used to update the configuration file.
                    Console.WriteLine((traceListener.GetType().AssemblyQualifiedName));
                }
                //</Snippet22>
                //<Snippet23>
                // Show correlation and output options.
                Trace.CorrelationManager.StartLogicalOperation("abc");
                //</Snippet23>
                //<Snippet24>
                // Issue file not found message as a verbose event using a formatted string.
                ts.TraceEvent(TraceEventType.Verbose, 2, "File {0} not found.", "test");
                //</Snippet24>
                Trace.CorrelationManager.StartLogicalOperation("def");
                // Issue file not found message as information.
                ts.TraceEvent(TraceEventType.Information, 3, "File {0} not found.", "test");
                //<Snippet25>
                Trace.CorrelationManager.StopLogicalOperation();
                //</Snippet25>
                //<Snippet26>
                ts.Listeners["console"].TraceOutputOptions |= TraceOptions.LogicalOperationStack;
                //</Snippet26>
                // Issue file not found message as an error event.
                ts.TraceEvent(TraceEventType.Error, 4, "File {0} not found.", "test");
                Trace.CorrelationManager.StopLogicalOperation();
                // Write simple message from trace.
                //<Snippet27>
                Trace.TraceWarning("Warning from Trace.");
                //</Snippet27>
                //<Snippet28>
                // Test the filter on the ConsoleTraceListener.
                ts.Listeners["console"].Filter = new SourceFilter("No match");
                ts.TraceData(TraceEventType.Information, 5, 
                    "SourceFilter should reject this message for the console trace listener.");
                ts.Listeners["console"].Filter = new SourceFilter("TraceTest");
                ts.TraceData(TraceEventType.Information, 6, 
                    "SourceFilter should let this message through on the console trace listener.");
                //</Snippet28>
                ts.Listeners["console"].Filter = null;
                // Use the TraceData method. 
                //<Snippet30>
                ts.TraceData(TraceEventType.Warning, 9, new object());
                //</Snippet30>
                //<Snippet31>
                ts.TraceData(TraceEventType.Warning, 10, new object[] { "Message 1", "Message 2" });
                //</Snippet31>
                // Activity tests.
                //<Snippet32>
                ts.TraceEvent(TraceEventType.Start, 11, "Will not appear until the switch is changed.");
                ts.Switch.Level = SourceLevels.ActivityTracing | SourceLevels.Critical;
                ts.TraceEvent(TraceEventType.Suspend, 12, "Switch includes ActivityTracing, this should appear");
                ts.TraceEvent(TraceEventType.Critical, 13, "Switch includes Critical, this should appear");
                //</Snippet32>

                Trace.Flush();
                ((TextWriterTraceListener)Trace.Listeners["file"]).Close();
                ((TextWriterTraceListener)Trace.Listeners["fileBuilder"]).Close();

                System.Threading.Thread.Sleep(1000);


                // Examine the contents of the log file.
                Console.WriteLine("\n\n\n");
                // Use try/catch in case the file hasn't been defined.
                try
                {
                    Console.WriteLine("Examining " + TEXTFILE);
                    StreamReader logfile = new StreamReader(TEXTFILE);
                    while (!logfile.EndOfStream)
                        Console.WriteLine(logfile.ReadLine());

                    logfile.Close();

                    File.Delete(TEXTFILE);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error tying to read the text log file. " + e.Message);
                }

                // Display the contents of the log file builder.
                Console.WriteLine("\n\n\n");
                // Use try/catch in case the file hasn't been defined.
                try
                {
                    Console.WriteLine("Examining " + DELIMITEDFILE);
                    StreamReader logfile = new StreamReader(DELIMITEDFILE);
                    while (!logfile.EndOfStream)
                        Console.WriteLine(logfile.ReadLine());
                    logfile.Close();
                    File.Delete(DELIMITEDFILE);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error tying to read the delimited text file. " + e.Message);
                }

                Console.WriteLine("Press any key to exit.");
                Console.Read();
            }
            catch (Exception e)
            {
                // Catch any unexpected exception.
                Console.WriteLine("Unexpected exception: " + e.ToString());
                Console.Read();
            }
        }
    }

    //<Snippet33>
    public class MyTraceSource : TraceSource
    {
        string firstAttribute = "";
        string secondAttribute = "";
        public MyTraceSource(string n) : base(n) {}

        public string FirstTraceSourceAttribute
        {
            get {
                foreach (DictionaryEntry de in this.Attributes)
                    if (de.Key.ToString().ToLower() == "firsttracesourceattribute")
                        firstAttribute = de.Value.ToString() ; 
                return firstAttribute;
            }
            set { firstAttribute = value; }
        }

        public string SecondTraceSourceAttribute
        {
            get {
                foreach (DictionaryEntry de in this.Attributes)
                    if (de.Key.ToString().ToLower() == "secondtracesourceattribute")
                        secondAttribute = de.Value.ToString();
                return secondAttribute; }
            set { secondAttribute = value; }
        }

        protected override string[] GetSupportedAttributes()
        {
            // Allow the use of the attributes in the configuration file.
            return new string[] { "FirstTraceSourceAttribute", "SecondTraceSourceAttribute" };
        }
    }
    //</Snippet33>

    //<Snippet34>
    public class MySourceSwitch : SourceSwitch
    {
        int sourceAttribute = 0;
        public MySourceSwitch(string n) : base(n) { }
        public int CustomSourceSwitchAttribute
        {
            get
            {
                foreach (DictionaryEntry de in this.Attributes)
                    if (de.Key.ToString().ToLower() == "customsourceswitchattribute")
                        sourceAttribute = (int)de.Value;
                return sourceAttribute;
            }
            set { sourceAttribute = (int)value; }
        }

        protected override string[] GetSupportedAttributes()
        {
            return new string[] { "customsourceSwitchattribute" };
        }
    }
    //</snippet34>

    // Very basic test listener derived from TextWriterTraceListener.
    //<Snippet35>
    [HostProtection(Synchronization = true)]
    public class TestListener : TextWriterTraceListener
    {
        public TestListener(string fileName) : base(fileName) { }
        public TestListener(string fileName, string name) : base(fileName, name) {}

        public override void Write(string s)
        {
            base.Write("TestListener " + s);
        }
        public override void WriteLine(string s)
        {
            base.WriteLine("TestListener " + s);
        }
        protected override string[] GetSupportedAttributes()
        {
            // The following string array will allow the use of 
            // the name "customListenerAttribute" in the configuration file.
            return new string[] { "customListenerAttribute" };
        }
    }
    //</Snippet35>
}
//</Snippet1>


//<Snippet1>
// The following configuration file can be used with this sample.
// When using a configuration file #define ConfigFile.
//<configuration>
//    <system.diagnostics>
//        <sources>
//            <source name="TraceTest" switchName="SourceSwitch" switchType="System.Diagnostics.SourceSwitch" >
//                <listeners>
//                    <add name="console" type="System.Diagnostics.ConsoleTraceListener" initializeData="false" />
//                    <remove name ="Default" />
//                </listeners>
//            </source>
//        </sources>
//        <switches>
//            <!-- You can set the level at which tracing is to occur -->
//            <add name="SourceSwitch" value="Warning" />
//            <!-- You can turn tracing off -->
//            <!--add name="SourceSwitch" value="Off" -->
//        </switches>
//        <trace autoflush="true" indentsize="4"></trace>
//    </system.diagnostics>
//</configuration>
#define TRACE
//#define ConfigFile

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
        //<Snippet9>
        // Initialize the trace source.
        static TraceSource ts = new TraceSource("TraceTest");
        //</Snippet9>
        //<Snippet2>
        [SwitchAttribute("SourceSwitch", typeof(SourceSwitch))]
        static void Main()
        //</Snippet2>
        {
            try
            {
                // Initialize trace switches.
                //<Snippet7>
#if(!ConfigFile)
                SourceSwitch sourceSwitch = new SourceSwitch("SourceSwitch", "Verbose");
                ts.Switch = sourceSwitch;
                int idxConsole = ts.Listeners.Add(new System.Diagnostics.ConsoleTraceListener());
                ts.Listeners[idxConsole].Name = "console";
#endif
                //</Snippet7>
                DisplayProperties(ts);
                //<Snippet16>
                ts.Listeners["console"].TraceOutputOptions |= TraceOptions.Callstack;
                //</Snippet16>
                //<Snippet17>
                ts.TraceEvent(TraceEventType.Warning, 1);
                //</Snippet17>
                ts.Listeners["console"].TraceOutputOptions = TraceOptions.DateTime;
                //<Snippet18>
                // Issue file not found message as a warning.
                ts.TraceEvent(TraceEventType.Warning, 2, "File Test not found");
                //</Snippet18>
                //<Snippet24>
                // Issue file not found message as a verbose event using a formatted string.
                ts.TraceEvent(TraceEventType.Verbose, 3, "File {0} not found.", "test");
                //</Snippet24>
                // Issue file not found message as information.
                ts.TraceInformation("File {0} not found.", "test");
                //<Snippet26>
                ts.Listeners["console"].TraceOutputOptions |= TraceOptions.LogicalOperationStack;
                //</Snippet26>
                // Issue file not found message as an error event.
                ts.TraceEvent(TraceEventType.Error, 4, "File {0} not found.", "test");
                //<Snippet28>
                // Test the filter on the ConsoleTraceListener.
                ts.Listeners["console"].Filter = new SourceFilter("No match");
                ts.TraceData(TraceEventType.Error, 5,
                    "SourceFilter should reject this message for the console trace listener.");
                ts.Listeners["console"].Filter = new SourceFilter("TraceTest");
                ts.TraceData(TraceEventType.Error, 6,
                    "SourceFilter should let this message through on the console trace listener.");
                //</Snippet28>
                ts.Listeners["console"].Filter = null;
                // Use the TraceData method. 
                //<Snippet30>
                ts.TraceData(TraceEventType.Warning, 7, new object());
                //</Snippet30>
                //<Snippet31>
                ts.TraceData(TraceEventType.Warning, 8, new object[] { "Message 1", "Message 2" });
                //</Snippet31>
                // Activity tests.
                //<Snippet32>
                ts.TraceEvent(TraceEventType.Start, 9, "Will not appear until the switch is changed.");
                ts.Switch.Level = SourceLevels.ActivityTracing | SourceLevels.Critical;
                ts.TraceEvent(TraceEventType.Suspend, 10, "Switch includes ActivityTracing, this should appear");
                ts.TraceEvent(TraceEventType.Critical, 11, "Switch includes Critical, this should appear");
                //</Snippet32>
                //<Snippet33>
                ts.Flush();
                ts.Close();
                //</Snippet33>
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
        public static void DisplayProperties(TraceSource ts)
        {
            Console.WriteLine("TraceSource name = " + ts.Name);
            //<Snippet8>
            Console.WriteLine("TraceSource switch level = " + ts.Switch.Level);
            //</Snippet8>
            //<Snippet10>
            Console.WriteLine("TraceSource switch = " + ts.Switch.DisplayName);
            //</Snippet10>
            //<Snippet12>
            SwitchAttribute[] switches = SwitchAttribute.GetAll(typeof(TraceTest).Assembly);
            for (int i = 0; i < switches.Length; i++)
            {
                Console.WriteLine("Switch name = " + switches[i].SwitchName);
                Console.WriteLine("Switch type = " + switches[i].SwitchType);
            }
            //</Snippet12>
#if(ConfigFile)
            //<Snippet14>
            // Get the custom attributes for the TraceSource.
            Console.WriteLine("Number of custom trace source attributes = "
                + ts.Attributes.Count);
            foreach (DictionaryEntry de in ts.Attributes)
                Console.WriteLine("Custom trace source attribute = "
                    + de.Key + "  " + de.Value);
            //</Snippet14>
            //<Snippet15>
            // Get the custom attributes for the trace source switch.
            foreach (DictionaryEntry de in ts.Switch.Attributes)
                Console.WriteLine("Custom switch attribute = "
                    + de.Key + "  " + de.Value);
            //</Snippet15>
#endif
            //<Snippet19>
            Console.WriteLine("Number of listeners = " + ts.Listeners.Count);
            //</Snippet19>
            //<Snippet21>
            foreach (TraceListener traceListener in ts.Listeners)
            {
                Console.Write("TraceListener: " + traceListener.Name + "\t");
                // The following output can be used to update the configuration file.
                Console.WriteLine("AssemblyQualifiedName = " +
                    (traceListener.GetType().AssemblyQualifiedName));
            }
            //</Snippet21>
        }
    }
}
//</Snippet1>



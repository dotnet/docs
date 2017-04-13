//<Snippet1>
// This code example uses the following application configuration file:

//<?xml version="1.0" encoding="utf-8"?>
//<configuration>
//  <system.diagnostics>
//    <sources>
//      <source name="TraceTest" switchName="SourceSwitch" switchType="System.Diagnostics.SourceSwitch" >
//        <listeners>
//          <add name="Testlistener" />
//        </listeners>
//      </source>
//    </sources>
//    <switches>
//      <add name="SourceSwitch" value="Warning" />
//    </switches>
//    <sharedListeners>
//      <add name="Testlistener" type="CustomTraceListener.TestListener, CustomTraceListener, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null" initializeData="TestListener" Source="test"/>
//    </sharedListeners>
//    <trace autoflush="true" indentsize="4" />
//  </system.diagnostics>
//</configuration>

using System;
using System.Diagnostics;
using System.Configuration;
using System.Reflection;
using System.Collections;
namespace CustomTraceListener
{
    class Program
    {
        static void Main(string[] args)
        {
            TraceSource ts = new TraceSource("TraceTest");
            Console.WriteLine(ts.Switch.DisplayName);
            foreach (TraceListener traceListener in ts.Listeners)
            {
                Console.Write("TraceListener: " + traceListener.Name + "\t");
                // The following output can be used to update the configuration file.
                Console.WriteLine("AssemblyQualifiedName = " +
                    (traceListener.GetType().AssemblyQualifiedName));
            }
            ts.TraceEvent(TraceEventType.Error, 1, "test error message");
        }
    }
    public class TestListener : TraceListener
    {
        string source;
        string name;
        public TestListener(string listenerName)
        {
            name = listenerName;
        }

        public string Source
        {
            get
            {
                foreach (DictionaryEntry de in this.Attributes)
                    if (de.Key.ToString().ToLower() == "source")
                        source = de.Value.ToString();
                return source;
            }
            set { source = value; }
        }

        public override void Write(string s)
        {
            Console.Write(name + " " + Source + ": " + s);
        }
        public override void WriteLine(string s)
        {
            Console.WriteLine(s);
        }
        protected override string[] GetSupportedAttributes()
        {
            return new string[] { "Source" };
        }

    }
}
// This code example creates the following output:
/*
SourceSwitch
TraceListener: Default  AssemblyQualifiedName = System.Diagnostics.DefaultTraceL
istener, System, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0
89
TraceListener: Testlistener     AssemblyQualifiedName = CustomTraceListener.Test
Listener, CustomTraceListener, Version=1.0.0.0, Culture=neutral, PublicKeyToken=
null
TestListener test: TraceTest Error: 1 : test error message
*/
//</Snippet1>
//<Snippet1>
using System;
using System.Management;
using System.Configuration.Install;
using System.Management.Instrumentation;

// This example demonstrates how to create
// a management event class by using
// the InstrumentationType enumeration

// Specify which namespace the management event
// class is created in
[assembly:Instrumented("Root/Default")]

// Let the system know you will run
// InstallUtil.exe tool against this assembly
[System.ComponentModel.RunInstaller(true)]
public class MyInstaller : 
    DefaultManagementProjectInstaller {}

namespace WMISample
{
    // Create a management instrumentation event class
    [InstrumentationClass(InstrumentationType.Event)]
    public class MyEvent
    {
        private string EventName;
        public void setEventName(string name)
        {
            EventName = name;
        }
    }

    public class WMIInstrumentedEventExample
    {
        public static void Main() 
        {
            MyEvent e = new MyEvent();
            e.setEventName("Hello");
        
            // Fire a management event
            Instrumentation.Fire(e);        
            return;
        }
    }
}
//</Snippet1>
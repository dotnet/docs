// <Snippet1>
/////////////////////////////////////////////////////////////////////////////////
//
// NAME     TraceSource2.cpp : main project file
//
/////////////////////////////////////////////////////////////////////////////////



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

#using <System.dll>

using namespace System;
using namespace System::Collections;
using namespace System::Diagnostics;
using namespace System::Reflection;
using namespace System::IO;
using namespace System::Security::Permissions;

void DisplayProperties(TraceSource^ ts);  // Forward Declaration


int main()
{
    TraceSource^ ts = gcnew TraceSource("TraceTest");

    try
        {
        // Initialize trace switches.
#if(!ConfigFile)
        SourceSwitch^ sourceSwitch = gcnew SourceSwitch("SourceSwitch", "Verbose");
		ts->Switch = sourceSwitch;
        int idxConsole = ts->Listeners->Add(gcnew System::Diagnostics::ConsoleTraceListener());
        ts->Listeners[idxConsole]->Name = "console";
#endif
        DisplayProperties(ts);
        ts->Listeners["console"]->TraceOutputOptions |= TraceOptions::Callstack;
        ts->TraceEvent(TraceEventType::Warning, 1);
        ts->Listeners["console"]->TraceOutputOptions = TraceOptions::DateTime;
        // Issue file not found message as a warning.
        ts->TraceEvent(TraceEventType::Warning, 2, "File Test not found");
        // Issue file not found message as a verbose event using a formatted string.
        ts->TraceEvent(TraceEventType::Verbose, 3, "File {0} not found.", "test");
        // Issue file not found message as information.
        ts->TraceInformation("File {0} not found.", "test");
        ts->Listeners["console"]->TraceOutputOptions |= TraceOptions::LogicalOperationStack;
        // Issue file not found message as an error event.
        ts->TraceEvent(TraceEventType::Error, 4, "File {0} not found.", "test");

        // Test the filter on the ConsoleTraceListener.
        ts->Listeners["console"]->Filter = gcnew SourceFilter("No match");
        ts->TraceData(TraceEventType::Error, 5,
            "SourceFilter should reject this message for the console trace listener.");
        ts->Listeners["console"]->Filter = gcnew SourceFilter("TraceTest");
        ts->TraceData(TraceEventType::Error, 6,
            "SourceFilter should let this message through on the console trace listener.");
        ts->Listeners["console"]->Filter = nullptr;

        // Use the TraceData method. 
        ts->TraceData(TraceEventType::Warning, 7, gcnew array<Object^>{ "Message 1", "Message 2" });

        // Activity tests.
        ts->TraceEvent(TraceEventType::Start, 9, "Will not appear until the switch is changed.");
        ts->Switch->Level = SourceLevels::ActivityTracing | SourceLevels::Critical;
        ts->TraceEvent(TraceEventType::Suspend, 10, "Switch includes ActivityTracing, this should appear");
        ts->TraceEvent(TraceEventType::Critical, 11, "Switch includes Critical, this should appear");
        ts->Flush();
        ts->Close();
        Console::WriteLine("Press enter key to exit.");
        Console::Read();
        }
    catch (Exception ^e)
        {
         // Catch any unexpected exception.
         Console::WriteLine("Unexpected exception: " + e->ToString());
         Console::Read();
        }
}


void DisplayProperties(TraceSource^ ts)
{
    Console::WriteLine("TraceSource name = " + ts->Name);
//    Console::WriteLine("TraceSource switch level = " + ts->Switch->Level);         // error C3063: operator '+': all operands must have the same enumeration type
    Console::WriteLine("TraceSource switch level = {0}", ts->Switch->Level);         //  SUCCESS:  does compile.  Weird
    Console::WriteLine("TraceSource Attributes Count " + ts->Attributes->Count);     //  SUCCESS:  also compiles.  Really weird
    Console::WriteLine("TraceSource Attributes Count = {0}", ts->Attributes->Count); //  SUCCESS:  okay, I give up.  Somebody call me a cab.

    Console::WriteLine("TraceSource switch = " + ts->Switch->DisplayName);
    array<SwitchAttribute^>^ switches = SwitchAttribute::GetAll(TraceSource::typeid->Assembly);

    for (int i = 0; i < switches->Length; i++)
        { 
        Console::WriteLine("Switch name = " + switches[i]->SwitchName);
        Console::WriteLine("Switch type = " + switches[i]->SwitchType);
        }

#if(ConfigFile)
            // Get the custom attributes for the TraceSource.
            Console::WriteLine("Number of custom trace source attributes = "
                + ts.Attributes.Count);
            foreach (DictionaryEntry de in ts.Attributes)
                Console::WriteLine("Custom trace source attribute = "
                    + de.Key + "  " + de.Value);
            // Get the custom attributes for the trace source switch.
            foreach (DictionaryEntry de in ts.Switch.Attributes)
                Console::WriteLine("Custom switch attribute = "
                    + de.Key + "  " + de.Value);
#endif
       Console::WriteLine("Number of listeners = " + ts->Listeners->Count);
       for each (TraceListener ^ traceListener in ts->Listeners)
           {
           Console::Write("TraceListener: " + traceListener->Name + "\t");
           // The following output can be used to update the configuration file.
           Console::WriteLine("AssemblyQualifiedName = " +
               (traceListener->GetType()->AssemblyQualifiedName));
           }
}
// </Snippet1>

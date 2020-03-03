//<Snippet1>
#define TRACE

#using <System.dll>

using namespace System;
using namespace System::Diagnostics;

namespace TestingTracing
{
    //<Snippet2>
    public ref class ErrorFilter : TraceFilter
    {
    public:
        virtual bool ShouldTrace(TraceEventCache^ cache, String^ source,
            TraceEventType eventType, int id, String^ formatOrMessage,
            array<Object^>^ args, Object^ data, array<Object^>^ dataArray) override
        {
            return eventType == TraceEventType::Error;
        }
    };
    //</Snippet2>

    ref class TraceTest
    {
    public:
        static void Main()
        {
            TraceSource^ ts = gcnew TraceSource("TraceTest");
            SourceSwitch^ sourceSwitch = gcnew SourceSwitch("SourceSwitch", "Verbose");
            ts->Switch = sourceSwitch;
            ConsoleTraceListener^ ctl = gcnew ConsoleTraceListener();
            ctl->Name = "console";
            ctl->TraceOutputOptions = TraceOptions::DateTime;
            ctl->Filter = gcnew ErrorFilter();
            ts->Listeners->Add(ctl);

            ts->TraceEvent(TraceEventType::Warning, 1, "*** This event will be filtered out ***");
            // this event will be get displayed
            ts->TraceEvent(TraceEventType::Error, 2, "*** This event will be be displayed ***");

            ts->Flush();
            ts->Close();
        }
    };
}

int main()
{
    TestingTracing::TraceTest::Main();
}
//</Snippet1>

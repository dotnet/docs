// <snippet2>
#using <System.dll>

using namespace System;
using namespace System::Diagnostics;

ref class InitTraceListener
{
public:
    static void Main()
    {
        // <snippet4>
        Trace::Listeners->Add(gcnew TextWriterTraceListener("TextWriterOutput.log", "myListener"));
        // <snippet3>
        Trace::TraceInformation("Test message.");
        // You must close or flush the trace to empty the output buffer.
        Trace::Flush();
        // </snippet3>
        // </snippet4>
        Trace::Close();

        // <snippet5>
        TextWriterTraceListener^ myListener =
            gcnew TextWriterTraceListener("TextWriterOutput.log", "myListener");
        myListener->WriteLine("Test message.");
        // You must close or flush the trace listener to empty the output buffer.
        myListener->Flush();
        // </snippet5>
        myListener->Close();
    }
};

int main()
{
    InitTraceListener::Main();
}
// </snippet2>

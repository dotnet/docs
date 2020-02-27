//<Snippet1>

///////////////////////////////////////////////////////////////////////
//
// EventSchemaTraceListener.cpp : main project file.
// Expected Output:
// 1)
//      EventSchemaTraceListener CPP Sample
//
//      IsThreadSafe? True
//      BufferSize =  65536
//      MaximumFileSize =  20480000
//      MaximumNumberOfFiles =  2
//      Name =  eventListener
//      TraceLogRetentionOption = LimitedCircularFiles
//      TraceOutputOptions = DateTime, Timestamp, ProcessId
//
//      Press the enter key to exit
//
// 2) An output file is created named TraceOutput.xml.  It will be
//    opened and displayed in Microsoft Notepad.
//
// NOTE 1:
//  Under certain circumstances, the VS C++ compiler will treat
//          Console::WriteLine("MyText = " + MyVar);
//        differently then the VS CSharp compiler.
//        The C++ compiler will produce error C3063, whereas the 
//        CSharp compiler accepts the statement.
//        This occurs when the VS C++ compiler cannot determine the
//        datatype of "MyVar" because it is an enumeration type.
//        The solution is:
//        Use either of the following two methods:
//          Console::WriteLine("MyText = {0} " , MyVar);
//          Console::WriteLine("MyText =  " + MyVar.ToString());
//
//        Although not specific to this particular pieces of code,
//        this is demonstrated below in the Display function:  The
//        last two members, TraceLogRetentionOption, and
//        TraceOutputOptions, are enumerations, and cannot simply be
//        concatenated into Console::WriteLine.
//
///////////////////////////////////////////////////////////////////////
#using <System.dll>
#using <System.Core.dll>

#define NOCONFIGFILE 1
using namespace System;
using namespace System::IO;
using namespace System::Diagnostics;


[STAThreadAttribute]
void main()
{
    Console::WriteLine("EventSchemaTraceListener CPP Sample\n");

    File::Delete("TraceOutput.xml");
    TraceSource ^ ts = gcnew TraceSource("TestSource");


#if NOCONFIGFILE
    ts->Listeners->Add(gcnew EventSchemaTraceListener("TraceOutput.xml",
                            "eventListener", 65536,
                            TraceLogRetentionOption::LimitedCircularFiles,
                            20480000, 2));
    ts->Listeners["eventListener"]->TraceOutputOptions =
                                    TraceOptions::DateTime |
                                    TraceOptions::ProcessId |
                                    TraceOptions::Timestamp;
#endif

    EventSchemaTraceListener ^ ESTL =
               (EventSchemaTraceListener^)(ts->Listeners["eventListener"]);


    Console::WriteLine("IsThreadSafe?            = " + ESTL->IsThreadSafe);
    Console::WriteLine("BufferSize               = " + ESTL->BufferSize);
    Console::WriteLine("MaximumFileSize          = " + ESTL->MaximumFileSize);
    Console::WriteLine("MaximumNumberOfFiles     = " + ESTL->MaximumNumberOfFiles);
    Console::WriteLine("Name                     = " + ESTL->Name);
    Console::WriteLine("TraceLogRetentionOption  = " + ESTL->TraceLogRetentionOption.ToString());
    Console::WriteLine("TraceOutputOptions       = {0}\n", ESTL->TraceOutputOptions);

    ts->Switch->Level = SourceLevels::All;
    String ^ testString = "<Test><InnerElement Val=\"1\" />"
                        + "<InnerElement Val=\"Data\"/>"
                        + "<AnotherElement>11</AnotherElement></Test>";

    UnescapedXmlDiagnosticData ^ unXData = gcnew UnescapedXmlDiagnosticData(testString);
    ts->TraceData(TraceEventType::Error, 38, unXData);
    ts->TraceEvent(TraceEventType::Error, 38, testString);
    ts->Flush();
    ts->Close();

    Process::Start("notepad.exe", "TraceOutput.xml");
    Console::WriteLine("\nPress the enter key to exit");
    Console::ReadLine();
}
//</Snippet1>
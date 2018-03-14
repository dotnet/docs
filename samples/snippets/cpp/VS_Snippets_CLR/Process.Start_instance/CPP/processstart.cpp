// <Snippet1>
#using <System.dll>
using namespace System;
using namespace System::Diagnostics;
using namespace System::ComponentModel;

int main()
{
    Process^ myProcess = gcnew Process;

    try
    {
        myProcess->StartInfo->UseShellExecute = false;
        // You can start any process, HelloWorld is a do-nothing example.
        myProcess->StartInfo->FileName = "C:\\HelloWorld.exe";
        myProcess->StartInfo->CreateNoWindow = true;
        myProcess->Start();
        // This code assumes the process you are starting will terminate itself. 
        // Given that is is started without a window so you cannot terminate it 
        // on the desktop, it must terminate itself or you can do it programmatically
        // from this application using the Kill method.
    }
    catch ( Exception^ e ) 
    {
        Console::WriteLine( e->Message );
    }
}
// </Snippet1>

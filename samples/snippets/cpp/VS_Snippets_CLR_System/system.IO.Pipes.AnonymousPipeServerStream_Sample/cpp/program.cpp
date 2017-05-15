//<snippet01>
#using <System.dll>
#using <System.Core.dll>

using namespace System;
using namespace System::IO;
using namespace System::IO::Pipes;
using namespace System::Diagnostics;

ref class PipeServer
{
public:
    static void Main()
    {
        Process^ pipeClient = gcnew Process();

        pipeClient->StartInfo->FileName = "pipeClient.exe";

        AnonymousPipeServerStream^ pipeServer =
            gcnew AnonymousPipeServerStream(PipeDirection::Out,
            HandleInheritability::Inheritable);
        // Show that anonymous pipes do not support Message mode.
        try
        {
            Console::WriteLine("[SERVER] Setting ReadMode to \"Message\".");
            pipeServer->ReadMode = PipeTransmissionMode::Message;
        }
        catch (NotSupportedException^ e)
        {
            Console::WriteLine("[SERVER] Exception:\n    {0}", e->Message);
        }

        Console::WriteLine("[SERVER] Current TransmissionMode: {0}.",
            pipeServer->TransmissionMode);

        // Pass the client process a handle to the server.
        pipeClient->StartInfo->Arguments =
            pipeServer->GetClientHandleAsString();
        pipeClient->StartInfo->UseShellExecute = false;
        pipeClient->Start();

        pipeServer->DisposeLocalCopyOfClientHandle();

        try
        {
            // Read user input and send that to the client process.
            StreamWriter^ sw = gcnew StreamWriter(pipeServer);

            sw->AutoFlush = true;
            // Send a 'sync message' and wait for client to receive it.
            sw->WriteLine("SYNC");
            pipeServer->WaitForPipeDrain();
            // Send the console input to the client process.
            Console::Write("[SERVER] Enter text: ");
            sw->WriteLine(Console::ReadLine());
            sw->Close();
        }
        // Catch the IOException that is raised if the pipe is broken
        // or disconnected.
        catch (IOException^ e)
        {
            Console::WriteLine("[SERVER] Error: {0}", e->Message);
        }
        pipeServer->Close();
        pipeClient->WaitForExit();
        pipeClient->Close();
        Console::WriteLine("[SERVER] Client quit. Server terminating.");
    }
};

int main()
{
    PipeServer::Main();
}
//</snippet01>
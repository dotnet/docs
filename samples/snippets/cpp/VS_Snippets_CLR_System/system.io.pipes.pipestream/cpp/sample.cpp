//<snippet1>
#using <System.dll>
#using <System.Core.dll>

using namespace System;
using namespace System::IO;
using namespace System::IO::Pipes;
using namespace System::Diagnostics;

ref class PipeStreamExample
{
private:
    static array<Byte>^ matchSign = {9, 0, 9, 0};

public:
    static void Main()
    {
        array<String^>^ args = Environment::GetCommandLineArgs();
        if (args->Length < 2)
        {
            Process^ clientProcess = gcnew Process();

            clientProcess->StartInfo->FileName = Environment::CommandLine;

            AnonymousPipeServerStream^ pipeServer =
                gcnew AnonymousPipeServerStream(PipeDirection::In,
                HandleInheritability::Inheritable);
            // Pass the client process a handle to the server.
            clientProcess->StartInfo->Arguments = pipeServer->GetClientHandleAsString();
            clientProcess->StartInfo->UseShellExecute = false;
            Console::WriteLine("[SERVER] Starting client process...");
            clientProcess->Start();

            pipeServer->DisposeLocalCopyOfClientHandle();

            try
            {
                if (WaitForClientSign(pipeServer))
                {
                    Console::WriteLine("[SERVER] Valid sign code received!");
                }
                else
                {
                    Console::WriteLine("[SERVER] Invalid sign code received!");
                }
            }
            catch (IOException^ e)
            {
                 Console::WriteLine("[SERVER] Error: {0}", e->Message);
            }
            clientProcess->WaitForExit();
            clientProcess->Close();
            Console::WriteLine("[SERVER] Client quit. Server terminating.");
        }
        else
        {
            PipeStream^ pipeClient =
                gcnew AnonymousPipeClientStream(PipeDirection::Out, args[1]);
            try
            {
                Console::WriteLine("[CLIENT] Sending sign code...");
                SendClientSign(pipeClient);
            }
            catch (IOException^ e)
            {
                Console::WriteLine("[CLIENT] Error: {0}", e->Message);
            }
            Console::WriteLine("[CLIENT] Terminating.");
        }
    }

    //<snippet2>
private:
    static bool WaitForClientSign(PipeStream^ inStream)
    {
        array<Byte>^ inSign = gcnew array<Byte>(matchSign->Length);
        int len = inStream->Read(inSign, 0, matchSign->Length);
        bool valid = len == matchSign->Length;

        while (valid && len-- > 0)
        {
            valid = valid && (matchSign[len] == inSign[len]);
        }
        return valid;
    }
    //</snippet2>

    static void SendClientSign(PipeStream^ outStream)
    {
        outStream->Write(matchSign, 0, matchSign->Length);
    }
};

int main()
{
    PipeStreamExample::Main();
}
//</snippet1>

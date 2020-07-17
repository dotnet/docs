//<snippet01>
#using <System.Core.dll>

using namespace System;
using namespace System::IO;
using namespace System::IO::Pipes;

ref class PipeClient
{
public:
    static void Main(array<String^>^ args)
    {
        if (args->Length > 1)
        {
            PipeStream^ pipeClient = gcnew AnonymousPipeClientStream(PipeDirection::In, args[1]);

            Console::WriteLine("[CLIENT] Current TransmissionMode: {0}.",
                pipeClient->TransmissionMode);

            StreamReader^ sr = gcnew StreamReader(pipeClient);

            // Display the read text to the console
            String^ temp;

            // Wait for 'sync message' from the server.
            do
            {
                Console::WriteLine("[CLIENT] Wait for sync...");
                temp = sr->ReadLine();
            }
            while (!temp->StartsWith("SYNC"));

            // Read the server data and echo to the console.
            while ((temp = sr->ReadLine()) != nullptr)
            {
                Console::WriteLine("[CLIENT] Echo: " + temp);
            }
            sr->Close();
            pipeClient->Close();
        }
        Console::Write("[CLIENT] Press Enter to continue...");
        Console::ReadLine();
    }
};

int main()
{
    array<String^>^ args = Environment::GetCommandLineArgs();
    PipeClient::Main(args);
}
//</snippet01>

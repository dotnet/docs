
#using <System.dll>
#using <System.Core.dll>

using namespace System;
using namespace System::IO;
using namespace System::IO::Pipes;
using namespace System::Text;
using namespace System::Security::Principal;
using namespace System::Diagnostics;
using namespace System::Threading;

// Defines the data protocol for reading and writing strings on our stream
public ref class StreamString
{
private:
    Stream^ ioStream;
    UnicodeEncoding^ streamEncoding;

public:
    StreamString(Stream^ ioStream)
    {
        this->ioStream = ioStream;
        streamEncoding = gcnew UnicodeEncoding();
    }

    String^ ReadString()
    {
        int len;

        len = ioStream->ReadByte() * 256;
        len += ioStream->ReadByte();
        array<Byte>^ inBuffer = gcnew array<Byte>(len);
        ioStream->Read(inBuffer, 0, len);

        return streamEncoding->GetString(inBuffer);
    }

    int WriteString(String^ outString)
    {
        array<Byte>^ outBuffer = streamEncoding->GetBytes(outString);
        int len = outBuffer->Length;
        if (len > UInt16::MaxValue)
        {
            len = (int)UInt16::MaxValue;
        }
        ioStream->WriteByte((Byte)(len / 256));
        ioStream->WriteByte((Byte)(len & 255));
        ioStream->Write(outBuffer, 0, len);
        ioStream->Flush();

        return outBuffer->Length + 2;
    }
};

public ref class PipeClient
{
private:
    static int numClients = 4;

public:
    static void Main(array<String^>^ Args)
    {
        if (Args->Length > 1)
        {
            if (Args[1] == "spawnclient")
            {
                NamedPipeClientStream^ pipeClient =
                    gcnew NamedPipeClientStream(".", "testpipe",
                        PipeDirection::InOut, PipeOptions::None,
                        TokenImpersonationLevel::Impersonation);

                Console::WriteLine("Connecting to server...\n");
                pipeClient->Connect();

                //<snippet2>
                StreamString^ ss = gcnew StreamString(pipeClient);
                // Validate the server's signature string
                if (ss->ReadString() == "I am the one true server!")
                {
                    // The client security token is sent with the first write.
                    // Send the name of the file whose contents are returned
                    // by the server.
                    ss->WriteString("c:\\textfile.txt");

                    // Print the file to the screen.
                    Console::Write(ss->ReadString());
                }
                else
                {
                    Console::WriteLine("Server could not be verified.");
                }
                pipeClient->Close();
                //</snippet2>
                // Give the client process some time to display results before exiting.
                Thread::Sleep(4000);
            }
        }
        else
        {
            Console::WriteLine("\n*** Named pipe client stream with impersonation example ***\n");
            StartClients();
        }
    }

private:
    // Helper function to create pipe client processes
    static void StartClients()
    {
        int i;
        array<Process^>^ plist = gcnew array<Process^>(numClients);

        Console::WriteLine("Spawning client processes...\n");
        for (i = 0; i < numClients; i++)
        {
            // Start 'this' program but spawn a named pipe client.
            plist[i] = Process::Start(Process::GetCurrentProcess()->ProcessName + ".exe", "spawnclient");
        }
        while (i > 0)
        {
            for (int j = 0; j < numClients; j++)
            {
                if (plist[j] != nullptr)
                {
                    if (plist[j]->HasExited)
                    {
                        Console::WriteLine("Client process[{0}] has exited.",
                            plist[j]->Id);
                        plist[j] = nullptr;
                        i--;    // decrement the process watch count
                    }
                    else
                    {
                        Thread::Sleep(250);
                    }
                }
            }
        }
        Console::WriteLine("\nClient processes finished, exiting.");
    }
};

int main()
{
    PipeClient::Main(Environment::GetCommandLineArgs());
}

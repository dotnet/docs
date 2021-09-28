//<snippet01>
#using <System.Core.dll>

using namespace System;
using namespace System::IO;
using namespace System::IO::Pipes;
using namespace System::Text;
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

// Contains the method executed in the context of the impersonated user
public ref class ReadFileToStream
{
private:
    String^ fn;
    StreamString ^ss;

public:
    ReadFileToStream(StreamString^ str, String^ filename)
    {
        fn = filename;
        ss = str;
    }

    void Start()
    {
        String^ contents = File::ReadAllText(fn);
        ss->WriteString(contents);
    }
};

public ref class PipeServer
{
private:
    static int numThreads = 4;

public:
    static void Main()
    {
        int i;
        array<Thread^>^ servers = gcnew array<Thread^>(numThreads);

        Console::WriteLine("\n*** Named pipe server stream with impersonation example ***\n");
        Console::WriteLine("Waiting for client connect...\n");
        for (i = 0; i < numThreads; i++)
        {
            servers[i] = gcnew Thread(gcnew ThreadStart(&ServerThread));
            servers[i]->Start();
        }
        Thread::Sleep(250);
        while (i > 0)
        {
            for (int j = 0; j < numThreads; j++)
            {
                if (servers[j] != nullptr)
                {
                    if (servers[j]->Join(250))
                    {
                        Console::WriteLine("Server thread[{0}] finished.", servers[j]->ManagedThreadId);
                        servers[j] = nullptr;
                        i--;    // decrement the thread watch count
                    }
                }
            }
        }
        Console::WriteLine("\nServer threads exhausted, exiting.");
    }

private:
    static void ServerThread()
    {
        NamedPipeServerStream^ pipeServer =
            gcnew NamedPipeServerStream("testpipe", PipeDirection::InOut, numThreads);

        int threadId = Thread::CurrentThread->ManagedThreadId;

        // Wait for a client to connect
        pipeServer->WaitForConnection();

        Console::WriteLine("Client connected on thread[{0}].", threadId);
        try
        {
            //<snippet2>
            // Read the request from the client. Once the client has
            // written to the pipe its security token will be available.

            StreamString^ ss = gcnew StreamString(pipeServer);

            // Verify our identity to the connected client using a
            // string that the client anticipates.

            ss->WriteString("I am the one true server!");
            String^ filename = ss->ReadString();

            // Read in the contents of the file while impersonating the client.
            ReadFileToStream^ fileReader = gcnew ReadFileToStream(ss, filename);

            // Display the name of the user we are impersonating.
            Console::WriteLine("Reading file: {0} on thread[{1}] as user: {2}.",
                filename, threadId, pipeServer->GetImpersonationUserName());
            pipeServer->RunAsClient(gcnew PipeStreamImpersonationWorker(fileReader, &ReadFileToStream::Start));
            //</snippet2>
        }
        // Catch the IOException that is raised if the pipe is broken
        // or disconnected.
        catch (IOException^ e)
        {
            Console::WriteLine("ERROR: {0}", e->Message);
        }
        pipeServer->Close();
    }
};

int main()
{
    PipeServer::Main();
}
//</snippet01>
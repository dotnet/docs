#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Net::Sockets;
using namespace System::Threading;

namespace TcpListenerExample
{
    public ref class TcpServer
    {
        // <Snippet2>
    public:
        static void GetSetExclusiveAddressUse(TcpListener^ listener)
        {
            // Set Exclusive Address Use for the underlying socket.
            listener->ExclusiveAddressUse = true;
            Console::WriteLine("ExclusiveAddressUse value is {0}",
                listener->ExclusiveAddressUse);
        }
        // </Snippet2>

        // <Snippet3>
    public:
        static void DoStart(TcpListener^ listener, int backlog)
        {
            // Start listening for client connections with the
            // specified backlog.
            listener->Start(backlog);
            Console::WriteLine("Started listening");
        }
        // </Snippet3>

        // <Snippet4>
        // Thread signal.
    public:
        static ManualResetEvent^ ClientConnected;

        // Accept one client connection asynchronously.
    public:
        static void DoBeginAcceptSocket(TcpListener^ listener)
        {
            // Set the event to nonsignaled state.
            ClientConnected->Reset();

            // Start to listen for connections from a client.
            Console::WriteLine("Waiting for a connection...");

            // Accept the connection.
            // BeginAcceptSocket() creates the accepted socket.
            listener->BeginAcceptSocket(
                gcnew AsyncCallback(DoAcceptSocketCallback), listener);
            // Wait until a connection is made and processed before
            // continuing.
            ClientConnected->WaitOne();
        }

        // Process the client connection.
    public:
        static void DoAcceptSocketCallback(IAsyncResult^ result)
        {
            // Get the listener that handles the client request.
            TcpListener^ listener = (TcpListener^) result->AsyncState;

            // End the operation and display the received data on the
            //console.
            Socket^ clientSocket = listener->EndAcceptSocket(result);

            // Process the connection here. (Add the client to a
            // server table, read data, etc.)
            Console::WriteLine("Client connected completed");

            // Signal the calling thread to continue.
            ClientConnected->Set();
        }
        // </Snippet4>

        // <Snippet5>
        // Thread signal.
    public:
        static ManualResetEvent^ TcpClientConnected;

        // Accept one client connection asynchronously.
    public:
        static void DoBeginAcceptTcpClient(TcpListener^ listener)
        {
            // Set the event to nonsignaled state.
            TcpClientConnected->Reset();

            // Start to listen for connections from a client.
            Console::WriteLine("Waiting for a connection...");

            // Accept the connection.
            // BeginAcceptSocket() creates the accepted socket.
            listener->BeginAcceptTcpClient(
                gcnew AsyncCallback(DoAcceptTcpClientCallback),
                listener);

            // Wait until a connection is made and processed before
            // continuing.
            TcpClientConnected->WaitOne();
        }

        // Process the client connection.
    public:
        static void DoAcceptTcpClientCallback(IAsyncResult^ result)
        {
            // Get the listener that handles the client request.
            TcpListener^ listener = (TcpListener^) result->AsyncState;

            // End the operation and display the received data on
            // the console.
            TcpClient^ client = listener->EndAcceptTcpClient(result);

            // Process the connection here. (Add the client to a
            // server table, read data, etc.)
            Console::WriteLine("Client connected completed");

            // Signal the calling thread to continue.
            TcpClientConnected->Set();

        }
        // </Snippet5>

    public:
        static void Main()
        {
            ClientConnected = gcnew ManualResetEvent(false);

            TcpClientConnected = gcnew ManualResetEvent(false);

            TcpListener^ listener = gcnew TcpListener(
				Dns::GetHostAddresses(Dns::GetHostName())[0], 4242);

            GetSetExclusiveAddressUse(listener);

            // Start listening for client connections.
            DoStart(listener, 20);

            // Accept one client connection asynchronously
            DoBeginAcceptSocket(listener);
            DoBeginAcceptTcpClient(listener);

            Console::WriteLine("Hit any key");
            Console::Read();
        }
    };
}

[STAThread]
int main()
{
    TcpListenerExample::TcpServer::Main();
}

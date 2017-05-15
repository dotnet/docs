#using <System.dll>

using namespace System;
using namespace System::Collections::Generic;
using namespace System::Net;
using namespace System::Net::Sockets;
using namespace System::Text;
using namespace System::Threading;

namespace SocketExample
{
    ref class TestClass 
    {
    public:

        static void SyncSendAndReceive(String^ host, int port)
        {
            //<Snippet1>
            Encoding^ asciiEncoding = Encoding::ASCII;
            
            // Create the TCP Socket.
            IPHostEntry^ hostEntry = Dns::Resolve(host);
            IPEndPoint^ endPoint = gcnew IPEndPoint(
                hostEntry->AddressList[0], port);
            
            Socket^ tcpSocket = gcnew Socket(
                AddressFamily::InterNetwork, SocketType::Stream, 
                ProtocolType::Tcp);
            
            tcpSocket->Connect(endPoint);
            
            // Build the buffers to be sent.
            List<ArraySegment<Byte> >^ buffers = 
                gcnew List<ArraySegment<Byte> >(2);
            
            buffers->Add(ArraySegment<Byte>(
                asciiEncoding->GetBytes("<buffer 1>")));
            
            buffers->Add(ArraySegment<Byte>(
                asciiEncoding->GetBytes("<buffer 2>")));
            
            // Send the data.
            tcpSocket->Send(buffers);       
            //</Snippet1>

            //<Snippet2>

            // Build the buffers for the receive.
            List<ArraySegment<Byte> >^ receiveBuffers = 
                gcnew List<ArraySegment<Byte> >(2);
            
            array<Byte>^ bigBuffer = gcnew array<Byte>(1024);
            
            // Specify the first buffer segment (2 bytes, starting 
            // at the 4th element of bigBuffer)
            receiveBuffers->Add(ArraySegment<Byte>(bigBuffer, 4, 2));
            
            // Specify the second buffer segment (500 bytes, starting
            // at the 20th element of bigBuffer)
            receiveBuffers->Add(
                ArraySegment<Byte>(bigBuffer, 20, 500));
            
            tcpSocket->Receive(receiveBuffers);
            
            Console::WriteLine("{0}", 
                asciiEncoding->GetString(bigBuffer));
            //</Snippet2>
        }

        static void AsyncSendAndReceive(String^ host, int port)
        {
            //<Snippet3>
            Encoding^ asciiEncoding = Encoding::ASCII;
            
            // Create the TCP Socket.
            IPHostEntry^ hostEntry = Dns::Resolve(host);
            IPEndPoint^ endPoint = gcnew IPEndPoint(
                hostEntry->AddressList[0], port);
            
            Socket^ tcpSocket = gcnew Socket(
                AddressFamily::InterNetwork, SocketType::Stream, 
                ProtocolType::Tcp);
            
            tcpSocket->Connect(endPoint);
            
            // Build the buffers to be sent.
            List<ArraySegment<Byte> >^ buffers = 
                gcnew List<ArraySegment<Byte> >(2);
            
            buffers->Add(ArraySegment<Byte>(
                asciiEncoding->GetBytes("<buffer 1>")));
            
            buffers->Add(ArraySegment<Byte>(
                asciiEncoding->GetBytes("<buffer 2>")));
            
            // Create delegate instance for the callback function
            AsyncCallback^ sendCallback = 
                gcnew AsyncCallback(SendCallback);

            // Send the data.
            allDone->Reset();
            tcpSocket->BeginSend(buffers, SocketFlags::None, 
                sendCallback, (Object^)tcpSocket);
            allDone->WaitOne();
            
            // done
            Console::WriteLine("Data sent");
            //</Snippet3>

            //<Snippet4>
            
            // Build the buffers for the receive.
            List<ArraySegment<Byte> >^ receiveBuffers = 
                gcnew List<ArraySegment<Byte> >(2);
            
            array<Byte>^ bigBuffer = gcnew array<Byte>(1024);
            
            // Specify the first buffer segment (2 bytes, starting 
            // at the 6th element of bigBuffer)
            receiveBuffers->Add(ArraySegment<Byte>(bigBuffer, 6, 2));
            
            // Specify the second buffer segment (500 bytes, starting
            // at the 10th element of bigBuffer)
            receiveBuffers->Add(
                ArraySegment<Byte>(bigBuffer, 10, 500));
            
            // Create delegate instance for the callback function
            AsyncCallback^ receiveCallback = 
                gcnew AsyncCallback(ReceiveCallback);

            // Receive the data.
            allDone->Reset();
            tcpSocket->BeginReceive(
                receiveBuffers, SocketFlags::None, 
                receiveCallback, (Object^)tcpSocket);
            
            allDone->WaitOne();
            
            Console::WriteLine("Data received:");
            Console::WriteLine("{0}", 
                asciiEncoding->GetString(bigBuffer));
            //</Snippet4>
        }

    private:
        
        static ManualResetEvent^ allDone = 
            gcnew ManualResetEvent(false); 

        static void SendCallback(IAsyncResult^ result)
        {
            allDone->Set();
            Socket^ sendSocket = (Socket^)result->AsyncState;
            sendSocket->EndSend(result);
        }

        static void ReceiveCallback(IAsyncResult^ result)
        {
            allDone->Set();
            Socket^ receiveSocket = (Socket^)result->AsyncState;
            receiveSocket->EndReceive(result);
        }
    };
}

int main()
{
    Console::WriteLine("starting synchronous test");
    SocketExample::TestClass::SyncSendAndReceive("localhost", 80);
    Console::WriteLine("starting asynchronous test");
    SocketExample::TestClass::AsyncSendAndReceive("localhost", 80);
    Console::WriteLine("ending tests");

    return 0;
}

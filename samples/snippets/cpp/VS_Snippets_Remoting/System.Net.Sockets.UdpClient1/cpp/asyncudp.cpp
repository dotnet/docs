#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Net;
using namespace System::Net::Sockets;
using namespace System::Text;
using namespace System::Threading;

public ref class UdpClientExample
{
public:
    value struct UdpState
    {
    public:
        UdpClient^ udpClient;
        IPEndPoint^ ipEndPoint;
    };

private:
    static int listenPort = 13000;

    //<snippet1>
public:
    static bool isMessageReceived;

    static void ReceiveCallback(IAsyncResult^ asyncResult)
    {
        UdpClient^ udpClient =
            ((UdpState)(asyncResult->AsyncState)).udpClient;
        IPEndPoint^ ipEndPoint =
            ((UdpState)(asyncResult->AsyncState)).ipEndPoint;

        array<Byte>^ receiveBytes =
            udpClient->EndReceive(asyncResult, ipEndPoint);
        String^ receiveString =
            Encoding::ASCII->GetString(receiveBytes);

        Console::WriteLine("Received: {0}", receiveString);
        isMessageReceived = true;
    }

    static void ReceiveMessages()
    {
        // Receive a message and write it to the console.
        IPEndPoint^ ipEndPoint = gcnew IPEndPoint(IPAddress::Any, listenPort);
        UdpClient^ udpClient = gcnew UdpClient(ipEndPoint);

        UdpState^ udpState = gcnew UdpState();
        udpState->ipEndPoint = ipEndPoint;
        udpState->udpClient = udpClient;

        Console::WriteLine("listening for messages");
        udpClient->BeginReceive(gcnew AsyncCallback(ReceiveCallback),
            udpState);

        // Do some work while we wait for a message. For this example,
        // we'll just sleep
        while (!isMessageReceived)
        {
            Thread::Sleep(100);
        }
    }
    //</snippet1>

    //<snippet2>
public:
    static bool isMessageSent;

    static void SendCallback(IAsyncResult^ asyncResult)
    {
        UdpClient^ udpClient = (UdpClient^)asyncResult->AsyncState;

        Console::WriteLine("number of bytes sent: {0}",
            udpClient->EndSend(asyncResult));
        isMessageSent = true;
    }
    //</snippet2>

    //<snippet3>
public:
    static void SendMessage1(String^ server, String^ message)
    {
        // create the udp socket
        UdpClient^ udpClient = gcnew UdpClient();

        udpClient->Connect(server, listenPort);
        array<Byte>^ sendBytes = Encoding::ASCII->GetBytes(message);

        // send the message
        // the destination is defined by the call to .Connect()
        udpClient->BeginSend(sendBytes, sendBytes->Length,
            gcnew AsyncCallback(SendCallback), udpClient);

        // Do some work while we wait for the send to complete. For
        // this example, we'll just sleep
        while (!isMessageSent)
        {
            Thread::Sleep(100);
        }
    }
    //</snippet3>

    //<snippet4>
public:
    static void SendMessage2(String^ server, String^ message)
    {
        // create the udp socket
        UdpClient^ udpClient = gcnew UdpClient();
        array<Byte>^ sendBytes = Encoding::ASCII->GetBytes(message);

        // resolve the server name
        IPHostEntry^ resolvedServer = Dns::GetHostEntry(server);

        IPEndPoint^ ipEndPoint =
            gcnew IPEndPoint(resolvedServer->AddressList[0], listenPort);

        // send the message
        // the destination is defined by the IPEndPoint
        udpClient->BeginSend(sendBytes, sendBytes->Length, ipEndPoint,
            gcnew AsyncCallback(SendCallback), udpClient);

        // Do some work while we wait for the send to complete. For
        // this example, we'll just sleep
        while (!isMessageSent)
        {
            Thread::Sleep(100);
        }
    }
    //</snippet4>

    //<snippet5>
public:
    static void SendMessage3(String^ server, String^ message)
    {
        // create the udp socket
        UdpClient^ udpClient = gcnew UdpClient();

        array<Byte>^ sendBytes = Encoding::ASCII->GetBytes(message);

        // send the message
        // the destination is defined by the server name and port
        udpClient->BeginSend(sendBytes, sendBytes->Length, server, listenPort,
            gcnew AsyncCallback(SendCallback), udpClient);

        // Do some work while we wait for the send to complete. For
        // this example, we'll just sleep
        while (!isMessageSent)
        {
            Thread::Sleep(100);
        }
    }
    //</snippet5>

};

int main(array<String^>^ args)
{
    // Parse arguments
    String^ server = "";
    String^ message = "This is a test!";
    bool isServer;
    int sendMethod = 1; // n called SendMessagen

    if (args->Length == 0)
    {
        server = "localhost";
        isServer = false;
    }
    else if (args->Length == 1)
    {
        if (args[0] == "s")
        {
            isServer = true;
        }
        else
        {
            isServer = false;
        }
    }
    else if (args->Length == 2)
    {
        if (args[0] == "s")
        {
            isServer = true;
        }
        else
        {
            isServer = false;
        }
        server = args[1];
    }
    else if (args->Length == 3)
    {
        if (args[0] == "s")
        {
            isServer = true;
        }
        else
        {
            isServer = false;
        }
        server = args[1];
        message = args[2];
    }
    else if (args->Length == 4)
    {
        if (args[0] == "s")
        {
            isServer = true;
        }
        else
        {
            isServer = false;
        }
        server = args[1];
        message = args[2];

        try
        {
            sendMethod = Convert::ToInt32(args[3]);
        }
        catch (System::ArgumentNullException^ ex)
        {
            Console::WriteLine(ex->Message);
        }
        catch (System::FormatException^ ex)
        {
            Console::WriteLine(ex->Message);
        }
        catch (System::OverflowException^ ex)
        {
            Console::WriteLine(ex->Message);
        }
    }
    else
    {
        Console::WriteLine(
            "Usage: asyncudp [s|c] [host name] [message] [send method]");
        return 0;
    }

    if (isServer)
    {
        UdpClientExample::ReceiveMessages();
    }
    else
    {
        switch (sendMethod)
        {
        case 1:
            UdpClientExample::SendMessage1(server, message);
            break;
        case 2:
            UdpClientExample::SendMessage2(server, message);
            break;
        case 3:
            UdpClientExample::SendMessage3(server, message);
            break;
        }
    }
}

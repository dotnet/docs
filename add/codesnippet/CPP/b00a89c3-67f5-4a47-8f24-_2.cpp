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
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
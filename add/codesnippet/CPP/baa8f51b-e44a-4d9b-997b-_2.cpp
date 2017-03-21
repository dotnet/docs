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
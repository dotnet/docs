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
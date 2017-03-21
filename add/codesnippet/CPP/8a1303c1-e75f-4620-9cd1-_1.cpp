public:
    static bool isMessageSent;

    static void SendCallback(IAsyncResult^ asyncResult)
    {
        UdpClient^ udpClient = (UdpClient^)asyncResult->AsyncState;

        Console::WriteLine("number of bytes sent: {0}",
            udpClient->EndSend(asyncResult));
        isMessageSent = true;
    }
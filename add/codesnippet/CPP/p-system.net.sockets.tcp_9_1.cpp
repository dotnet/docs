    public:
        static void GetSetExclusiveAddressUse(TcpListener^ listener)
        {
            // Set Exclusive Address Use for the underlying socket.
            listener->ExclusiveAddressUse = true;
            Console::WriteLine("ExclusiveAddressUse value is {0}",
                listener->ExclusiveAddressUse);
        }
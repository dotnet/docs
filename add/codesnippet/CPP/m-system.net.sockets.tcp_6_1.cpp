    public:
        static void DoStart(TcpListener^ listener, int backlog)
        {
            // Start listening for client connections with the
            // specified backlog.
            listener->Start(backlog);
            Console::WriteLine("Started listening");
        }
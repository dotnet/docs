        public static void DoStart(TcpListener t, int backlog)
        {
            // Start listening for client connections with the 
            // specified backlog.
            t.Start(backlog);
            Console.WriteLine("started listening");
        }
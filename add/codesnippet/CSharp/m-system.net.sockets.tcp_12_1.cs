        public static ManualResetEvent connectDone = 
            new ManualResetEvent(false);

        public static void ConnectCallback(IAsyncResult ar)
        {
            connectDone.Set();
            TcpClient t = (TcpClient)ar.AsyncState;
            t.EndConnect(ar);
        }
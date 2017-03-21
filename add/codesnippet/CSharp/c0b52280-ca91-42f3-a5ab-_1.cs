        public static ManualResetEvent allDone = 
            new ManualResetEvent(false);

        // handles the completion of the prior asynchronous 
        // connect call. the socket is passed via the objectState 
        // paramater of BeginConnect().
        public static void ConnectCallback1(IAsyncResult ar)
        {
            allDone.Set();
            Socket s = (Socket) ar.AsyncState;
            s.EndConnect(ar);
        }
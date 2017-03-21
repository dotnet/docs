    // Displays sending with a connected socket
    // using the overload that takes a buffer.
    public static int SendReceiveTest1(Socket server)
    {
        byte[] msg = Encoding.UTF8.GetBytes("This is a test");
        byte[] bytes = new byte[256];
        try 
        {
            // Blocks until send returns.
            int i = server.Send(msg);
            Console.WriteLine("Sent {0} bytes.", i);
            
            // Get reply from the server.
            i = server.Receive(bytes);
            Console.WriteLine(Encoding.UTF8.GetString(bytes));
        }
        catch (SocketException e)
        {
            Console.WriteLine("{0} Error code: {1}.", e.Message, e.ErrorCode);
            return (e.ErrorCode);
        }
        return 0;
    }
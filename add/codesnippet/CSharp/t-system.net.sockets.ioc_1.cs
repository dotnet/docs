        static void DisplayPendingByteCount(Socket s)
        {
            byte[] outValue = BitConverter.GetBytes(0);

            // Check how many bytes have been received.
            s.IOControl(IOControlCode.DataToRead, null, outValue);

            uint bytesAvailable = BitConverter.ToUInt32(outValue, 0);
            Console.Write("server has {0} bytes pending. ", 
                bytesAvailable);
            Console.WriteLine("Available property says {1}.",
                             s.Available);

            return;
        }
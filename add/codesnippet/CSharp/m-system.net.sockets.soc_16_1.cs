        // FIONREAD is also available as the "Available" property.
       public const int FIONREAD   = 0x4004667F;
       
       static void DisplayPendingByteCount(Socket s)
        {
            byte[] outValue = BitConverter.GetBytes(0);

            // Check how many bytes have been received.
            s.IOControl(FIONREAD, null, outValue);
            
            uint bytesAvailable = BitConverter.ToUInt32(outValue, 0);
            Console.WriteLine("server has {0} bytes pending. Available property says {1}.",
                bytesAvailable, s.Available);
            
            return;
        }
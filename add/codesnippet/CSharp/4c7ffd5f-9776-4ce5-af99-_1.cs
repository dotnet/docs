
            // Build the buffers for the receive.
            List<ArraySegment<byte>> recvBuffers = 
                                     new List<ArraySegment<byte>>(2);

            byte[] bigBuffer = new byte[1024];

            // Specify the first buffer segment (2 bytes, starting 
            // at the 4th element of bigBuffer)
            recvBuffers.Add(new ArraySegment<byte>
                                    (bigBuffer, 4, 2));

            // Specify the second buffer segment (500 bytes, starting
            // at the 20th element of bigBuffer)
            recvBuffers.Add(new ArraySegment<byte>
                                    (bigBuffer, 20, 500));

            int bytesReceived = mySocket.Receive(recvBuffers);

            Console.WriteLine("{0}", ASCII.GetString(bigBuffer));
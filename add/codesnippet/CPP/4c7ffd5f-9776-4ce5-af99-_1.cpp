
            // Build the buffers for the receive.
            List<ArraySegment<Byte> >^ receiveBuffers = 
                gcnew List<ArraySegment<Byte> >(2);
            
            array<Byte>^ bigBuffer = gcnew array<Byte>(1024);
            
            // Specify the first buffer segment (2 bytes, starting 
            // at the 4th element of bigBuffer)
            receiveBuffers->Add(ArraySegment<Byte>(bigBuffer, 4, 2));
            
            // Specify the second buffer segment (500 bytes, starting
            // at the 20th element of bigBuffer)
            receiveBuffers->Add(
                ArraySegment<Byte>(bigBuffer, 20, 500));
            
            tcpSocket->Receive(receiveBuffers);
            
            Console::WriteLine("{0}", 
                asciiEncoding->GetString(bigBuffer));
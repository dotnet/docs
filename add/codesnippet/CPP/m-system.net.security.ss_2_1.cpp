    private:
        static String^ ReadMessage(SslStream^ sslStream)
        {
              
            // Read the  message sent by the server.
            // The end of the message is signaled using the
            // "<EOF>" marker.
            array<Byte>^ buffer = gcnew array<Byte>(2048);
            StringBuilder^ messageData = gcnew StringBuilder;
            // Use Decoder class to convert from bytes to UTF8
            // in case a character spans two buffers.
            Encoding^ u8 = Encoding::UTF8;
            Decoder^ decoder = u8->GetDecoder();

            int bytes = -1;
            do
            {
                bytes = sslStream->Read(buffer, 0, buffer->Length);
                 
                array<__wchar_t>^ chars = gcnew array<__wchar_t>(
                    decoder->GetCharCount(buffer, 0, bytes));
                decoder->GetChars(buffer, 0, bytes, chars, 0);
                messageData->Append(chars);
                 
                // Check for EOF.
                if (messageData->ToString()->IndexOf("<EOF>") != -1)
                {
                    break;
                }
            }
            while (bytes != 0);

            return messageData->ToString();
        }
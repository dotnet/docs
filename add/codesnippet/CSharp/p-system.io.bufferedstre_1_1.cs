            if(bufStream.CanWrite)
            {
                SendData(netStream, bufStream);
            }
        // Receive data using the BufferedStream.
        Console.WriteLine("Receiving data using BufferedStream.");
        bytesReceived = 0;
        startTime = DateTime.Now;

        int numBytesToRead = receivedData.Length;

        while (numBytesToRead > 0)
        {
            // Read may return anything from 0 to numBytesToRead.
            int n = bufStream.Read(receivedData,0, receivedData.Length);
            // The end of the file is reached.
            if (n == 0)
                break;
            bytesReceived += n;
            numBytesToRead -= n;
        }

        bufferedTime = (DateTime.Now - startTime).TotalSeconds;
        Console.WriteLine("{0} bytes received in {1} seconds.\n",
            bytesReceived.ToString(),
            bufferedTime.ToString("F1"));
        // Send the data using the BufferedStream.
        Console.WriteLine("Sending data using BufferedStream.");
        startTime = DateTime.Now;
        for(int i = 0; i < numberOfLoops; i++)
        {
            bufStream.Write(dataToSend, 0, dataToSend.Length);
        }
        bufStream.Flush();
        bufferedTime = (DateTime.Now - startTime).TotalSeconds;
        Console.WriteLine("{0} bytes sent in {1} seconds.\n",
            numberOfLoops * dataToSend.Length,
            bufferedTime.ToString("F1"));
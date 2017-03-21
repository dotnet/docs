    static void Main()
    {
        // Create a synchronization object that gets 
        // signaled when verification is complete.
        ManualResetEvent manualEvent = new ManualResetEvent(false);

        // Create random data to write to the file.
        byte[] writeArray = new byte[100000];
        new Random().NextBytes(writeArray);

        FileStream fStream = 
            new FileStream("Test#@@#.dat", FileMode.Create, 
            FileAccess.ReadWrite, FileShare.None, 4096, true);

        // Check that the FileStream was opened asynchronously.
        Console.WriteLine("fStream was {0}opened asynchronously.",
            fStream.IsAsync ? "" : "not ");

        // Asynchronously write to the file.
        IAsyncResult asyncResult = fStream.BeginWrite(
            writeArray, 0, writeArray.Length, 
            new AsyncCallback(EndWriteCallback), 
            new State(fStream, writeArray, manualEvent));

        // Concurrently do other work and then wait 
        // for the data to be written and verified.
        manualEvent.WaitOne(5000, false);
    }
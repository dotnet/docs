// <Snippet1>
using System;
using System.IO;
using System.Threading;

class FStream
{
// <Snippet2>
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
// </Snippet2>

    // When BeginWrite is finished writing data to the file, the
    // EndWriteCallback method is called to end the asynchronous 
    // write operation and then read back and verify the data.
// <Snippet3>
    static void EndWriteCallback(IAsyncResult asyncResult)
    {
        State tempState = (State)asyncResult.AsyncState;
        FileStream fStream = tempState.FStream;
        fStream.EndWrite(asyncResult);

        // Asynchronously read back the written data.
        fStream.Position = 0;
        asyncResult = fStream.BeginRead(
            tempState.ReadArray, 0 , tempState.ReadArray.Length, 
            new AsyncCallback(EndReadCallback), tempState);

        // Concurrently do other work, such as 
        // logging the write operation.
    }
// </Snippet3>

    // When BeginRead is finished reading data from the file, the 
    // EndReadCallback method is called to end the asynchronous 
    // read operation and then verify the data.
// <Snippet4>
    static void EndReadCallback(IAsyncResult asyncResult)
    {
        State tempState = (State)asyncResult.AsyncState;
        int readCount = tempState.FStream.EndRead(asyncResult);

        int i = 0;
        while(i < readCount)
        {
            if(tempState.ReadArray[i] != tempState.WriteArray[i++])
            {
                Console.WriteLine("Error writing data.");
                tempState.FStream.Close();
                return;
            }
        }
        Console.WriteLine("The data was written to {0} and verified.",
            tempState.FStream.Name);
        tempState.FStream.Close();

        // Signal the main thread that the verification is finished.
        tempState.ManualEvent.Set();
    }
// </Snippet4>

    // Maintain state information to be passed to 
    // EndWriteCallback and EndReadCallback.
    class State
    {
        // fStream is used to read and write to the file.
        FileStream fStream;

        // writeArray stores data that is written to the file.
        byte[] writeArray;

        // readArray stores data that is read from the file.
        byte[] readArray;

        // manualEvent signals the main thread 
        // when verification is complete.
        ManualResetEvent manualEvent;

        public State(FileStream fStream, byte[] writeArray, 
            ManualResetEvent manualEvent)
        {
            this.fStream   = fStream;
            this.writeArray = writeArray;
            this.manualEvent = manualEvent;
            readArray = new byte[writeArray.Length];
        }

        public FileStream FStream
        { get{ return fStream; } }

        public byte[] WriteArray
        { get{ return writeArray; } }

        public byte[] ReadArray
        { get{ return readArray; } }

        public ManualResetEvent ManualEvent
        { get{ return manualEvent; } }
    }
}
// </Snippet1>
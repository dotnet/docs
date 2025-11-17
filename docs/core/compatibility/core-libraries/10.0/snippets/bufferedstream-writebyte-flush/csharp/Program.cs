using System;
using System.IO;

// <PreviousBehavior>
StreamWithFlush streamWithFlush = new();
BufferedStream bufferedStream = new(streamWithFlush, bufferSize: 4);

// Write 4 bytes to fill the buffer
bufferedStream.WriteByte(1);
bufferedStream.WriteByte(2);
bufferedStream.WriteByte(3);
bufferedStream.WriteByte(4); // In .NET 9 and earlier, this caused an implicit flush

class StreamWithFlush : MemoryStream
{
    public override void Flush()
    {
        Console.WriteLine("Flush was called.");

        base.Flush();
    }
}
// </PreviousBehavior>

class BeforeExample
{
    static void Example()
    {
        // <Before>
        BufferedStream bufferedStream = new(new MemoryStream(), bufferSize: 4);
        bufferedStream.WriteByte(1);
        bufferedStream.WriteByte(2);
        bufferedStream.WriteByte(3);
        bufferedStream.WriteByte(4); // Implicit flush occurred here in .NET 9 and earlier
        // </Before>
    }
}

class AfterExample
{
    static void Example()
    {
        // <After>
        BufferedStream bufferedStream = new(new MemoryStream(), bufferSize: 4);
        bufferedStream.WriteByte(1);
        bufferedStream.WriteByte(2);
        bufferedStream.WriteByte(3);
        bufferedStream.WriteByte(4);
        bufferedStream.Flush(); // Explicit flush
        // </After>
    }
}

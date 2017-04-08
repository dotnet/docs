// <Snippet1>
using System;
using System.IO;

class BinaryRW
{
    static void Main()
    {
        char[] invalidPathChars = Path.InvalidPathChars;
        MemoryStream memStream = new MemoryStream();
        BinaryWriter binWriter = new BinaryWriter(memStream);

        // Write to memory.
        binWriter.Write("Invalid file path characters are: ");
        binWriter.Write(
            Path.InvalidPathChars, 0, Path.InvalidPathChars.Length);

        // Create the reader using the same MemoryStream 
        // as used with the writer.
        BinaryReader binReader = new BinaryReader(memStream);

        // Set Position to the beginning of the stream.
        memStream.Position = 0;

        // Read the data from memory and write it to the console.
        Console.Write(binReader.ReadString());
        int arraySize = (int)(memStream.Length - memStream.Position);
        char[] memoryData = new char[arraySize];
        binReader.Read(memoryData, 0, arraySize);
        Console.WriteLine(memoryData);
    }
}
// </Snippet1>
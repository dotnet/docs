// <Snippet1>
using System;
using System.IO;

class BinaryRW
{
    static void Main()
    {
        int i = 0;
        char[] invalidPathChars = Path.InvalidPathChars;
        MemoryStream memStream = new MemoryStream();
        BinaryWriter binWriter = new BinaryWriter(memStream);

        // Write to memory.
        binWriter.Write("Invalid file path characters are: ");
        for(i = 0; i < invalidPathChars.Length; i++)
        {
            binWriter.Write(invalidPathChars[i]);
        }

        // Create the reader using the same MemoryStream 
        // as used with the writer.
        BinaryReader binReader = new BinaryReader(memStream);

        // Set Position to the beginning of the stream.
        memStream.Position = 0;

        // Read the data from memory and write it to the console.
        Console.Write(binReader.ReadString());
        char[] memoryData = 
            new char[memStream.Length - memStream.Position];
        for(i = 0; i < memoryData.Length; i++)
        {
            memoryData[i] = binReader.ReadChar();
        }
        Console.WriteLine(memoryData);
    }
}
// </Snippet1>
// <Snippet1>
using System;
using System.IO;

class BinaryRW
{
    static void Main()
    {
        const int arrayLength = 1000;

        // Create random data to write to the stream.
        byte[] dataArray = new byte[arrayLength];
        new Random().NextBytes(dataArray);

        BinaryWriter binWriter = new BinaryWriter(new MemoryStream());

        // Write the data to the stream.
        Console.WriteLine("Writing the data.");
        binWriter.Write(dataArray);

        // Create the reader using the stream from the writer.
        BinaryReader binReader = 
            new BinaryReader(binWriter.BaseStream);

        // Set Position to the beginning of the stream.
        binReader.BaseStream.Position = 0;

        // Read and verify the data.
        byte[] verifyArray = binReader.ReadBytes(arrayLength);
        if(verifyArray.Length != arrayLength)
        {
            Console.WriteLine("Error writing the data.");
            return;
        }
        for(int i = 0; i < arrayLength; i++)
        {
            if(verifyArray[i] != dataArray[i])
            {
                Console.WriteLine("Error writing the data.");
                return;
            }
        }
        Console.WriteLine("The data was written and verified.");
    }
}
// </Snippet1>
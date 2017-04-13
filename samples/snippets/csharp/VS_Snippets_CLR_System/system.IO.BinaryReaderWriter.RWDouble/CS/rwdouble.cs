// <Snippet1>
using System;
using System.IO;

class BinaryRW
{
    static void Main()
    {
        int i;
        const int arrayLength = 1000;

        // Create random data to write to the stream.
        Random randomGenerator = new Random();
        double[] dataArray = new double[arrayLength];
        for(i = 0; i < arrayLength; i++)
        {
            dataArray[i] = 100.1 * randomGenerator.NextDouble();
        }

        using(BinaryWriter binWriter = 
            new BinaryWriter(new MemoryStream()))
        {
            // Write the data to the stream.
            Console.WriteLine("Writing data to the stream.");
            for(i = 0; i < arrayLength; i++)
            {
                binWriter.Write(dataArray[i]);
            }

            // Create a reader using the stream from the writer.
            using(BinaryReader binReader = 
                new BinaryReader(binWriter.BaseStream))
            {
                try
                {
                    // Return to the beginning of the stream.
                    binReader.BaseStream.Position = 0;

                    // Read and verify the data.
                    Console.WriteLine("Verifying the written data.");
                    for(i = 0; i < arrayLength; i++)
                    {
                        if(binReader.ReadDouble() != dataArray[i])
                        {
                            Console.WriteLine("Error writing data.");
                            break;
                        }
                    }
                    Console.WriteLine("The data was written " +
                        "and verified.");
                }
                catch(EndOfStreamException e)
                {
                    Console.WriteLine("Error writing data: {0}.",
                        e.GetType().Name);
                }
            }
        }
    }
}
// </Snippet1>
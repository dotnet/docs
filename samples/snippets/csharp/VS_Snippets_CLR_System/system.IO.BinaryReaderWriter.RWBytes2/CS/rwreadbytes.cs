// <Snippet1>
using System;
using System.IO;

namespace BinaryRW
{
    class Program
    {
        static void Main(string[] args)
        {
            const int arrayLength = 1000;
            byte[] dataArray = new byte[arrayLength];
            byte[] verifyArray = new byte[arrayLength];

            new Random().NextBytes(dataArray);

            using (BinaryWriter binWriter = new BinaryWriter(new MemoryStream()))
            {
                Console.WriteLine("Writing the data.");
                binWriter.Write(dataArray, 0, arrayLength);

                using (BinaryReader binReader = new BinaryReader(binWriter.BaseStream))
                {
                    binReader.BaseStream.Position = 0;
                    
                    if (binReader.Read(verifyArray, 0, arrayLength) != arrayLength)
                    {
                        Console.WriteLine("Error writing the data.");
                        return;
                    }
                }
            }

            for (int i = 0; i < arrayLength; i++)
            {
                if (verifyArray[i] != dataArray[i])
                {
                    Console.WriteLine("Error writing the data.");
                    return;
                }
            }

            Console.WriteLine("The data was written and verified.");
        }
    }
}
// </Snippet1>
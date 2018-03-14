// <Snippet1>
using System;
using System.IO;

class Test
{

public static void Main()
{
    // Specify a file to read from and to create.
    string pathSource = @"c:\tests\source.txt";
    string pathNew = @"c:\tests\newfile.txt";

    try
    {

        using (FileStream fsSource = new FileStream(pathSource,
            FileMode.Open, FileAccess.Read))
        {

            // Read the source file into a byte array.
            byte[] bytes = new byte[fsSource.Length];
            int numBytesToRead = (int)fsSource.Length;
            int numBytesRead = 0;
            while (numBytesToRead > 0)
            {
                // Read may return anything from 0 to numBytesToRead.
                int n = fsSource.Read(bytes, numBytesRead, numBytesToRead);

                // Break when the end of the file is reached.
                if (n == 0)
                    break;

                numBytesRead += n;
                numBytesToRead -= n;
            }
             numBytesToRead = bytes.Length;

            // Write the byte array to the other FileStream.
            using (FileStream fsNew = new FileStream(pathNew,
                FileMode.Create, FileAccess.Write))
            {
                fsNew.Write(bytes, 0, numBytesToRead);
            }
        }
    }
    catch (FileNotFoundException ioEx)
    {
        Console.WriteLine(ioEx.Message);
    }
}
}
// </Snippet1>
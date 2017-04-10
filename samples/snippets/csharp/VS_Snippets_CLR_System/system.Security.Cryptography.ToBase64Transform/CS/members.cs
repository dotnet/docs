// This sample demonstrates how to use each member of the ToBase64Transform
// class. The file named members.cs is read in and written out as a 
// transformed file named members.enc.
//<Snippet1>
using System;
using System.IO;
using System.Security.Cryptography;

class Members
{
    [STAThread]
    static void Main(string[] args)
    {
        string appPath = (System.IO.Directory.GetCurrentDirectory() + "\\");

        // Insert your file names into this method call.
        EncodeFromFile(appPath + "members.cs", appPath + "members.enc");

        Console.WriteLine("This sample completed successfully; " +
            "press Enter to exit.");
        Console.ReadLine();
    }

    // Read in the specified source file and write out an encoded target file.
    private static void EncodeFromFile(string sourceFile, string targetFile) 
    {
        // Verify members.cs exists at the specified directory.
        if (!File.Exists(sourceFile))
        {
            Console.Write("Unable to locate source file located at ");
            Console.WriteLine(sourceFile + ".");
            Console.Write("Please correct the path and run the ");
            Console.WriteLine("sample again.");
            return;
        }

        // Retrieve the input and output file streams.
        FileStream inputFileStream = 
            new FileStream(sourceFile, FileMode.Open, FileAccess.Read);
        FileStream outputFileStream = 
            new FileStream(targetFile, FileMode.Create, FileAccess.Write);

        // Create a new ToBase64Transform object to convert to base 64.
        //<Snippet2>
        ToBase64Transform base64Transform = new ToBase64Transform();
        //</Snippet2>

        // Create a new byte array with the size of the output block size.
        //<Snippet6>
        byte[] outputBytes = new byte[base64Transform.OutputBlockSize];
        //</Snippet6>

        // Retrieve the file contents into a byte array.
        byte[] inputBytes = new byte[inputFileStream.Length];
        inputFileStream.Read(inputBytes, 0, inputBytes.Length);

        // Verify that multiple blocks can not be transformed.
        //<Snippet4>
        if (!base64Transform.CanTransformMultipleBlocks)
        //</Snippet4>
        {
            // Initializie the offset size.
            int inputOffset = 0;

            // Iterate through inputBytes transforming by blockSize.
            //<Snippet8>
            //<Snippet5>
            int inputBlockSize = base64Transform.InputBlockSize;
            //</Snippet5>

            while(inputBytes.Length - inputOffset > inputBlockSize)
            {
                base64Transform.TransformBlock(
                    inputBytes,
                    inputOffset,
                    inputBytes.Length - inputOffset,
                    outputBytes,
                    0);

                inputOffset += base64Transform.InputBlockSize;
                outputFileStream.Write(
                    outputBytes, 
                    0, 
                    base64Transform.OutputBlockSize);
            }
            //</Snippet8>

            // Transform the final block of data.
            //<Snippet9>
            outputBytes = base64Transform.TransformFinalBlock(
                inputBytes,
                inputOffset,
                inputBytes.Length - inputOffset);
            //</Snippet9>

            outputFileStream.Write(outputBytes, 0, outputBytes.Length);
            Console.WriteLine("Created encoded file at " + targetFile);
        }

        // Determine if the current transform can be reused.
        //<Snippet3>
        if (! base64Transform.CanReuseTransform)
        //</Snippet3>
        {
            // Free up any used resources.
            //<Snippet7>
            base64Transform.Clear();
            //</Snippet7>
        }

        // Close file streams.
        inputFileStream.Close();
        outputFileStream.Close();
    }
}
//
// This sample produces the following output:
//
// Created encoded file at C:\ConsoleApplication1\\membersvcs.enc
// This sample completed successfully; press Enter to exit.
//</Snippet1>
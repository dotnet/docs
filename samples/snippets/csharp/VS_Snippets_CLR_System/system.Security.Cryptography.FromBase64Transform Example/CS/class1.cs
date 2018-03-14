//<snippet1>

using System;
using System.IO;
using System.Security.Cryptography;

class Members
{
    [STAThread]
    static void Main(string[] args)
    {
        string appPath = (System.IO.Directory.GetCurrentDirectory() );
        appPath = appPath + "..\\\\..\\\\..\\";
        // Insert your file names into this method call.
        EncodeFromFile(appPath + "program.cs", appPath + "code.enc");
        DecodeFromFile(appPath + "code.enc", appPath + "roundtrip.txt");

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
        using (FileStream inputFileStream =
            new FileStream(sourceFile, FileMode.Open, FileAccess.Read))
        {
            using (FileStream outputFileStream =
                new FileStream(targetFile, FileMode.Create, FileAccess.Write))
            {

                // Create a new ToBase64Transform object to convert to base 64.
                ToBase64Transform base64Transform = new ToBase64Transform();

                // Create a new byte array with the size of the output block size.
                byte[] outputBytes = new byte[base64Transform.OutputBlockSize];

                // Retrieve the file contents into a byte array.
                byte[] inputBytes = new byte[inputFileStream.Length];
                inputFileStream.Read(inputBytes, 0, inputBytes.Length);

                // Verify that multiple blocks can not be transformed.
                if (!base64Transform.CanTransformMultipleBlocks)
                {
                    // Initializie the offset size.
                    int inputOffset = 0;

                    // Iterate through inputBytes transforming by blockSize.
                    int inputBlockSize = base64Transform.InputBlockSize;

                    while (inputBytes.Length - inputOffset > inputBlockSize)
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

                    // Transform the final block of data.
                    outputBytes = base64Transform.TransformFinalBlock(
                        inputBytes,
                        inputOffset,
                        inputBytes.Length - inputOffset);

                    outputFileStream.Write(outputBytes, 0, outputBytes.Length);
                    Console.WriteLine("Created encoded file at " + targetFile);
                }

                // Determine if the current transform can be reused.
                if (!base64Transform.CanReuseTransform)
                {
                    // Free up any used resources.
                    base64Transform.Clear();
                }
            }
        }

    }

        public static void DecodeFromFile(string inFileName, string outFileName)
        {
            using (FromBase64Transform myTransform = new FromBase64Transform(FromBase64TransformMode.IgnoreWhiteSpaces))
            {

                byte[] myOutputBytes = new byte[myTransform.OutputBlockSize];

                //Open the input and output files.
                using (FileStream myInputFile = new FileStream(inFileName, FileMode.Open, FileAccess.Read))
                {
                    using (FileStream myOutputFile = new FileStream(outFileName, FileMode.Create, FileAccess.Write))
                    {

                        //Retrieve the file contents into a byte array. 
                        byte[] myInputBytes = new byte[myInputFile.Length];
                        myInputFile.Read(myInputBytes, 0, myInputBytes.Length);

                        //Transform the data in chunks the size of InputBlockSize. 
                        int i = 0;
                        while (myInputBytes.Length - i > 4/*myTransform.InputBlockSize*/)
                        {
                            int bytesWritten = myTransform.TransformBlock(myInputBytes, i, 4/*myTransform.InputBlockSize*/, myOutputBytes, 0);
                            i += 4/*myTransform.InputBlockSize*/;
                            myOutputFile.Write(myOutputBytes, 0, bytesWritten);
                        }

                        //Transform the final block of data.
                        myOutputBytes = myTransform.TransformFinalBlock(myInputBytes, i, myInputBytes.Length - i);
                        myOutputFile.Write(myOutputBytes, 0, myOutputBytes.Length);

                        //Free up any used resources.
                        myTransform.Clear();
                    }
                }
            }

        }
}

//</snippet1>

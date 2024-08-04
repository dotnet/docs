
//<TestCode>
// Read the contents of data.txt, encrypt it, and write it to shifted.txt
WriteShiftedFile();

// Read the contents of shifted.txt, decrypt it, and write it to unshifted.txt
ReadShiftedFile();

// Check if the decrypted file is valid
Console.WriteLine(IsShiftedFileValid()
                    ? "Decrypted file is valid"     // True
                    : "Decrypted file is invalid"   // False
                 );

// Output:
//   Decrypted file is valid
//</TestCode>

//<WriteShiftedFile>
void WriteShiftedFile()
{
    // Create the base streams for the input and output files
    using FileStream inputBaseStream = File.OpenRead("data.txt");
    using CipherStream encryptStream = CipherStream.CreateForRead(inputBaseStream);
    using FileStream outputBaseStream = File.Open("shifted.txt", FileMode.Create, FileAccess.Write);

    int intValue;

    // Read byte from inputBaseStream through the encryptStream (normal bytes into shifted bytes)
    while ((intValue = encryptStream.ReadByte()) != -1)
    {
        outputBaseStream.WriteByte((byte)intValue);
    }

    // Process is:
    //  (inputBaseStream -> encryptStream) -> outputBaseStream
}
//</WriteShiftedFile>

//<ReadShiftedFile>
void ReadShiftedFile()
{
    int intValue;

    // Create the base streams for the input and output files
    using FileStream inputBaseStream = File.OpenRead("shifted.txt");
    using FileStream outputBaseStream = File.Open("unshifted.txt", FileMode.Create, FileAccess.Write);
    using CipherStream unencryptStream = CipherStream.CreateForWrite(outputBaseStream);

    // Read byte from inputBaseStream through the encryptStream (shifted bytes into normal bytes)
    while ((intValue = inputBaseStream.ReadByte()) != -1)
    {
        unencryptStream.WriteByte((byte)intValue);
    }

    // Process is:
    //  inputBaseStream -> (encryptStream -> outputBaseStream)
}
//</ReadShiftedFile>

//<ValidateFile>
bool IsShiftedFileValid()
{
    // Read the shifted file
    string originalText = File.ReadAllText("data.txt");

    // Read the shifted file
    string shiftedText = File.ReadAllText("unshifted.txt");

    // Check if the decrypted file is valid
    return shiftedText == originalText;
}
//</ValidateFile>

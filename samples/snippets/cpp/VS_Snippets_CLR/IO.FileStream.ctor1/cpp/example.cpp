//<SNIPPET1>
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Text;
using namespace System::Security::AccessControl;

int main()
{
    try
    {
        // Create a file and write data to it.

        // Create an array of bytes.
        array<Byte>^ messageByte =
            Encoding::ASCII->GetBytes("Here is some data.");

        // Create a file using the FileStream class.
        FileStream^ fWrite = gcnew FileStream("test.txt", FileMode::Create,
            FileAccess::ReadWrite, FileShare::None, 8, FileOptions::None);

        // Write the number of bytes to the file.
        fWrite->WriteByte((Byte)messageByte->Length);

        // Write the bytes to the file.
        fWrite->Write(messageByte, 0, messageByte->Length);

        // Close the stream.
        fWrite->Close();


        // Open a file and read the number of bytes.

        FileStream^ fRead = gcnew FileStream("test.txt", 
            FileMode::Open);

        // The first byte is the string length.
        int length = (int)fRead->ReadByte();

        // Create a new byte array for the data.
        array<Byte>^ readBytes = gcnew array<Byte>(length);

        // Read the data from the file.
        fRead->Read(readBytes, 0, readBytes->Length);

        // Close the stream.
        fRead->Close();

        // Display the data.
        Console::WriteLine(Encoding::ASCII->GetString(readBytes));

        Console::WriteLine("Done writing and reading data.");
    }
    catch (IOException^ ex)
    {
        Console::WriteLine(ex->Message);
    }
}
//</SNIPPET1>
//<SNIPPET1>
using namespace System;
using namespace System::IO;
using namespace System::Text;
using namespace System::Security::AccessControl;
using namespace System::Security::Principal;

int main()
{
    try
    {
        // Create a file and write data to it.

        // Create an array of bytes.
        array<Byte>^ messageByte =
            Encoding::ASCII->GetBytes("Here is some data.");

        // Specify an access control list (ACL)
        FileSecurity^ fs = gcnew FileSecurity();

        fs->AddAccessRule(
            gcnew FileSystemAccessRule("MYDOMAIN\\MyAccount",
            FileSystemRights::Modify, AccessControlType::Allow));

        // Create a file using the FileStream class.
        FileStream^ fWrite = gcnew FileStream("test.txt",
            FileMode::Create, FileSystemRights::Modify,
            FileShare::None, 8, FileOptions::None, fs);

        // Write the number of bytes to the file.
        fWrite->WriteByte((Byte)messageByte->Length);

        // Write the bytes to the file.
        fWrite->Write(messageByte, 0, messageByte->Length);

        // Close the stream.
        fWrite->Close();

        // Open a file and read the number of bytes.

        FileStream^ fRead = 
            gcnew FileStream("test.txt", FileMode::Open);

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

    catch (IdentityNotMappedException^)
    {
        Console::WriteLine("You need to use your own credentials " +
            " 'MYDOMAIN\\MyAccount'.");
    }

    catch (IOException^ ex)
    {
        Console::WriteLine(ex->Message);
    }
}

//</SNIPPET1>

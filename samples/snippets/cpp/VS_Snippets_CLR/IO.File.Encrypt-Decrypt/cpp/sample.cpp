//<SNIPPET1>
using namespace System;
using namespace System::IO;

int main()
{
    String^ fileName = "test.xml";
    if (!File::Exists(fileName))
    {
        Console::WriteLine("The file " + fileName
            + " does not exist.");
        return 0;
    }
    try
    {
        Console::WriteLine("Encrypt " + fileName);

        // Encrypt the file.
        File::Encrypt(fileName);

        Console::WriteLine("Decrypt " + fileName);

        // Decrypt the file.
        File::Decrypt(fileName);

        Console::WriteLine("Done");
    }
    catch (IOException^ ex)
    {
        Console::WriteLine("There was an IO problem.");
        Console::WriteLine(ex->Message);
    }
    catch (PlatformNotSupportedException^)
    {
        Console::WriteLine("Encryption is not supported on " +
            "this system.");
    }
    catch (NotSupportedException^)
    {
        Console::WriteLine("Encryption is not supported on " +
            "this system.");
    }
    catch (UnauthorizedAccessException^)
    {
        Console::WriteLine("The operation could not be "
            + "carried out.");
    }
}
//</SNIPPET1>

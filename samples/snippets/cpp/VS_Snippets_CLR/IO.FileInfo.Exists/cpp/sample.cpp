using namespace System;
using namespace System::IO;

//<SNIPPET1>
array<Byte>^ Openfile(String^ fileName)
{
    // Check the fileName argument.
    if (fileName == nullptr || fileName->Length == 0)
    {
        throw gcnew ArgumentNullException("fileName");
    }

    // Check to see if the file exists.
    FileInfo^ fInfo = gcnew FileInfo(fileName);

    // You can throw a personalized exception if
    // the file does not exist.
    if (!fInfo->Exists)
    {
        throw gcnew FileNotFoundException("The file was not found.",
            fileName);
    }

    try
    {
        // Open the file.
        FileStream^ fStream = gcnew FileStream(fileName, FileMode::Open);

        // Create a buffer.
        array<Byte>^ buffer = gcnew array<Byte>(fStream->Length);

        // Read the file contents to the buffer.
        fStream->Read(buffer, 0, (int)fStream->Length);

        // return the buffer.
        return buffer;
    }
    catch (IOException^ ex)
    {
        Console::WriteLine(ex->Message);
        return nullptr;
    }
}
//</SNIPPET1>

int main()
{

};

//<snippet21>
using namespace System;
using namespace System::IO;

public ref class ReadBuf
{
private:
    static String^ FILE_NAME = "MyFile.txt";

public:
    static void Main()
    {
        if (!File::Exists(FILE_NAME))
        {
            Console::WriteLine("{0} does not exist.", FILE_NAME);
            return;
        }
        FileStream^ f = gcnew FileStream(FILE_NAME, FileMode::Open,
            FileAccess::Read, FileShare::Read);
        // Create an instance of BinaryReader that can
        // read bytes from the FileStream.
        BinaryReader^ br = gcnew BinaryReader(f);
        Byte input;
        // While not at the end of the file, read lines from the file.
        while (br->PeekChar() >-1 )
        {
            input = br->ReadByte();
            Console::WriteLine(input);
        }
        br->Close();
    }
};

int main()
{
    ReadBuf::Main();
}
//</snippet21>

//<snippet7>
using namespace System;
using namespace System::IO;

ref class MyStream
{
private:
    static String^ FILE_NAME = "Test.data";

public:
    static void Main()
    {
        // Create the new, empty data file.
        if (File::Exists(FILE_NAME))
        {
            Console::WriteLine("{0} already exists!", FILE_NAME);
            return;
        }
        FileStream^ fs = gcnew FileStream(FILE_NAME, FileMode::CreateNew);
        // Create the writer for data.
        BinaryWriter^ w = gcnew BinaryWriter(fs);
        // Write data to Test.data.
        for (int i = 0; i < 11; i++)
        {
            w->Write(i);
        }
        w->Close();
        fs->Close();
        // Create the reader for data.
        fs = gcnew FileStream(FILE_NAME, FileMode::Open, FileAccess::Read);
        BinaryReader^ r = gcnew BinaryReader(fs);
        // Read data from Test.data.
        for (int i = 0; i < 11; i++)
        {
            Console::WriteLine(r->ReadInt32());
        }
        fs->Close();
    }
};

int main()
{
    MyStream::Main();
}
//</snippet7>

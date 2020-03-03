// <Snippet1>
using namespace System;
using namespace System::IO;
using namespace System::Text;

public ref class OpenTextTest
{
public:
    static void Main()
    {
        String^ path = "c:\\MyTest.txt";

        FileInfo^ fi = gcnew FileInfo(path);

        // Check for existing file
        if (!fi->Exists)
        {
            // Create the file.
            FileStream^ fs = fi->Create();
            array<Byte>^ info =
                (gcnew UTF8Encoding(true))->GetBytes("This is some text in the file.");

            // Add some information to the file.
            fs->Write(info, 0, info->Length);
            fs->Close();
        }

        // Open the stream and read it back.
        StreamReader^ sr = fi->OpenText();
        String^ s = "";
        while ((s = sr->ReadLine()) != nullptr)
        {
            Console::WriteLine(s);
        }
    }
};

int main()
{
    OpenTextTest::Main();
}
//This code produces output similar to the following; 
//results may vary based on the computer/file structure/etc.:
//
//This is some text in the file.
//
// </Snippet1>

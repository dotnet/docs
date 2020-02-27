//<snippet20>
using namespace System;
using namespace System::IO;

public ref class CompBuf
{
private:
    static String^ FILE_NAME = "MyFile.txt";

public:
    static void Main()
    {
        if (!File::Exists(FILE_NAME))
        {
            Console::WriteLine("{0} does not exist!", FILE_NAME);
            return;
        }
        FileStream^ fsIn = gcnew FileStream(FILE_NAME, FileMode::Open,
            FileAccess::Read, FileShare::Read);
        // Create an instance of StreamReader that can read
        // characters from the FileStream.
        StreamReader^ sr = gcnew StreamReader(fsIn);
        String^ input;

        // While not at the end of the file, read lines from the file.
        while (sr->Peek() > -1)
        {
            input = sr->ReadLine();
            Console::WriteLine(input);
        }
        sr->Close();
    }
};

int main()
{
    CompBuf::Main();
}
//</snippet20>

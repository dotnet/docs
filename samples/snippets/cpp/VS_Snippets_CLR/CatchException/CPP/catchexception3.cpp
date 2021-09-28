//<snippet4>
using namespace System;
using namespace System::IO;

public ref class ProcessFile
{
public:
    static void Main()
    {
        try
        {
            StreamReader^ sr = File::OpenText("data.txt");
            Console::WriteLine("The first line of this file is {0}", sr->ReadLine());
        }
        //<snippet5>
        catch (FileNotFoundException^ e)
        {
            Console::WriteLine("[Data File Missing] {0}", e);
        }
        //</snippet5>
        catch (Exception^ e)
        {
            Console::WriteLine("An error occurred: '{0}'", e);
        }
    }
};

int main()
{
    ProcessFile::Main();
}
//</snippet4>

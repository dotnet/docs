using namespace System;
using namespace System::Collections::Generic;
//using namespace System::Threading;

public ref class Example
{
public:
    static void Main()
    {
        // Create a new dictionary of strings, with string keys.
        //
        Dictionary<String^, String^>^ myDictionary =
            gcnew Dictionary<String^, String^>();

        // Add some elements to the dictionary. There are no
        // duplicate keys, but some of the values are duplicates.
        myDictionary->Add("txt", "notepad.exe");
        myDictionary->Add("bmp", "paint.exe");
        myDictionary->Add("dib", "paint.exe");
        myDictionary->Add("rtf", "wordpad.exe");

        //<Snippet11>
        for each(KeyValuePair<String^, String^> kvp in myDictionary)
        {
            Console::WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
        }
        //</Snippet11>
    }
};

int main()
{
    Example::Main();
}


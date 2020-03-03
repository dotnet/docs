#using <System.dll>

using namespace System;
using namespace System::Collections;
using namespace System::Collections::Specialized;

public ref class OrderedDictionarySample
{
public:
    static void Main()
    {
        OrderedDictionary^ myOrderedDictionary = gcnew OrderedDictionary();
        // <Snippet06>
        for each (DictionaryEntry de in myOrderedDictionary)
        {
            //...
        }
        // </Snippet06>
    }
};

int main()
{
    OrderedDictionarySample::Main();
}


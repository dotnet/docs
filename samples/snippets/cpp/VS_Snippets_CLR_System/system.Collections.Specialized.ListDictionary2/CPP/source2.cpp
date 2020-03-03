#using <System.dll>

using namespace System;
using namespace System::Collections;
using namespace System::Collections::Specialized;
using namespace System::Threading;

public ref class SamplesListDictionary
{
public:
    static void Main()
    {
        // <Snippet2>
        ListDictionary^ myCollection = gcnew ListDictionary();
        bool lockTaken = false;
        try
        {
            Monitor::Enter(myCollection->SyncRoot, lockTaken);
            for each (Object^ item in myCollection)
            {
                // Insert your code here.
            }
        }
        finally
        {
            if (lockTaken)
            {
                Monitor::Exit(myCollection->SyncRoot);
            }
        }
        // </Snippet2>
    }

    static void Dummy()
    {
        ListDictionary^ myListDictionary = gcnew ListDictionary();
        // <Snippet3>
        for each (DictionaryEntry de in myListDictionary)
        {
            //...
        }
        // </Snippet3>
    }
};

int main()
{
    SamplesListDictionary::Main();
}


#using <System.dll>

using namespace System;
using namespace System::Collections;
using namespace System::Collections::Specialized;
using namespace System::Threading;

public ref class HybridDictSample
{
public:
    static void Main()
    {
        // Creates and initializes a new HybridDictionary.
        HybridDictionary^ myHybridDictionary = gcnew HybridDictionary();

        // <snippet2>
        for each (DictionaryEntry^ de in myHybridDictionary)
        {
            //...
        }
        // </snippet2>

        // <snippet3>
        HybridDictionary^ myCollection = gcnew HybridDictionary();
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
        // </snippet3>
    }
};

int main()
{
    HybridDictSample::Main();
}
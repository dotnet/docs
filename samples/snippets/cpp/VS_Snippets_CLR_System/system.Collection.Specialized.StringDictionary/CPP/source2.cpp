#using <System.dll>

using namespace System;
using namespace System::Collections;
using namespace System::Collections::Specialized;
using namespace System::Threading;

public ref class SamplesStringDictionary
{
public:
    static void Main()
    {
        // <Snippet2>
        StringDictionary^ myCollection = gcnew StringDictionary();
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
};

int main()
{
    SamplesStringDictionary::Main();
}


#using <System.dll>

using namespace System;
using namespace System::Collections;
using namespace System::Collections::Specialized;
using namespace System::Threading;

public ref class SamplesStringCollection
{
public:
    static void Main()
    {
        // <Snippet2>
        StringCollection^ myCollection = gcnew StringCollection();
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
    SamplesStringCollection::Main();
}




#using <system.dll>

using namespace System;
using namespace System::Collections;
using namespace System::Threading;

public ref class SamplesHashtable
{
public:
    static void Main()
    {
        // <Snippet2>
        Hashtable^ myCollection = gcnew Hashtable();
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

void main()
{
    SamplesHashtable::Main();
}

using namespace System;
using namespace System::Collections;
using namespace System::Threading;

public ref class Remarks
{
public:
    static void Main()
    {
        ArrayList^ someCollection = gcnew ArrayList(5);
        // <Snippet1>
        ICollection^ myCollection = someCollection;
        bool lockTaken = false;
        try
        {
            Monitor::Enter(myCollection->SyncRoot, lockTaken);
            for each (Object^ item in myCollection);
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
        // </Snippet1>
    }

    static void Dummy()
    {
        ArrayList^ someCollection = gcnew ArrayList(5);
        // <Snippet2>
        ICollection^ myCollection = someCollection;
        bool lockTaken = false;
        try
        {
            Monitor::Enter(myCollection->SyncRoot, lockTaken);
            // Some operation on the collection, which is now thread safe.
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
    Remarks::Main();
}



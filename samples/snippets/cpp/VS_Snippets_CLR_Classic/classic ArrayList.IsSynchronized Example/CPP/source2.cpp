using namespace System;
using namespace System::Collections;
using namespace System::Threading;

public ref class SamplesArrayList
{
public:
    static void Main()
    {
        // <Snippet2>
        ArrayList^ myCollection = gcnew ArrayList();
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
        // </Snippet2>
    }
};

int main()
{
    SamplesArrayList::Main();
}
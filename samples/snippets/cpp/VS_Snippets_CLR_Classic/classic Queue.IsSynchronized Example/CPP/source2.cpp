using namespace System;
using namespace System::Collections;
using namespace System::Threading;

public ref class SamplesQueue
{
public:
    static void Main()
    {
        // <Snippet2>
        Queue^ myCollection = gcnew Queue();
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
    SamplesQueue::Main();
}
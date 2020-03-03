using namespace System;
using namespace System::Collections;
using namespace System::Threading;

public ref class SamplesSortedList
{
public:
    static void Main()
    {
        // <Snippet2>
        SortedList^ myCollection = gcnew SortedList();
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
    SamplesSortedList::Main();
}
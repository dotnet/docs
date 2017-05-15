using namespace System;
using namespace System::Collections;
using namespace System::Threading;

public ref class SamplesLocker
{
public:
    static void Main()
    {
        // <Snippet2>
        BitArray^ myCollection = gcnew BitArray(64, true);
        bool lockTaken = false;
        Monitor::Enter(myCollection->SyncRoot, lockTaken);
        {
            for each (Object^ item in myCollection)
            {
                // Insert your code here.
            }
        }
        Monitor::Exit(myCollection->SyncRoot);
        // </Snippet2>
    }
};

int main()
{
    SamplesLocker::Main();
}



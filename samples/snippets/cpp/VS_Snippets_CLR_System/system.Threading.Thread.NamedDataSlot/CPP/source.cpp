// <Snippet1>
using namespace System;
using namespace System::Threading;

ref class Slot
{
private:
    static Random^ randomGenerator = gcnew Random();

public:
    static void SlotTest()
    {
        // Set random data in each thread's data slot.
        int slotData = randomGenerator->Next(1, 200);
        int threadId = Thread::CurrentThread->ManagedThreadId;

        Thread::SetData(
            Thread::GetNamedDataSlot("Random"),
            slotData);

        // Show what was saved in the thread's data slot.
        Console::WriteLine("Data stored in thread_{0}'s data slot: {1,3}",
            threadId, slotData);

        // Allow other threads time to execute SetData to show
        // that a thread's data slot is unique to itself.
        Thread::Sleep(1000);

        int newSlotData =
            (int)Thread::GetData(Thread::GetNamedDataSlot("Random"));

        if (newSlotData == slotData)
        {
            Console::WriteLine("Data in thread_{0}'s data slot is still: {1,3}",
                threadId, newSlotData);
        }
        else
        {
            Console::WriteLine("Data in thread_{0}'s data slot changed to: {1,3}",
                threadId, newSlotData);
        }
    }
};

ref class Test
{
public:
    static void Main()
    {
        array<Thread^>^ newThreads = gcnew array<Thread^>(4);
        int i;
        for (i = 0; i < newThreads->Length; i++)
        {
            newThreads[i] =
                gcnew Thread(gcnew ThreadStart(&Slot::SlotTest));
            newThreads[i]->Start();
        }
        Thread::Sleep(2000);
        for (i = 0; i < newThreads->Length; i++)
        {
            newThreads[i]->Join();
            Console::WriteLine("Thread_{0} finished.",
                newThreads[i]->ManagedThreadId);
        }
    }
};

int main()
{
    Test::Main();
}
// </Snippet1>
// <snippet0>

#using <System.dll>
#using <System.Messaging.dll>

using namespace System;
using namespace System::Messaging;

// Create a new queue.
static void CreateQueue(String^ queuePath, bool transactional)
{
    if (!MessageQueue::Exists(queuePath))
    {
        MessageQueue^ queue = MessageQueue::Create(queuePath, transactional);
        queue->Close();
    }
    else
    {
        Console::WriteLine("{0} already exists.", queuePath);
    }
}

static void UseQueue()
{
    // <snippet1>
    // Connect to a queue on the local computer, grant exclusive read
    // access to the first application that accesses the queue, and
    // enable connection caching.
    MessageQueue^ queue = gcnew MessageQueue(".\\exampleQueue", true, true);

    queue->Close();
    // </snippet1>
}

int main()
{
    // Create a nontransactional queue on the local computer.
    CreateQueue(".\\exampleQueue", false);

    UseQueue();
}

// </snippet0>

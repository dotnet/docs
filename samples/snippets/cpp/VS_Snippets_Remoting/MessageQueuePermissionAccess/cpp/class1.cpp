// <snippet0>

#using <System.dll>
#using <System.Messaging.dll>

using namespace System;
using namespace System::Messaging;

// Creates a new queue.
void CreateQueue(String^ queuePath, bool transactional)
{
    if (!MessageQueue::Exists(queuePath))
    {
        MessageQueue^ queue = MessageQueue::Create(queuePath, transactional);
        queue->Close();       
    }
    else
    {
        Console::WriteLine("{0} already exists.",queuePath);
    }
}

// Demonstrates the use of MessageQueuePermissionAccess
void CreatePermission()
{
    // <snippet1>
    // Connect to a queue on the local computer.
    MessageQueue^ queue = gcnew MessageQueue(".\\exampleQueue");

    // Create a new instance of MessageQueuePermission.
    MessageQueuePermission^ permission = gcnew MessageQueuePermission(
        MessageQueuePermissionAccess::Receive, queue->MachineName,
        queue->Label, queue->Category.ToString());

    queue->Close();
    // </snippet1>
}

int main()
{
    try
    {

        // Create a non-transactional queue on the local computer.
        CreateQueue(".\\exampleQueue", false);

        // Demonstrate use of MessageQueuePermissionAccess.
        CreatePermission();
    }

    catch (InvalidOperationException^)
    {
        Console::WriteLine("Please install Message Queuing.");
    }

    catch (MessageQueueException^ ex)
    {
        Console::WriteLine(ex->Message);
    }
}

// </snippet0>

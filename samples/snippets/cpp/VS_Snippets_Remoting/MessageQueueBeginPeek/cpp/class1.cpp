// <snippet0>
#using <System.Messaging.dll>
#using <System.dll>

using namespace System;
using namespace System::Messaging;

// Creates a new queue.
void CreateQueue(String^ queuePath, bool transactional)
{
    if(!MessageQueue::Exists(queuePath))
    {
        MessageQueue^ queue = MessageQueue::Create(queuePath, transactional);
        queue->Close();      
    }
    else
    {
        Console::WriteLine("{0} already exists.", queuePath);
    }
}

// Provides an event handler for the PeekCompleted event.
void MyPeekCompleted(IAsyncResult^ asyncResult)
{
    // Connect to the queue.
    MessageQueue^ queue = gcnew MessageQueue(".\\exampleQueue");

    // End the asynchronous peek operation.
    Message^ msg = queue->EndPeek(asyncResult);

    // Display the message information on the screen.
    Console::WriteLine("Message number: {0}", asyncResult->AsyncState);
    Console::WriteLine("Message body: {0}", msg->Body);

    // Receive the message. This will remove the message from the queue.
    msg = queue->Receive(TimeSpan::FromSeconds(10.0));

    queue->Close();
}

int main()
{
    // Represents a state object associated with each message.
    int messageNumber = 0;

    // Create a non-transactional queue on the local computer.
    // Note that the queue might not be immediately accessible, and
    // therefore this example might throw an exception of type
    // System.Messaging.MessageQueueException when trying to send a
    // message to the newly created queue.
    CreateQueue(".\\exampleQueue", false);

    // Connect to a queue on the local computer.
    MessageQueue^ queue = gcnew MessageQueue(".\\exampleQueue");

    // Send a message to the queue.
    queue->Send("Example Message");

    // Begin the asynchronous peek operation.
    queue->BeginPeek(TimeSpan::FromSeconds(10.0), messageNumber++,
        gcnew AsyncCallback(MyPeekCompleted));

    // Simulate doing other work on the current thread.
    System::Threading::Thread::Sleep(TimeSpan::FromSeconds(10.0));

    queue->Close();
}

// </snippet0>

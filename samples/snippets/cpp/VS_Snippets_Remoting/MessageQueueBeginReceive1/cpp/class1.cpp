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

// Provides an event handler for the ReceiveCompleted event.
void HandleReceiveCompleted(Object^ source, ReceiveCompletedEventArgs^ e)
{
    // Connect to the queue.
    MessageQueue^ queue = (MessageQueue^)source;

    // End the asynchronous receive operation.
    Message^ msg = queue->EndReceive(e->AsyncResult);

    // Display the message information on the screen.
    Console::WriteLine("Message body: {0}", msg->Body);
    
    queue->Close();
}

int main()
{
    // Create a non-transactional queue on the local computer.
    // Note that the queue might not be immediately accessible, and
    // therefore this example might throw an exception of type
    // System.Messaging.MessageQueueException when trying to send a
    // message to the newly created queue.
    MessageQueue^ queue = nullptr;
    try
    {
        CreateQueue(".\\exampleQueue", false);

        // Connect to a queue on the local computer.
        queue = gcnew MessageQueue(".\\exampleQueue");

        // Add an event handler for the ReceiveCompleted event.
        queue->ReceiveCompleted += gcnew
            ReceiveCompletedEventHandler(HandleReceiveCompleted);

        // Send a message to the queue.
        queue->Send("Example Message");

        // Begin the asynchronous receive operation.
        queue->BeginReceive(TimeSpan::FromSeconds(10.0));

        // Simulate doing other work on the current thread.
        System::Threading::Thread::Sleep(TimeSpan::FromSeconds(10.0));
    }

    catch (InvalidOperationException^)
    {
        Console::WriteLine("Please install Message Queuing.");
    }

    catch (MessageQueueException^ ex)
    {
        Console::WriteLine(ex->Message);
    }

    finally
    {   
        queue->Close();
    }

}
// </snippet0>

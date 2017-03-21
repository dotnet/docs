
#using <System.Messaging.dll>
#using <System.dll>

using namespace System;
using namespace System::Messaging;

public ref class MessageQueuePermissionEntryExample
{
    // Creates a new queue.
public:
    static void CreateQueue(String^ queuePath, bool transactional)
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

    // Demonstrates the following MessageQueuePermission constructor:
    // public #ctor (MessageQueuePermissionAccess permissionAccess,
    //  String path)
public:
    void CreateEntryShortCtor()
    {
        // Connect to a queue on the local computer.
        MessageQueue^ queue = gcnew MessageQueue(".\\exampleQueue");

        // Create a new instance of MessageQueuePermissionEntry.
        MessageQueuePermissionEntry^ entry = gcnew MessageQueuePermissionEntry(
            MessageQueuePermissionAccess::Receive,
            queue->Path);

        queue->Close(); 
    }

    // Demonstrates the following MessageQueuePermission constructor:
    // public #ctor (MessageQueuePermissionAccess permissionAccess,
    //  String machineName, String label, String category)
public:
    void CreateEntryLongCtor()
    {
        // Connect to a queue on the local computer.
        MessageQueue^ queue = gcnew MessageQueue(".\\exampleQueue");

        // Create a new instance of MessageQueuePermissionEntry.
        MessageQueuePermissionEntry^ entry = gcnew MessageQueuePermissionEntry(
            MessageQueuePermissionAccess::Receive,
            queue->MachineName,
            queue->Label,
            queue->Category.ToString());

        queue->Close();
    }

public:
    void CategoryExample()
    {
        // Connect to a queue on the local computer.
        MessageQueue^ queue = gcnew MessageQueue(".\\exampleQueue");

        // Create a new instance of MessageQueuePermissionEntry.
        MessageQueuePermissionEntry^ entry = gcnew MessageQueuePermissionEntry(
            MessageQueuePermissionAccess::Receive,
            queue->MachineName,
            queue->Label,
            queue->Category.ToString());

        // Display the value of the entry's Category property.
        Console::WriteLine("Category: {0}", entry->Category->ToString());

        queue->Close();
    }

public:
    void LabelExample()
    {
        // Connect to a queue on the local computer.
        MessageQueue^ queue = gcnew MessageQueue(".\\exampleQueue");

        // Create a new instance of MessageQueuePermissionEntry.
        MessageQueuePermissionEntry^ entry = gcnew MessageQueuePermissionEntry(
            MessageQueuePermissionAccess::Receive,
            queue->MachineName,
            queue->Label,
            queue->Category.ToString());

        // Display the value of the entry's Label property.
        Console::WriteLine("Label: {0}", entry->Label);

        queue->Close();
    }

public:
    void MachineNameExample()
    {
        // Connect to a queue on the local computer.
        MessageQueue^ queue = gcnew MessageQueue(".\\exampleQueue");

        // Create a new instance of MessageQueuePermissionEntry.
        MessageQueuePermissionEntry^ entry = gcnew MessageQueuePermissionEntry(
            MessageQueuePermissionAccess::Receive,
            queue->MachineName,
            queue->Label,
            queue->Category.ToString());

        // Display the value of the entry's MachineName property.
        Console::WriteLine("MachineName: {0}", entry->MachineName);

        queue->Close();
    }

public:
    void PathExample()
    {
        // Connect to a queue on the local computer.
        MessageQueue^ queue = gcnew MessageQueue(".\\exampleQueue");

        // Create a new instance of MessageQueuePermissionEntry.
        MessageQueuePermissionEntry^ entry = gcnew MessageQueuePermissionEntry(
            MessageQueuePermissionAccess::Receive,
            queue->Path);

        // Display the value of the entry's Path property.
        Console::WriteLine("Path: {0}", entry->Path);

        queue->Close();
    }

public:
    void PermissionAccessExample()
    {
        // Connect to a queue on the local computer.
        MessageQueue^ queue = gcnew MessageQueue(".\\exampleQueue");

        // Create a new instance of MessageQueuePermissionEntry.
        MessageQueuePermissionEntry^ entry = gcnew MessageQueuePermissionEntry(
            MessageQueuePermissionAccess::Receive,
            queue->MachineName,
            queue->Label,
            queue->Category.ToString());

        // Display the value of the entry's PermissionAccess property.
        Console::WriteLine("PermissionAccess: {0}", entry->PermissionAccess);
 
        queue->Close(); 
    }
};

int main()
{
    // Create a new instance of the class.
    MessageQueuePermissionEntryExample^ example =
        gcnew MessageQueuePermissionEntryExample();

    try
    {
        // Create a non-transactional queue on the local computer.
        // Note that the queue might not be immediately accessible, and
        // therefore this example might throw an exception of type
        // System.Messaging.MessageQueueException when trying to send a
        // message to the newly created queue.
        example->CreateQueue(".\\exampleQueue", false);

        // Demonstrate MessageQueuePermissionEntry's constructors.
        example->CreateEntryShortCtor();
        example->CreateEntryLongCtor();

        // Demonstrate MessageQueuePermissionEntry's properties.
        example->CategoryExample();
        example->LabelExample();
        example->MachineNameExample();
        example->PathExample();
        example->PermissionAccessExample();
    }

    catch (InvalidOperationException^)
    {
        Console::WriteLine("Please install Message Queuing.");
    }

    catch (MessageQueueException^ ex)
    {
        // Write the exception information to the console.
        Console::WriteLine(ex->Message);
    }
}
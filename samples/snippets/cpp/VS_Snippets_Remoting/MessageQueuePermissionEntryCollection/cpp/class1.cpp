// <snippet0>

#using <System.Messaging.dll>
#using <System.dll>
using namespace System;
using namespace System::Messaging;

public ref class MessageQueuePermissionEntryCollectionExample
{
    // Demonstrates:
    // public Int32 Add (MessageQueuePermissionEntry value)
public:
    void AddExample()
    {
        // <snippet1>
        // Connect to a queue on the local computer.
        MessageQueue^ queue = gcnew MessageQueue(".\\exampleQueue");

        // Create a new instance of MessageQueuePermission.
        MessageQueuePermission^ permission = gcnew MessageQueuePermission();

        // Get an instance of MessageQueuePermissionEntryCollection from the
        // permission's PermissionEntries property.
        MessageQueuePermissionEntryCollection^ collection =
            permission->PermissionEntries;

        // Create a new instance of MessageQueuePermissionEntry.
        MessageQueuePermissionEntry^ entry = gcnew MessageQueuePermissionEntry(
            MessageQueuePermissionAccess::Receive, 
            queue->MachineName, 
            queue->Label, queue->Category.ToString());

        // Add the entry to the collection.
        collection->Add(entry);

        queue->Close();
        // </snippet1>
    }

    // Demonstrates:
    // public Void AddRange (MessageQueuePermissionEntry[] value)
public:
    void AddRangeExample1()
    {
        // <snippet2>
        // Connect to a queue on the local computer.
        MessageQueue^ queue = gcnew MessageQueue(".\\exampleQueue");

        // Create a new instance of MessageQueuePermission.
        MessageQueuePermission^ permission = gcnew MessageQueuePermission();

        // Get an instance of MessageQueuePermissionEntryCollection from the
        // permission's PermissionEntries property.
        MessageQueuePermissionEntryCollection^ collection =
            permission->PermissionEntries;

        // Create an array of type MessageQueuePermissionEntry.
        array<MessageQueuePermissionEntry^>^ entries = 
            gcnew array<MessageQueuePermissionEntry^>(1);

        // Create a new instance of MessageQueuePermissionEntry and place the
        // instance in the array.
        entries[0] = gcnew MessageQueuePermissionEntry(
            MessageQueuePermissionAccess::Receive, 
            queue->MachineName, 
            queue->Label, 
            queue->Category.ToString());

        // Add the array to the collection.
        collection->AddRange(entries);

        queue->Close();
        // </snippet2>
    }

    // Demonstrates:
    // public Void AddRange (MessageQueuePermissionEntryCollection value)
public:
    void AddRangeExample2()
    {
        // <snippet3>
        // Connect to a queue on the local computer.
        MessageQueue^ queue = gcnew MessageQueue(".\\exampleQueue");

        // Create a new instance of MessageQueuePermission.
        MessageQueuePermission^ permission = gcnew MessageQueuePermission();

        // Create a new instance of MessageQueuePermissionEntry.
        MessageQueuePermissionEntry^ entry = gcnew MessageQueuePermissionEntry(
            MessageQueuePermissionAccess::Receive, 
            queue->MachineName, 
            queue->Label, queue->Category.ToString());

        // Add the entry to the permission's collection.
        permission->PermissionEntries->Add(entry);

        // Create another new instance of MessageQueuePermission.
        MessageQueuePermission^ newPermission = gcnew MessageQueuePermission();

        // Use AddRange() to append the original permission's collection to the
        // new permission's collection.
        newPermission->PermissionEntries->AddRange(
            permission->PermissionEntries);

        // To show that AddRange() copies collections by value and not by
        // reference, we'll clear the original permission's collection, then
        // display a count of how many entries are in the original permission's
        // collection and how many entries are in the new permission's
        // collection.

        // Clear the original permission's collection.
        permission->PermissionEntries->Clear();

        // The original permission now contains 0 entries, but the new
        // permission still contains 1 entry.
        Console::WriteLine("Original permission contains {0} entries.",
            permission->PermissionEntries->Count);
        Console::WriteLine("New permission contains {0} entries.",
            newPermission->PermissionEntries->Count);

        queue->Close();
        // </snippet3>
    }

    // Demonstrates:
    // public Boolean Contains (MessageQueuePermissionEntry value)
public:
    void ContainsExample()
    {
        // <snippet4>
        // Connect to a queue on the local computer.
        MessageQueue^ queue = gcnew MessageQueue(".\\exampleQueue");

        // Create a new instance of MessageQueuePermission.
        MessageQueuePermission^ permission = gcnew MessageQueuePermission();

        // Get an instance of MessageQueuePermissionEntryCollection from the
        // permission's PermissionEntries property.
        MessageQueuePermissionEntryCollection^ collection =
            permission->PermissionEntries;

        // Create a new instance of MessageQueuePermissionEntry.
        MessageQueuePermissionEntry^ entry = gcnew MessageQueuePermissionEntry(
            MessageQueuePermissionAccess::Receive, 
            queue->MachineName, 
            queue->Label, 
            queue->Category.ToString());

        // Add the entry to the collection.
        collection->Add(entry);

        // Show that the collection contains the entry.
        Console::WriteLine("Collection contains first entry (true/false): {0}",
            collection->Contains(entry));

        // Create another new instance of MessageQueuePermissionEntry.
        MessageQueuePermissionEntry^ newEntry = 
            gcnew MessageQueuePermissionEntry(
            MessageQueuePermissionAccess::Send, 
            queue->MachineName, 
            queue->Label, 
            queue->Category.ToString());

        // Show that the collection does not contain the new entry.
        Console::WriteLine(
            "Collection contains second entry (true/false): {0}",
            collection->Contains(newEntry));

        queue->Close();
        // </snippet4>
    }

    // Demonstrates:
    // public Void CopyTo (MessageQueuePermissionEntry[] array, Int32 index)
public:
    void CopyToExample()
    {
        // <snippet5>
        // Connect to a queue on the local computer.
        MessageQueue^ queue = gcnew MessageQueue(".\\exampleQueue");

        // Create a new instance of MessageQueuePermission.
        MessageQueuePermission^ permission = gcnew MessageQueuePermission();

        // Get an instance of MessageQueuePermissionEntryCollection from the
        // permission's PermissionEntries property.
        MessageQueuePermissionEntryCollection^ collection =
            permission->PermissionEntries;

        // Create a new instance of MessageQueuePermissionEntry.
        MessageQueuePermissionEntry^ entry = gcnew MessageQueuePermissionEntry(
            MessageQueuePermissionAccess::Receive, 
            queue->MachineName, 
            queue->Label, 
            queue->Category.ToString());

        // Add the entry to the collection.
        collection->Add(entry);

        // Create an array of type MessageQueuePermissionEntry.
        array<MessageQueuePermissionEntry^>^ entries = 
            gcnew array<MessageQueuePermissionEntry^>(1);

        // Copy the collection to index 0 of the array.
        collection->CopyTo(entries, 0);

        // Show that the array now contains the entry.
        Console::WriteLine("entries[0].PermissionAccess: {0}",
            entries[0]->PermissionAccess);
        Console::WriteLine("entries[0].MachineName: {0}",
            entries[0]->MachineName);
        Console::WriteLine("entries[0].Label: {0}", entries[0]->Label);
        Console::WriteLine("entries[0].Category: {0}",
            entries[0]->Category);

        queue->Close();
        // </snippet5>
    }

    // Demonstrates:
    // public Int32 IndexOf (MessageQueuePermissionEntry value)
public:
    void IndexOfExample()
    {
        // <snippet6>
        // Connect to a queue on the local computer.
        MessageQueue^ queue = gcnew MessageQueue(".\\exampleQueue");

        // Create a new instance of MessageQueuePermission.
        MessageQueuePermission^ permission = gcnew MessageQueuePermission();

        // Get an instance of MessageQueuePermissionEntryCollection from the
        // permission's PermissionEntries property.
        MessageQueuePermissionEntryCollection^ collection =
            permission->PermissionEntries;

        // Create a new instance of MessageQueuePermissionEntry.
        MessageQueuePermissionEntry^ entry = gcnew MessageQueuePermissionEntry(
            MessageQueuePermissionAccess::Receive, 
            queue->MachineName, 
            queue->Label, 
            queue->Category.ToString());

        // Add the entry to the collection.
        collection->Add(entry);

        // Display the index of the entry in the collection.
        Console::WriteLine("Collection contains entry at index: {0}",
            collection->IndexOf(entry));

        queue->Close();
        // </snippet6>
    }

    // Demonstrates:
    // public Void Insert (Int32 index, MessageQueuePermissionEntry value)
public:
    void InsertExample()
    {
        // <snippet7>
        // Connect to a queue on the local computer.
        MessageQueue^ queue = gcnew MessageQueue(".\\exampleQueue");

        // Create a new instance of MessageQueuePermission.
        MessageQueuePermission^ permission = gcnew MessageQueuePermission();

        // Get an instance of MessageQueuePermissionEntryCollection from the
        // permission's PermissionEntries property.
        MessageQueuePermissionEntryCollection^ collection =
            permission->PermissionEntries;

        // Create a new instance of MessageQueuePermissionEntry.
        MessageQueuePermissionEntry^ entry = gcnew MessageQueuePermissionEntry(
            MessageQueuePermissionAccess::Receive, 
            queue->MachineName, 
            queue->Label, 
            queue->Category.ToString());

        // Add the entry to the collection.
        collection->Add(entry);

        // Create another new instance of MessageQueuePermissionEntry.
        MessageQueuePermissionEntry^ newEntry = 
            gcnew MessageQueuePermissionEntry(
            MessageQueuePermissionAccess::Send, 
            queue->MachineName, 
            queue->Label, 
            queue->Category.ToString());

        // Insert the new entry into the collection before the original entry.
        collection->Insert(0, newEntry);

        queue->Close();
        // </snippet7>
    }

    // Demonstrates:
    // public MessageQueuePermissionEntry Item [Int32 index] { get; set; }
public:
    void ItemExample()
    {
        // <snippet8>
        // Connect to a queue on the local computer.
        MessageQueue^ queue = gcnew MessageQueue(".\\exampleQueue");

        // Create a new instance of MessageQueuePermission.
        MessageQueuePermission^ permission = gcnew MessageQueuePermission();

        // Get an instance of MessageQueuePermissionEntryCollection from the
        // permission's PermissionEntries property.
        MessageQueuePermissionEntryCollection^ collection =
            permission->PermissionEntries;

        // Create a new instance of MessageQueuePermissionEntry.
        MessageQueuePermissionEntry^ entry = gcnew MessageQueuePermissionEntry(
            MessageQueuePermissionAccess::Receive, 
            queue->MachineName, 
            queue->Label, 
            queue->Category.ToString());

        // Add the entry to the collection.
        collection->Add(entry);

        // Display the entry's properties, using the collection's Item
        // accessor.
        Console::WriteLine("collection[0].PermissionAccess: {0}",
            collection[0]->PermissionAccess);
        Console::WriteLine("collection[0].MachineName: {0}",
            collection[0]->MachineName);
        Console::WriteLine("collection[0].Label: {0}", collection[0]->Label);
        Console::WriteLine("collection[0].Category: {0}",
            collection[0]->Category);

        queue->Close();
        // </snippet8>
    }

    // Demonstrates:
    // public Void Remove (MessageQueuePermissionEntry value)
public:
    void RemoveExample()
    {
        // <snippet9>
        // Connect to a queue on the local computer.
        MessageQueue^ queue = gcnew MessageQueue(".\\exampleQueue");

        // Create a new instance of MessageQueuePermission.
        MessageQueuePermission^ permission = gcnew MessageQueuePermission();

        // Get an instance of MessageQueuePermissionEntryCollection from the
        // permission's PermissionEntries property.
        MessageQueuePermissionEntryCollection^ collection =
            permission->PermissionEntries;

        // Create a new instance of MessageQueuePermissionEntry.
        MessageQueuePermissionEntry^ entry = gcnew MessageQueuePermissionEntry(
            MessageQueuePermissionAccess::Receive, 
            queue->MachineName, 
            queue->Label, 
            queue->Category.ToString());

        // Add the entry to the collection.
        collection->Add(entry);

        // Remove the entry from the collection.
        collection->Remove(entry);

        queue->Close();
        // </snippet9>
    }
};

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
        Console::WriteLine("{0} already exists.", queuePath);
    }
}

int main()
{
    // Create a new instance of the class.
    MessageQueuePermissionEntryCollectionExample^ example =
        gcnew MessageQueuePermissionEntryCollectionExample();

    // Create a non-transactional queue on the local computer.
    CreateQueue(".\\exampleQueue", false);

    // Demonstrate MessageQueuePermissionEntryCollection's members.
    example->AddExample();
    example->AddRangeExample1();
    example->AddRangeExample2();
    example->ContainsExample();
    example->CopyToExample();
    example->IndexOfExample();
    example->InsertExample();
    example->ItemExample();
    example->RemoveExample();
}

// </snippet0>

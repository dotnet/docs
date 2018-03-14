// <snippet0>

#using <System.Messaging.dll>
#using <System.dll>

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
        Console::WriteLine("{0} already exists.", queuePath);
    }
}

// Demonstrates the following MessageQueuePermissionAttribute constructor:
// public #ctor (SecurityAction action)
void CreateAttribute()
{
    // <snippet1>

    // Create a new instance of MessageQueuePermissionAttribute.
    MessageQueuePermissionAttribute^ attribute =
        gcnew MessageQueuePermissionAttribute(
        System::Security::Permissions::SecurityAction::Assert);

    // </snippet1>
}


void CategoryExample()
{
    // <snippet2>

    // Connect to a queue on the local computer.
    MessageQueue^ queue = gcnew MessageQueue(".\\exampleQueue");

    // Create a new instance of MessageQueuePermissionAttribute.
    MessageQueuePermissionAttribute^ attribute =
        gcnew MessageQueuePermissionAttribute(
        System::Security::Permissions::SecurityAction::Assert);

    // Set the attribute's Category property value, based on the queue's
    // Category property value.
    attribute->Category = queue->Category.ToString();

    // Display the new value of the attribute's Category property.
    Console::WriteLine("attribute->Category: {0}",
        attribute->Category);

    queue->Close();
    // </snippet2>
}

void LabelExample()
{
    // <snippet3>

    // Connect to a queue on the local computer.
    MessageQueue^ queue = gcnew MessageQueue(".\\exampleQueue");

    // Create a new instance of MessageQueuePermissionAttribute.
    MessageQueuePermissionAttribute^ attribute =
        gcnew MessageQueuePermissionAttribute(
        System::Security::Permissions::SecurityAction::Assert);

    // Set the attribute's Label property value, based on the queue's Label
    // property value.
    attribute->Label = queue->Label;

    // Display the new value of the attribute's Label property.
    Console::WriteLine("attribute->Label: {0}", attribute->Label);

    queue->Close();
    // </snippet3>
}


void MachineNameExample()
{
    // <snippet4>

    // Connect to a queue on the local computer.
    MessageQueue^ queue = gcnew MessageQueue(".\\exampleQueue");

    // Create a new instance of MessageQueuePermissionAttribute.
    MessageQueuePermissionAttribute^ attribute =
        gcnew MessageQueuePermissionAttribute(
        System::Security::Permissions::SecurityAction::Assert);

    // Set the attribute's MachineName property value, based on the queue's
    // MachineName property value.
    attribute->MachineName = queue->MachineName;

    // Display the new value of the attribute's MachineName property.
    Console::WriteLine("attribute->MachineName: {0}",
        attribute->MachineName);

    queue->Close();
    // </snippet4>
}

void PathExample()
{
    // <snippet5>

    // Connect to a queue on the local computer.
    MessageQueue^ queue = gcnew MessageQueue(".\\exampleQueue");

    // Create a new instance of MessageQueuePermissionAttribute.
    MessageQueuePermissionAttribute^ attribute =
        gcnew MessageQueuePermissionAttribute(
        System::Security::Permissions::SecurityAction::Assert);

    // Set the attribute's Path property value, based on the queue's Path
    // property value.
    attribute->Path = queue->Path;

    // Display the new value of the attribute's Path property.
    Console::WriteLine("attribute->Path: {0}", attribute->Path);

    queue->Close();
    // </snippet5>
}

void PermissionAccessExample()
{
    // <snippet6>

    // Connect to a queue on the local computer.
    MessageQueue^ queue = gcnew MessageQueue(".\\exampleQueue");

    // Create a new instance of MessageQueuePermissionAttribute.
    MessageQueuePermissionAttribute^ attribute =
        gcnew MessageQueuePermissionAttribute(
        System::Security::Permissions::SecurityAction::Assert);

    // Set the attribute's PermissionAccess property value.
    attribute->PermissionAccess = MessageQueuePermissionAccess::Receive;

    // Display the new value of the attribute's PermissionAccess property.
    Console::WriteLine("attribute->PermissionAccess: {0}",
        attribute->PermissionAccess);

    queue->Close();
    // </snippet6>
}

void CreatePermissionExample()
{
    // <snippet7>

    // Connect to a queue on the local computer.
    MessageQueue^ queue = gcnew MessageQueue(".\\exampleQueue");

    // Create a new instance of MessageQueuePermissionAttribute.
    MessageQueuePermissionAttribute^ attribute =
        gcnew MessageQueuePermissionAttribute(
        System::Security::Permissions::SecurityAction::Assert);

    // Set the attribute's Path property value, based on the queue's Path
    // property value.
    attribute->Path = queue->Path;

    // Get an IPermission interface by calling the attribute's
    // CreatePermission() method.
    System::Security::IPermission^ permission = attribute->CreatePermission();

    queue->Close();
    // </snippet7>
}

int main()
{
    try
    {

        // Create a non-transactional queue on the local computer.
        CreateQueue(".\\exampleQueue", false);

        // Demonstrate the members of MessageQueuePermissionAttribute.
        // Note that the Path, FormatName, MachineName, Label, and Category
        // property values cannot all be set on the same instance of
        // MessageQueuePermissionAttribute. Trying to do so will throw an
        // exception of type System.InvalidOperationException.

        CreateAttribute();
        CategoryExample();
        LabelExample();
        MachineNameExample();
        PathExample();
        PermissionAccessExample();
        CreatePermissionExample();
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

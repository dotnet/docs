#using <System.dll>
#using <System.Messaging.dll>

using namespace System;
using namespace System::Messaging;

// Creates a new queue.
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

void SendObjectString()
{
    // <snippet1>

    // Connect to a queue on the local computer.
    MessageQueue^ queue = gcnew MessageQueue(".\\exampleQueue");

    // Create a new message.
    Message^ msg = gcnew Message("Example Message Body");

    // Send the message.
    queue->Send(msg, "Example Message Label");

    queue->Close();

    // </snippet1>
}

void SendObjectTransactionType()
{
    // <snippet2>

    // Connect to a transactional queue on the local computer.
    MessageQueue^ queue = gcnew MessageQueue(".\\exampleTransQueue");

    // Create a new message.
    Message^ msg = gcnew Message("Example Message Body");

    // Send the message.
    queue->Send(msg, MessageQueueTransactionType::Single);

    queue->Close();

    // </snippet2>
}

void SendObjectStringTransactionType()
{
    // <snippet3>

    // Connect to a transactional queue on the local computer.
    MessageQueue^ queue = gcnew MessageQueue(".\\exampleTransQueue");

    // Create a new message.
    Message^ msg = gcnew Message("Example Message Body");

    // Send the message.
    queue->Send(msg, "Example Message Label",
        MessageQueueTransactionType::Single);

    queue->Close();

    // </snippet3>
}

void SendObjectStringTransaction()
{
    // <snippet4>

    // Connect to a transactional queue on the local computer.
    MessageQueue^ queue = gcnew MessageQueue(".\\exampleTransQueue");

    // Create a new message.
    Message^ msg = gcnew Message("Example Message Body");

    // Create a message queuing transaction.
    MessageQueueTransaction^ transaction = gcnew MessageQueueTransaction();

    try
    {
        // Begin a transaction.
        transaction->Begin();

        // Send the message to the queue.
        queue->Send(msg, "Example Message Label", transaction);

        // Commit the transaction.
        transaction->Commit();
    }
    catch (Exception^ ex)
    {
        // Cancel the transaction.
        transaction->Abort();

        // Propagate the exception.
        throw ex;
    }
    finally
    {
        // Dispose of the transaction object.
        delete transaction;
        queue->Close();
    }

    // </snippet4>
}

void PeekByCorrelationIdStringTimespan()
{
    // <snippet5>

    // Connect to a queue on the local computer.
    MessageQueue^ queue = gcnew MessageQueue(".\\exampleQueue");

    // Create a new message.
    Message^ msg = gcnew Message("Example Message Body");

    // Designate a queue to receive the acknowledgement message for this
    // message.
    msg->AdministrationQueue = 
        gcnew MessageQueue(".\\exampleAdminQueue");

    // Set the message to generate an acknowledgement message upon its
    // arrival.
    msg->AcknowledgeType = AcknowledgeTypes::PositiveArrival;

    // Send the message.
    queue->Send(msg, "Example Message Label");

    // Get the message's Id property value.
    String^ id = msg->Id;

    // Receive the message from the queue.
    msg = queue->ReceiveById(id, TimeSpan::FromSeconds(10.0));

    // Connect to the admin queue.
    MessageQueue^ adminQueue = 
        gcnew MessageQueue(".\\exampleAdminQueue");

    // Set the admin queue's MessageReadPropertyFilter property to ensure
    // that the acknowledgement message includes the desired properties.
    adminQueue->MessageReadPropertyFilter->Acknowledgment = true;
    adminQueue->MessageReadPropertyFilter->CorrelationId = true;

    // Peek at the acknowledgement message.
    Message^ ackMsg = adminQueue->PeekByCorrelationId(id,
        TimeSpan::FromSeconds(10.0));

    // Display the acknowledgement message's property values.
    Console::WriteLine("Message.Label: {0}", ackMsg->Label);
    Console::WriteLine("Message.Acknowledgment: {0}",
        ackMsg->Acknowledgment);
    Console::WriteLine("Message.CorrelationId: {0}", ackMsg->CorrelationId);

    adminQueue->Close();
    queue->Close();

    // </snippet5>
}

void PeekByIdString()
{
    // <snippet6>

    // Connect to a queue on the local computer.
    MessageQueue^ queue = gcnew MessageQueue(".\\exampleQueue");

    // Create a new message.
    Message^ msg = gcnew Message("Example Message Body");

    // Send the message.
    queue->Send(msg, "Example Message Label");

    // Get the message's Id property value.
    String^ id = msg->Id;

    // Simulate doing other work so the message has time to arrive.
    System::Threading::Thread::Sleep(TimeSpan::FromSeconds(10.0));

    // Peek at the message.
    msg = queue->PeekById(id);

    queue->Close();

    // </snippet6>
}

void PeekByIdStringTimespan()
{
    // <snippet7>

    // Connect to a queue on the local computer.
    MessageQueue^ queue = gcnew MessageQueue(".\\exampleQueue");

    // Create a new message.
    Message^ msg = gcnew Message("Example Message Body");

    // Send the message.
    queue->Send(msg, "Example Message Label");

    // Get the message's Id property value.
    String^ id = msg->Id;

    // Peek at the message.
    msg = queue->PeekById(id, TimeSpan::FromSeconds(10.0));

    queue->Close();

    // </snippet7>
}

void ReceiveTimespanTransactionType()
{
    // <snippet8>

    // Connect to a transactional queue on the local computer.
    MessageQueue^ queue = gcnew MessageQueue(".\\exampleTransQueue");

    // Create a new message.
    Message^ msg = gcnew Message("Example Message Body");

    // Send the message.
    queue->Send(msg, MessageQueueTransactionType::Single);

    // Set the formatter to indicate the message body contains a String.
    queue->Formatter = gcnew XmlMessageFormatter(
        gcnew array<Type^>{String::typeid});

    // Receive the message from the queue. Because the Id of the message
    // is not specified, it might not be the message just sent.
    msg = queue->Receive(TimeSpan::FromSeconds(10.0),
        MessageQueueTransactionType::Single);

    queue->Close();

    // </snippet8>
}

void ReceiveTransactionType()
{
    // <snippet9>

    // Connect to a transactional queue on the local computer.
    MessageQueue^ queue = gcnew MessageQueue(".\\exampleTransQueue");

    // Create a new message.
    Message^ msg = gcnew Message("Example Message Body");

    // Send the message.
    queue->Send(msg, MessageQueueTransactionType::Single);

    // Simulate doing other work so the message has time to arrive.
    System::Threading::Thread::Sleep(TimeSpan::FromSeconds(10.0));

    // Set the formatter to indicate the message body contains a String.
    queue->Formatter = gcnew XmlMessageFormatter(
        gcnew array<Type^>{String::typeid});

    // Receive the message from the queue.  Because the Id of the message
    // , it might not be the message just sent.
    msg = queue->Receive(MessageQueueTransactionType::Single);

    queue->Close();

    // </snippet9>
}

void ReceiveByCorrelationIdStringTimespan()
{
    // <snippet10>

    // Connect to a queue on the local computer.
    MessageQueue^ queue = gcnew MessageQueue(".\\exampleQueue");

    // Create a new message.
    Message^ msg = gcnew Message("Example Message Body");

    // Designate a queue to receive the acknowledgement message for this
    // message.
    msg->AdministrationQueue = 
        gcnew MessageQueue(".\\exampleAdminQueue");

    // Set the message to generate an acknowledgement message upon its
    // arrival.
    msg->AcknowledgeType = AcknowledgeTypes::PositiveArrival;

    // Send the message.
    queue->Send(msg, "Example Message Label");

    // Get the message's Id property value.
    String^ id = msg->Id;

    // Receive the message from the queue.
    msg = queue->ReceiveById(id, TimeSpan::FromSeconds(10.0));

    // Connect to the admin queue.
    MessageQueue^ adminQueue = 
        gcnew MessageQueue(".\\exampleAdminQueue");

    // Set the admin queue's MessageReadPropertyFilter property to ensure
    // that the acknowledgement message includes the desired properties.
    adminQueue->MessageReadPropertyFilter->Acknowledgment = true;
    adminQueue->MessageReadPropertyFilter->CorrelationId = true;

    // Receive the acknowledgement message from the admin queue.
    Message^ ackMsg = adminQueue->ReceiveByCorrelationId(id,
        TimeSpan::FromSeconds(10.0));

    // Display the acknowledgement message's property values.
    Console::WriteLine("Message.Label: {0}", ackMsg->Label);
    Console::WriteLine("Message.Acknowledgment: {0}",
        ackMsg->Acknowledgment);
    Console::WriteLine("Message.CorrelationId: {0}", ackMsg->CorrelationId);

    adminQueue->Close();
    queue->Close();

    // </snippet10>
}

void ReceiveByCorrelationIdStringTransactionType()
{
    // <snippet11>

    // Connect to a nontransactional queue on the local computer.
    MessageQueue^ queue = gcnew MessageQueue(".\\exampleQueue");

    // Create a new message.
    Message^ msg = gcnew Message("Example Message Body");

    // Send the message to the nontransactional queue.
    queue->Send(msg, "Example Message Label");

    // Get the message's Id property value.
    String^ id = msg->Id;

    // Receive the message from the nontransactional queue.
    msg = queue->ReceiveById(id, TimeSpan::FromSeconds(10.0));

    // Connect to a transactional queue on the local computer.
    MessageQueue^ transQueue = 
        gcnew MessageQueue(".\\exampleTransQueue");

    // Create a new message in response to the original message.
    Message^ responseMsg = gcnew Message("Example Response Message Body");

    // Set the response message's CorrelationId property value to the Id
    // property value of the original message.
    responseMsg->CorrelationId = id;

    // Send the response message to the transactional queue.
    transQueue->Send(responseMsg, "Example Response Message Label",
        MessageQueueTransactionType::Single);

    // Simulate doing other work so the message has time to arrive.
    System::Threading::Thread::Sleep(TimeSpan::FromSeconds(10.0));

    // Set the transactional queue's MessageReadPropertyFilter property to
    // ensure that the response message includes the desired properties.
    transQueue->MessageReadPropertyFilter->CorrelationId = true;

    // Receive the response message from the transactional queue.
    responseMsg = transQueue->ReceiveByCorrelationId(id,
        MessageQueueTransactionType::Single);

    // Display the response message's property values.
    Console::WriteLine("Message.Label: {0}", responseMsg->Label);
    Console::WriteLine("Message.CorrelationId: {0}",
        responseMsg->CorrelationId);

    transQueue->Close();
    queue->Close();

    // </snippet11>
}

void ReceiveByCorrelationIdStringTimespanTransactionType()
{
    // <snippet12>

    // Connect to a nontransactional queue on the local computer.
    MessageQueue^ queue = gcnew MessageQueue(".\\exampleQueue");

    // Create a new message.
    Message^ msg = gcnew Message("Example Message Body");

    // Send the message to the nontransactional queue.
    queue->Send(msg, "Example Message Label");

    // Get the message's Id property value.
    String^ id = msg->Id;

    // Receive the message from the nontransactional queue.
    msg = queue->ReceiveById(id, TimeSpan::FromSeconds(10.0));

    // Connect to a transactional queue on the local computer.
    MessageQueue^ transQueue = 
        gcnew MessageQueue(".\\exampleTransQueue");

    // Create a new message in response to the original message.
    Message^ responseMsg = gcnew Message("Example Response Message Body");

    // Set the response message's CorrelationId property value to the Id
    // property value of the original message.
    responseMsg->CorrelationId = id;

    // Send the response message to the transactional queue.
    transQueue->Send(responseMsg, "Example Response Message Label",
        MessageQueueTransactionType::Single);

    // Set the transactional queue's MessageReadPropertyFilter property to
    // ensure that the response message includes the desired properties.
    transQueue->MessageReadPropertyFilter->CorrelationId = true;

    // Receive the response message from the transactional queue.
    responseMsg = transQueue->ReceiveByCorrelationId(id,
        TimeSpan::FromSeconds(10.0), MessageQueueTransactionType::Single);

    // Display the response message's property values.
    Console::WriteLine("Message.Label: {0}", responseMsg->Label);
    Console::WriteLine("Message.CorrelationId: {0}",
        responseMsg->CorrelationId);

    transQueue->Close();
    queue->Close();

    // </snippet12>
}

void ReceiveByCorrelationIdStringTimespanTransaction()
{
    // <snippet13>

    // Connect to a nontransactional queue on the local computer.
    MessageQueue^ queue = gcnew MessageQueue(".\\exampleQueue");

    // Create a new message.
    Message^ msg = gcnew Message("Example Message Body");

    // Send the message to the nontransactional queue.
    queue->Send(msg, "Example Message Label");

    // Get the message's Id property value.
    String^ id = msg->Id;

    // Receive the message from the nontransactional queue.
    msg = queue->ReceiveById(id, TimeSpan::FromSeconds(10.0));

    // Connect to a transactional queue on the local computer.
    MessageQueue^ transQueue = 
        gcnew MessageQueue(".\\exampleTransQueue");

    // Create a new message in response to the original message.
    Message^ responseMsg = gcnew Message("Example Response Message Body");

    // Set the response message's CorrelationId property value to the Id
    // property value of the original message.
    responseMsg->CorrelationId = id;

    // Send the response message to the transactional queue.
    transQueue->Send(responseMsg, "Example Response Message Label",
        MessageQueueTransactionType::Single);

    // Set the transactional queue's MessageReadPropertyFilter property to
    // ensure that the response message includes the desired properties.
    transQueue->MessageReadPropertyFilter->CorrelationId = true;

    // Create a message queuing transaction.
    MessageQueueTransaction^ transaction = gcnew MessageQueueTransaction();

    try
    {
        // Begin a transaction.
        transaction->Begin();

        // Receive the response message from the transactional queue.
        responseMsg = transQueue->ReceiveByCorrelationId(id,
            TimeSpan::FromSeconds(10.0), transaction);

        // Commit the transaction.
        transaction->Commit();
    }
    catch (Exception^ ex)
    {
        // Cancel the transaction.
        transaction->Abort();

        // Propagate the exception.
        throw ex;
    }
    finally
    {
        // Dispose of the transaction object.
        delete transaction;
        transQueue->Close();
        queue->Close();
    }

    // Display the response message's property values.
    Console::WriteLine("Message.Label: {0}", responseMsg->Label);
    Console::WriteLine("Message.CorrelationId: {0}",
        responseMsg->CorrelationId);
                       	
    // </snippet13>
}

void ReceiveByCorrelationIdStringTransaction()
{
    // <snippet14>

    // Connect to a nontransactional queue on the local computer.
    MessageQueue^ queue = gcnew MessageQueue(".\\exampleQueue");

    // Create a new message.
    Message^ msg = gcnew Message("Example Message Body");

    // Send the message to the nontransactional queue.
    queue->Send(msg, "Example Message Label");

    // Get the message's Id property value.
    String^ id = msg->Id;

    // Receive the message from the nontransactional queue.
    msg = queue->ReceiveById(id, TimeSpan::FromSeconds(10.0));

    // Connect to a transactional queue on the local computer.
    MessageQueue^ transQueue = 
        gcnew MessageQueue(".\\exampleTransQueue");

    // Create a new message in response to the original message.
    Message^ responseMsg = gcnew Message("Example Response Message Body");

    // Set the response message's CorrelationId property value to the Id
    // property value of the original message.
    responseMsg->CorrelationId = id;

    // Send the response message to the transactional queue.
    transQueue->Send(responseMsg, "Example Response Message Label",
        MessageQueueTransactionType::Single);

    // Simulate doing other work so the message has time to arrive.
    System::Threading::Thread::Sleep(TimeSpan::FromSeconds(10.0));

    // Set the transactional queue's MessageReadPropertyFilter property to
    // ensure that the response message includes the desired properties.
    transQueue->MessageReadPropertyFilter->CorrelationId = true;

    // Create a message queuing transaction.
    MessageQueueTransaction^ transaction = gcnew MessageQueueTransaction();

    try
    {
        // Begin a transaction.
        transaction->Begin();

        // Receive the response message from the transactional queue.
        responseMsg = transQueue->ReceiveByCorrelationId(id, transaction);

        // Commit the transaction.
        transaction->Commit();
    }
    catch (Exception^ ex)
    {
        // Cancel the transaction.
        transaction->Abort();

        // Propagate the exception.
        throw ex;
    }
    finally
    {
        // Dispose of the transaction object.
        delete transaction;
        transQueue->Close();
        queue->Close(); 
    }

    // Display the response message's property values.
    Console::WriteLine("Message.Label: {0}", responseMsg->Label);
    Console::WriteLine("Message.CorrelationId: {0}",
        responseMsg->CorrelationId);

    // </snippet14>
}

void ReceiveByIdStringTransactionType()
{
    // <snippet15>

    // Connect to a transactional queue on the local computer.
    MessageQueue^ queue = gcnew MessageQueue(".\\exampleTransQueue");

    // Create a new message.
    Message^ msg = gcnew Message("Example Message Body");

    // Send the message.
    queue->Send(msg, "Example Message Label",
        MessageQueueTransactionType::Single);

    // Get the message's Id property value.
    String^ id = msg->Id;

    // Simulate doing other work so the message has time to arrive.
    System::Threading::Thread::Sleep(TimeSpan::FromSeconds(10.0));

    // Receive the message from the queue.
    msg = queue->ReceiveById(id, MessageQueueTransactionType::Single);

    queue->Close();

    // </snippet15>
}

void ReceiveByIdString()
{
    // <snippet16>

    // Connect to a queue on the local computer.
    MessageQueue^ queue = gcnew MessageQueue(".\\exampleQueue");

    // Create a new message.
    Message^ msg = gcnew Message("Example Message Body");

    // Send the message.
    queue->Send(msg, "Example Message Label");

    // Get the message's Id property value.
    String^ id = msg->Id;

    // Simulate doing other work so the message has time to arrive.
    System::Threading::Thread::Sleep(TimeSpan::FromSeconds(10.0));

    // Receive the message from the queue.
    msg = queue->ReceiveById(id);

    queue->Close();

    // </snippet16>
}

void ReceiveByIdStringTransaction()
{
    // <snippet17>

    // Connect to a transactional queue on the local computer.
    MessageQueue^ queue = gcnew MessageQueue(".\\exampleTransQueue");

    // Create a new message.
    Message^ msg = gcnew Message("Example Message Body");

    // Send the message.
    queue->Send(msg, "Example Message Label",
        MessageQueueTransactionType::Single);

    // Get the message's Id property value.
    String^ id = msg->Id;

    // Simulate doing other work so the message has time to arrive.
    System::Threading::Thread::Sleep(TimeSpan::FromSeconds(10.0));

    // Create a message queuing transaction.
    MessageQueueTransaction^ transaction = gcnew MessageQueueTransaction();

    try
    {
        // Begin a transaction.
        transaction->Begin();

        // Receive the message from the queue.
        msg = queue->ReceiveById(id, transaction);

        // Commit the transaction.
        transaction->Commit();
    }
    catch (Exception^ ex)
    {
        // Cancel the transaction.
        transaction->Abort();

        // Propagate the exception.
        throw ex;
    }
    finally
    {
        // Dispose of the transaction object.
        delete transaction;
        queue->Close();
    }

    // </snippet17>
}

void ReceiveByIdStringTimespanTransaction()
{
    // <snippet18>

    // Connect to a transactional queue on the local computer.
    MessageQueue^ queue = gcnew MessageQueue(".\\exampleTransQueue");

    // Create a new message.
    Message^ msg = gcnew Message("Example Message Body");

    // Send the message.
    queue->Send(msg, "Example Message Label",
        MessageQueueTransactionType::Single);

    // Get the message's Id property value.
    String^ id = msg->Id;

    // Create a message queuing transaction.
    MessageQueueTransaction^ transaction = gcnew MessageQueueTransaction();

    try
    {
        // Begin a transaction.
        transaction->Begin();

        // Receive the message from the queue.
        msg = queue->ReceiveById(id, TimeSpan::FromSeconds(10.0),
            transaction);

        // Commit the transaction.
        transaction->Commit();
    }
    catch (Exception^ ex)
    {
        // Cancel the transaction.
        transaction->Abort();

        // Propagate the exception.
        throw ex;
    }
    finally
    {
        // Dispose of the transaction object.
        delete transaction;
        queue->Close();
    }

    // </snippet18>
}

void ReceiveByIdStringTimespanTransactionType()
{
    // <snippet19>

    // Connect to a transactional queue on the local computer.
    MessageQueue^ queue = gcnew MessageQueue(".\\exampleTransQueue");

    // Create a new message.
    Message^ msg = gcnew Message("Example Message Body");

    // Send the message.
    queue->Send(msg, "Example Message Label",
        MessageQueueTransactionType::Single);

    // Get the message's Id property value.
    String^ id = msg->Id;

    // Receive the message from the queue.
    msg = queue->ReceiveById(id, TimeSpan::FromSeconds(10.0),
        MessageQueueTransactionType::Single);

    queue->Close();

    // </snippet19>
}

void ReceiveByIdStringTimespan()
{
    // <snippet20>

    // Connect to a queue on the local computer.
    MessageQueue^ queue = gcnew MessageQueue(".\\exampleQueue");

    // Create a new message.
    Message^ msg = gcnew Message("Example Message Body");

    // Send the message.
    queue->Send(msg, "Example Message Label");

    // Get the message's Id property value.
    String^ id = msg->Id;

    // Receive the message from the queue.
    msg = queue->ReceiveById(id, TimeSpan::FromSeconds(10.0));

    queue->Close();

    // </snippet20>
}

void GetAllMessages()
{
    // <snippet21>

    // Connect to a queue on the local computer.
    MessageQueue^ queue = gcnew MessageQueue(".\\exampleQueue");

    // Populate an array with copies of all the messages in the queue.
    array<Message^>^ msgs = queue->GetAllMessages();

    // Loop through the messages.
    for each(Message^ msg in msgs)
    {
        // Display the label of each message.
        Console::WriteLine(msg->Label);
    }

    queue->Close();

    // </snippet21>
}

void GetEnumerator()
{
    // <snippet22>

    // Connect to a queue on the local computer.
    MessageQueue^ queue = gcnew MessageQueue(".\\exampleQueue");

    // Get an IEnumerator object.
    System::Collections::IEnumerator^ enumerator = 
        queue->GetMessageEnumerator2();

    // Use the IEnumerator object to loop through the messages.
    while(enumerator->MoveNext())
    {
        // Get a message from the enumerator.
        Message^ msg = (Message^)enumerator->Current;

        // Display the label of the message.
        Console::WriteLine(msg->Label);
    }

    queue->Close();

    // </snippet22>
}

void SetPermissionsStringAccessRights()
{
    // <snippet23>

    // Connect to a queue on the local computer.
    MessageQueue^ queue = gcnew MessageQueue(".\\exampleQueue");

    // Grant all users in the "Everyone" user group the right to receive
    // messages from the queue.
    queue->SetPermissions("Everyone",
        MessageQueueAccessRights::ReceiveMessage);

    queue->Close();

    // </snippet23>
}

void SetPermissionsAccessControlEntry()
{
    // <snippet24>

    // Connect to a queue on the local computer.
    MessageQueue^ queue = gcnew MessageQueue(".\\exampleQueue");

    // Create a new trustee to represent the "Everyone" user group.
    Trustee^ tr = gcnew Trustee("Everyone");

    // Create a MessageQueueAccessControlEntry, granting the trustee the
    // right to receive messages from the queue.
    MessageQueueAccessControlEntry^ entry = gcnew
        MessageQueueAccessControlEntry(
        tr, MessageQueueAccessRights::ReceiveMessage,
        AccessControlEntryType::Allow);

    // Apply the MessageQueueAccessControlEntry to the queue.
    queue->SetPermissions(entry);

    queue->Close();

    // </snippet24>
}

void SetPermissionsStringAccessRightsAccessControlEntryType()
{
    // <snippet25>

    // Connect to a queue on the local computer.
    MessageQueue^ queue = gcnew MessageQueue(".\\exampleQueue");

    // Grant all users in the "Everyone" user group the right to receive
    // messages from the queue.
    queue->SetPermissions("Everyone",
        MessageQueueAccessRights::ReceiveMessage,
        AccessControlEntryType::Allow);

    queue->Close();

    // </snippet25>
}

void SetPermissionsAccessControlList()
{
    // <snippet26>

    // Connect to a queue on the local computer.
    MessageQueue^ queue = gcnew MessageQueue(".\\exampleQueue");

    // Create an AccessControlList.
    AccessControlList^ list = gcnew AccessControlList();

    // Create a new trustee to represent the "Everyone" user group.
    Trustee^ tr = gcnew Trustee("Everyone");

    // Create an AccessControlEntry, granting the trustee read access to
    // the queue.
    AccessControlEntry^ entry = gcnew AccessControlEntry(
        tr, GenericAccessRights::Read,
        StandardAccessRights::Read,
        AccessControlEntryType::Allow);

    // Add the AccessControlEntry to the AccessControlList.
    list->Add(entry);

    // Apply the AccessControlList to the queue.
    queue->SetPermissions(list);

    queue->Close();

    // </snippet26>
}

void ResetPermissions()
{
    // <snippet27>

    // Connect to a queue on the local computer.
    MessageQueue^ queue = gcnew MessageQueue(".\\exampleQueue");

    // Reset the queue's permission list to its default values.
    queue->ResetPermissions();

    queue->Close();

    // </snippet27>
}

void Refresh()
{
    // <snippet28>

    // Connect to a queue on the local computer.
    MessageQueue^ queue = gcnew MessageQueue(".\\exampleQueue");

    // Refresh the queue's property values to obtain its current state.
    queue->Refresh();

    queue->Close();

    // </snippet28>
}

void Purge()
{
    // <snippet29>

    // Connect to a queue on the local computer.
    MessageQueue^ queue = gcnew MessageQueue(".\\exampleQueue");

    // Delete all messages from the queue.
    queue->Purge();

    queue->Close();

    // </snippet29>
}

void main()
{
    try
    {
        // Create a nontransactional queue on the local computer.
        // Note that the queue might not be immediately accessible, and
        // therefore this example might throw an exception of type
        // System.Messaging.MessageQueueException when trying to send a
        // message to the newly created queue.
        CreateQueue(".\\exampleQueue", false);

        // Create a nontransactional queue on the local computer. This
        // queue will be used to receive acknowledgement messages.
        CreateQueue(".\\exampleAdminQueue", false);

        // Create a transactional queue on the local computer.
        CreateQueue(".\\exampleTransQueue", true);

        // Send a message to a queue.
        SendObjectString();

        // Send a message to a transactional queue.
        SendObjectTransactionType();

        // Send a message to a transactional queue.
        SendObjectStringTransactionType();

        // Send a message to a transactional queue.
        SendObjectStringTransaction();

        // Demonstrate PeekById.
        PeekByIdString();

        // Demonstrate PeekById.
        PeekByIdStringTimespan();

        // Demonstrate PeekByCorrelationId.
        PeekByCorrelationIdStringTimespan();

        // Receive a message from a transactional queue.
        ReceiveTimespanTransactionType();

        // Receive a message from a transactional queue.
        ReceiveTransactionType();

        // Demonstrate ReceiveByCorrelationId.
        ReceiveByCorrelationIdStringTimespan();

        // Demonstrate ReceiveByCorrelationId.
        ReceiveByCorrelationIdStringTransactionType();

        // Demonstrate ReceiveByCorrelationId.
        ReceiveByCorrelationIdStringTimespanTransactionType();

        // Demonstrate ReceiveByCorrelationId.
        ReceiveByCorrelationIdStringTimespanTransaction();

        // Demonstrate ReceiveByCorrelationId.
        ReceiveByCorrelationIdStringTransaction();

        // Demonstrate ReceiveById.
        ReceiveByIdStringTransactionType();

        // Demonstrate ReceiveById.
        ReceiveByIdString();

        // Demonstrate ReceiveById.
        ReceiveByIdStringTransaction();

        // Demonstrate ReceiveById.
        ReceiveByIdStringTimespanTransaction();

        // Demonstrate ReceiveById.
        ReceiveByIdStringTimespanTransactionType();

        // Demonstrate ReceiveById.
        ReceiveByIdStringTimespan();

        // Demonstrate GetAllMessages.
        GetAllMessages();

        // Demonstrate GetEnumerator.
        GetEnumerator();

        // Demonstrate SetPermissions.
        SetPermissionsStringAccessRights();

        // Demonstrate SetPermissions.
        SetPermissionsAccessControlEntry();

        // Demonstrate SetPermissions.
        SetPermissionsStringAccessRightsAccessControlEntryType();

        // Demonstrate SetPermissions.
        SetPermissionsAccessControlList();

        // Demonstrate ResetPermissions.
        ResetPermissions();

        // Demonstrate Refresh.
        Refresh();

        // Demonstrate Purge.
        Purge();
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
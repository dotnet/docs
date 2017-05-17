// <snippet0>

using System;
using System.Messaging;

public class QueueExample
{
    public static void Main()
    {
        // Create a new instance of the class.
        QueueExample example = new QueueExample();

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
            example.Send_ObjectString();

            // Send a message to a transactional queue.
            example.Send_ObjectTransactiontype();

            // Send a message to a transactional queue.
            example.Send_ObjectStringTransactiontype();

            // Send a message to a transactional queue.
            example.Send_ObjectStringTransaction();

            // Demonstrate PeekById.
            example.PeekById_String();

            // Demonstrate PeekById.
            example.PeekById_StringTimespan();

            // Demonstrate PeekByCorrelationId.
            example.PeekByCorrelationId_StringTimespan();

            // Receive a message from a transactional queue.
            example.Receive_TimespanTransactiontype();

            // Receive a message from a transactional queue.
            example.Receive_Transactiontype();

            // Demonstrate ReceiveByCorrelationId.
            example.ReceiveByCorrelationId_StringTimespan();

            // Demonstrate ReceiveByCorrelationId.
            example.ReceiveByCorrelationId_StringTransactiontype();

            // Demonstrate ReceiveByCorrelationId.
            example.ReceiveByCorrelationId_StringTimespanTransactiontype();

            // Demonstrate ReceiveByCorrelationId.
            example.ReceiveByCorrelationId_StringTimespanTransaction();

            // Demonstrate ReceiveByCorrelationId.
            example.ReceiveByCorrelationId_StringTransaction();

            // Demonstrate ReceiveById.
            example.ReceiveById_StringTransactionType();

            // Demonstrate ReceiveById.
            example.ReceiveById_String();

            // Demonstrate ReceiveById.
            example.ReceiveById_StringTransaction();

            // Demonstrate ReceiveById.
            example.ReceiveById_StringTimespanTransaction();

            // Demonstrate ReceiveById.
            example.ReceiveById_StringTimespanTransactiontype();

            // Demonstrate ReceiveById.
            example.ReceiveById_StringTimespan();

            // Demonstrate GetAllMessages.
            example.GetAllMessages();

            // Demonstrate GetEnumerator.
            example.GetEnumerator();

            // Demonstrate SetPermissions.
            example.SetPermissions_StringAccessrights();

            // Demonstrate SetPermissions.
            example.SetPermissions_Accesscontrolentry();

            // Demonstrate SetPermissions.
            example.SetPermissions_StringAccessrightsAccesscontrolentrytype();

            // Demonstrate SetPermissions.
            example.SetPermissions_Accesscontrollist();

            // Demonstrate ResetPermissions.
            example.ResetPermissions();

            // Demonstrate Refresh.
            example.Refresh();

            // Demonstrate Purge.
            example.Purge();
        }
        catch(System.Exception e)
        {
            // Write the exception information to the console.
            Console.WriteLine(e);
        }
    }

    // Creates a new queue.
    public static void CreateQueue(string queuePath, bool transactional)
    {
        if(!MessageQueue.Exists(queuePath))
        {
            MessageQueue.Create(queuePath, transactional);
        }
        else
        {
            Console.WriteLine(queuePath + " already exists.");
        }
    }

    public void Send_ObjectString()
    {
        // <snippet1>

        // Connect to a queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleQueue");

        // Create a new message.
        Message msg = new Message("Example Message Body");

        // Send the message.
        queue.Send(msg, "Example Message Label");

        // </snippet1>
    }

    public void Send_ObjectTransactiontype()
    {
        // <snippet2>

        // Connect to a transactional queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleTransQueue");

        // Create a new message.
        Message msg = new Message("Example Message Body");

        // Send the message.
        queue.Send(msg, MessageQueueTransactionType.Single);

        // </snippet2>
    }

    public void Send_ObjectStringTransactiontype()
    {
        // <snippet3>

        // Connect to a transactional queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleTransQueue");

        // Create a new message.
        Message msg = new Message("Example Message Body");

        // Send the message.
        queue.Send(msg, "Example Message Label",
            MessageQueueTransactionType.Single);

        // </snippet3>
    }

    public void Send_ObjectStringTransaction()
    {
        // <snippet4>

        // Connect to a transactional queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleTransQueue");

        // Create a new message.
        Message msg = new Message("Example Message Body");

        // Create a message queuing transaction.
        MessageQueueTransaction transaction = new MessageQueueTransaction();

        try
        {
            // Begin a transaction.
            transaction.Begin();

            // Send the message to the queue.
            queue.Send(msg, "Example Message Label", transaction);

            // Commit the transaction.
            transaction.Commit();
        }
        catch(System.Exception e)
        {
            // Cancel the transaction.
            transaction.Abort();

            // Propagate the exception.
            throw e;
        }
        finally
        {
            // Dispose of the transaction object.
            transaction.Dispose();
        }

        // </snippet4>
    }

    public void PeekByCorrelationId_StringTimespan()
    {
        // <snippet5>

        // Connect to a queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleQueue");

        // Create a new message.
        Message msg = new Message("Example Message Body");

        // Designate a queue to receive the acknowledgement message for this
        // message.
        msg.AdministrationQueue = new MessageQueue(".\\exampleAdminQueue");

        // Set the message to generate an acknowledgement message upon its
        // arrival.
        msg.AcknowledgeType = AcknowledgeTypes.PositiveArrival;

        // Send the message.
        queue.Send(msg, "Example Message Label");

        // Get the message's Id property value.
        string id = msg.Id;

        // Receive the message from the queue.
        msg = queue.ReceiveById(id, TimeSpan.FromSeconds(10.0));

        // Connect to the admin queue.
        MessageQueue adminQueue = new MessageQueue(".\\exampleAdminQueue");

        // Set the admin queue's MessageReadPropertyFilter property to ensure
        // that the acknowledgement message includes the desired properties.
        adminQueue.MessageReadPropertyFilter.Acknowledgment = true;
        adminQueue.MessageReadPropertyFilter.CorrelationId = true;

        // Peek at the acknowledgement message.
        Message ackMsg = adminQueue.PeekByCorrelationId(id,
            TimeSpan.FromSeconds(10.0));

        // Display the acknowledgement message's property values.
        Console.WriteLine("Message.Label: {0}", ackMsg.Label);
        Console.WriteLine("Message.Acknowledgment: {0}", ackMsg.Acknowledgment);
        Console.WriteLine("Message.CorrelationId: {0}", ackMsg.CorrelationId);

        // </snippet5>
    }

    public void PeekById_String()
    {
        // <snippet6>

        // Connect to a queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleQueue");

        // Create a new message.
        Message msg = new Message("Example Message Body");

        // Send the message.
        queue.Send(msg, "Example Message Label");

        // Get the message's Id property value.
        string id = msg.Id;

        // Simulate doing other work so the message has time to arrive.
        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(10.0));

        // Peek at the message.
        msg = queue.PeekById(id);

        // </snippet6>
    }

    public void PeekById_StringTimespan()
    {
        // <snippet7>

        // Connect to a queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleQueue");

        // Create a new message.
        Message msg = new Message("Example Message Body");

        // Send the message.
        queue.Send(msg, "Example Message Label");

        // Get the message's Id property value.
        string id = msg.Id;

        // Peek at the message.
        msg = queue.PeekById(id, TimeSpan.FromSeconds(10.0));

        // </snippet7>
    }

    public void Receive_TimespanTransactiontype()
    {
        // <snippet8>

        // Connect to a transactional queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleTransQueue");

        // Create a new message.
        Message msg = new Message("Example Message Body");

        // Send the message.
        queue.Send(msg, MessageQueueTransactionType.Single);

        // Set the formatter to indicate the message body contains a String.
        queue.Formatter = new XmlMessageFormatter(new Type[]
            {typeof(String)});

        // Receive the message from the queue. Because the Id of the message
        // is not specified, it might not be the message just sent.
        msg = queue.Receive(TimeSpan.FromSeconds(10.0),
            MessageQueueTransactionType.Single);

        // </snippet8>
    }

    public void Receive_Transactiontype()
    {
        // <snippet9>

        // Connect to a transactional queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleTransQueue");

        // Create a new message.
        Message msg = new Message("Example Message Body");

        // Send the message.
        queue.Send(msg, MessageQueueTransactionType.Single);

        // Simulate doing other work so the message has time to arrive.
        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(10.0));

        // Set the formatter to indicate the message body contains a String.
        queue.Formatter = new XmlMessageFormatter(new Type[]
            {typeof(String)});

        // Receive the message from the queue.  Because the Id of the message
        // , it might not be the message just sent.
        msg = queue.Receive(MessageQueueTransactionType.Single); 

        // </snippet9>
    }

    public void ReceiveByCorrelationId_StringTimespan()
    {
        // <snippet10>

        // Connect to a queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleQueue");

        // Create a new message.
        Message msg = new Message("Example Message Body");

        // Designate a queue to receive the acknowledgement message for this
        // message.
        msg.AdministrationQueue = new MessageQueue(".\\exampleAdminQueue");

        // Set the message to generate an acknowledgement message upon its
        // arrival.
        msg.AcknowledgeType = AcknowledgeTypes.PositiveArrival;

        // Send the message.
        queue.Send(msg, "Example Message Label");

        // Get the message's Id property value.
        string id = msg.Id;

        // Receive the message from the queue.
        msg = queue.ReceiveById(id, TimeSpan.FromSeconds(10.0));

        // Connect to the admin queue.
        MessageQueue adminQueue = new MessageQueue(".\\exampleAdminQueue");

        // Set the admin queue's MessageReadPropertyFilter property to ensure
        // that the acknowledgement message includes the desired properties.
        adminQueue.MessageReadPropertyFilter.Acknowledgment = true;
        adminQueue.MessageReadPropertyFilter.CorrelationId = true;

        // Receive the acknowledgement message from the admin queue.
        Message ackMsg = adminQueue.ReceiveByCorrelationId(id,
            TimeSpan.FromSeconds(10.0));

        // Display the acknowledgement message's property values.
        Console.WriteLine("Message.Label: {0}", ackMsg.Label);
        Console.WriteLine("Message.Acknowledgment: {0}", ackMsg.Acknowledgment);
        Console.WriteLine("Message.CorrelationId: {0}", ackMsg.CorrelationId);

        // </snippet10>
    }

    public void ReceiveByCorrelationId_StringTransactiontype()
    {
        // <snippet11>

        // Connect to a nontransactional queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleQueue");

        // Create a new message.
        Message msg = new Message("Example Message Body");

        // Send the message to the nontransactional queue.
        queue.Send(msg, "Example Message Label");

        // Get the message's Id property value.
        string id = msg.Id;

        // Receive the message from the nontransactional queue.
        msg = queue.ReceiveById(id, TimeSpan.FromSeconds(10.0));

        // Connect to a transactional queue on the local computer.
        MessageQueue transQueue = new MessageQueue(".\\exampleTransQueue");

        // Create a new message in response to the original message.
        Message responseMsg = new Message("Example Response Message Body");

        // Set the response message's CorrelationId property value to the Id
        // property value of the original message.
        responseMsg.CorrelationId = id;

        // Send the response message to the transactional queue.
        transQueue.Send(responseMsg, "Example Response Message Label",
            MessageQueueTransactionType.Single);

        // Simulate doing other work so the message has time to arrive.
        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(10.0));

        // Set the transactional queue's MessageReadPropertyFilter property to
        // ensure that the response message includes the desired properties.
        transQueue.MessageReadPropertyFilter.CorrelationId = true;

        // Receive the response message from the transactional queue.
        responseMsg = transQueue.ReceiveByCorrelationId(id,
            MessageQueueTransactionType.Single);

        // Display the response message's property values.
        Console.WriteLine("Message.Label: {0}", responseMsg.Label);
        Console.WriteLine("Message.CorrelationId: {0}",
            responseMsg.CorrelationId);

        // </snippet11>
    }

    public void ReceiveByCorrelationId_StringTimespanTransactiontype()
    {
        // <snippet12>

        // Connect to a nontransactional queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleQueue");

        // Create a new message.
        Message msg = new Message("Example Message Body");

        // Send the message to the nontransactional queue.
        queue.Send(msg, "Example Message Label");

        // Get the message's Id property value.
        string id = msg.Id;

        // Receive the message from the nontransactional queue.
        msg = queue.ReceiveById(id, TimeSpan.FromSeconds(10.0));

        // Connect to a transactional queue on the local computer.
        MessageQueue transQueue = new MessageQueue(".\\exampleTransQueue");

        // Create a new message in response to the original message.
        Message responseMsg = new Message("Example Response Message Body");

        // Set the response message's CorrelationId property value to the Id
        // property value of the original message.
        responseMsg.CorrelationId = id;

        // Send the response message to the transactional queue.
        transQueue.Send(responseMsg, "Example Response Message Label",
            MessageQueueTransactionType.Single);

        // Set the transactional queue's MessageReadPropertyFilter property to
        // ensure that the response message includes the desired properties.
        transQueue.MessageReadPropertyFilter.CorrelationId = true;

        // Receive the response message from the transactional queue.
        responseMsg = transQueue.ReceiveByCorrelationId(id,
            TimeSpan.FromSeconds(10.0), MessageQueueTransactionType.Single);

        // Display the response message's property values.
        Console.WriteLine("Message.Label: {0}", responseMsg.Label);
        Console.WriteLine("Message.CorrelationId: {0}",
            responseMsg.CorrelationId);

        // </snippet12>
    }

    public void ReceiveByCorrelationId_StringTimespanTransaction()
    {
        // <snippet13>

        // Connect to a nontransactional queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleQueue");

        // Create a new message.
        Message msg = new Message("Example Message Body");

        // Send the message to the nontransactional queue.
        queue.Send(msg, "Example Message Label");

        // Get the message's Id property value.
        string id = msg.Id;

        // Receive the message from the nontransactional queue.
        msg = queue.ReceiveById(id, TimeSpan.FromSeconds(10.0));

        // Connect to a transactional queue on the local computer.
        MessageQueue transQueue = new MessageQueue(".\\exampleTransQueue");

        // Create a new message in response to the original message.
        Message responseMsg = new Message("Example Response Message Body");

        // Set the response message's CorrelationId property value to the Id
        // property value of the original message.
        responseMsg.CorrelationId = id;

        // Send the response message to the transactional queue.
        transQueue.Send(responseMsg, "Example Response Message Label",
            MessageQueueTransactionType.Single);

        // Set the transactional queue's MessageReadPropertyFilter property to
        // ensure that the response message includes the desired properties.
        transQueue.MessageReadPropertyFilter.CorrelationId = true;

        // Create a message queuing transaction.
        MessageQueueTransaction transaction = new MessageQueueTransaction();

        try
        {
            // Begin a transaction.
            transaction.Begin();

            // Receive the response message from the transactional queue.
            responseMsg = transQueue.ReceiveByCorrelationId(id,
                TimeSpan.FromSeconds(10.0), transaction);

            // Commit the transaction.
            transaction.Commit();
        }
        catch(System.Exception e)
        {
            // Cancel the transaction.
            transaction.Abort();

            // Propagate the exception.
            throw e;
        }
        finally
        {
            // Dispose of the transaction object.
            transaction.Dispose();
        }

        // Display the response message's property values.
        Console.WriteLine("Message.Label: {0}", responseMsg.Label);
        Console.WriteLine("Message.CorrelationId: {0}",
            responseMsg.CorrelationId);

        // </snippet13>
    }

    public void ReceiveByCorrelationId_StringTransaction()
    {
        // <snippet14>

        // Connect to a nontransactional queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleQueue");

        // Create a new message.
        Message msg = new Message("Example Message Body");

        // Send the message to the nontransactional queue.
        queue.Send(msg, "Example Message Label");

        // Get the message's Id property value.
        string id = msg.Id;

        // Receive the message from the nontransactional queue.
        msg = queue.ReceiveById(id, TimeSpan.FromSeconds(10.0));

        // Connect to a transactional queue on the local computer.
        MessageQueue transQueue = new MessageQueue(".\\exampleTransQueue");

        // Create a new message in response to the original message.
        Message responseMsg = new Message("Example Response Message Body");

        // Set the response message's CorrelationId property value to the Id
        // property value of the original message.
        responseMsg.CorrelationId = id;

        // Send the response message to the transactional queue.
        transQueue.Send(responseMsg, "Example Response Message Label",
            MessageQueueTransactionType.Single);

        // Simulate doing other work so the message has time to arrive.
        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(10.0));

        // Set the transactional queue's MessageReadPropertyFilter property to
        // ensure that the response message includes the desired properties.
        transQueue.MessageReadPropertyFilter.CorrelationId = true;

        // Create a message queuing transaction.
        MessageQueueTransaction transaction = new MessageQueueTransaction();

        try
        {
            // Begin a transaction.
            transaction.Begin();

            // Receive the response message from the transactional queue.
            responseMsg = transQueue.ReceiveByCorrelationId(id, transaction);

            // Commit the transaction.
            transaction.Commit();
        }
        catch(System.Exception e)
        {
            // Cancel the transaction.
            transaction.Abort();

            // Propagate the exception.
            throw e;
        }
        finally
        {
            // Dispose of the transaction object.
            transaction.Dispose();
        }

        // Display the response message's property values.
        Console.WriteLine("Message.Label: {0}", responseMsg.Label);
        Console.WriteLine("Message.CorrelationId: {0}",
            responseMsg.CorrelationId);

        // </snippet14>
    }

    public void ReceiveById_StringTransactionType()
    {
        // <snippet15>

        // Connect to a transactional queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleTransQueue");

        // Create a new message.
        Message msg = new Message("Example Message Body");

        // Send the message.
        queue.Send(msg, "Example Message Label",
            MessageQueueTransactionType.Single);

        // Get the message's Id property value.
        string id = msg.Id;

        // Simulate doing other work so the message has time to arrive.
        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(10.0));

        // Receive the message from the queue.
        msg = queue.ReceiveById(id, MessageQueueTransactionType.Single);

        // </snippet15>
    }

    public void ReceiveById_String()
    {
        // <snippet16>

        // Connect to a queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleQueue");

        // Create a new message.
        Message msg = new Message("Example Message Body");

        // Send the message.
        queue.Send(msg, "Example Message Label");

        // Get the message's Id property value.
        string id = msg.Id;

        // Simulate doing other work so the message has time to arrive.
        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(10.0));

        // Receive the message from the queue.
        msg = queue.ReceiveById(id);

        // </snippet16>
    }

    public void ReceiveById_StringTransaction()
    {
        // <snippet17>

        // Connect to a transactional queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleTransQueue");

        // Create a new message.
        Message msg = new Message("Example Message Body");

        // Send the message.
        queue.Send(msg, "Example Message Label",
            MessageQueueTransactionType.Single);

        // Get the message's Id property value.
        string id = msg.Id;

        // Simulate doing other work so the message has time to arrive.
        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(10.0));

        // Create a message queuing transaction.
        MessageQueueTransaction transaction = new MessageQueueTransaction();

        try
        {
            // Begin a transaction.
            transaction.Begin();

            // Receive the message from the queue.
            msg = queue.ReceiveById(id, transaction);

            // Commit the transaction.
            transaction.Commit();
        }
        catch(System.Exception e)
        {
            // Cancel the transaction.
            transaction.Abort();

            // Propagate the exception.
            throw e;
        }
        finally
        {
            // Dispose of the transaction object.
            transaction.Dispose();
        }

        // </snippet17>
    }

    public void ReceiveById_StringTimespanTransaction()
    {
        // <snippet18>

        // Connect to a transactional queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleTransQueue");

        // Create a new message.
        Message msg = new Message("Example Message Body");

        // Send the message.
        queue.Send(msg, "Example Message Label",
            MessageQueueTransactionType.Single);

        // Get the message's Id property value.
        string id = msg.Id;

        // Create a message queuing transaction.
        MessageQueueTransaction transaction = new MessageQueueTransaction();

        try
        {
            // Begin a transaction.
            transaction.Begin();

            // Receive the message from the queue.
            msg = queue.ReceiveById(id, TimeSpan.FromSeconds(10.0),
                transaction);

            // Commit the transaction.
            transaction.Commit();
        }
        catch(System.Exception e)
        {
            // Cancel the transaction.
            transaction.Abort();

            // Propagate the exception.
            throw e;
        }
        finally
        {
            // Dispose of the transaction object.
            transaction.Dispose();
        }

        // </snippet18>
    }

    public void ReceiveById_StringTimespanTransactiontype()
    {
        // <snippet19>

        // Connect to a transactional queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleTransQueue");

        // Create a new message.
        Message msg = new Message("Example Message Body");

        // Send the message.
        queue.Send(msg, "Example Message Label",
            MessageQueueTransactionType.Single);

        // Get the message's Id property value.
        string id = msg.Id;

        // Receive the message from the queue.
        msg = queue.ReceiveById(id, TimeSpan.FromSeconds(10.0),
            MessageQueueTransactionType.Single);

        // </snippet19>
    }

    public void ReceiveById_StringTimespan()
    {
        // <snippet20>

        // Connect to a queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleQueue");

        // Create a new message.
        Message msg = new Message("Example Message Body");

        // Send the message.
        queue.Send(msg, "Example Message Label");

        // Get the message's Id property value.
        string id = msg.Id;

        // Receive the message from the queue.
        msg = queue.ReceiveById(id, TimeSpan.FromSeconds(10.0));

        // </snippet20>
    }

    public void GetAllMessages()
    {
        // <snippet21>

        // Connect to a queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleQueue");

        // Populate an array with copies of all the messages in the queue.
        Message[] msgs = queue.GetAllMessages();

        // Loop through the messages.
        foreach(Message msg in msgs)
        {
            // Display the label of each message.
            Console.WriteLine(msg.Label);
        }

        // </snippet21>
    }

        public void GetEnumerator()
    {
        // <snippet22>

        // Connect to a queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleQueue");

        // Get an IEnumerator object.
        System.Collections.IEnumerator enumerator = queue.GetEnumerator();

        // Use the IEnumerator object to loop through the messages.
        while(enumerator.MoveNext())
        {
            // Get a message from the enumerator.
            Message msg = (Message)enumerator.Current;

            // Display the label of the message.
            Console.WriteLine(msg.Label);
        }

        // </snippet22>
    }

    public void SetPermissions_StringAccessrights()
    {
        // <snippet23>

        // Connect to a queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleQueue");

        // Grant all users in the "Everyone" user group the right to receive
        // messages from the queue.
        queue.SetPermissions("Everyone", MessageQueueAccessRights.ReceiveMessage);

        // </snippet23>
    }

    public void SetPermissions_Accesscontrolentry()
    {
        // <snippet24>

        // Connect to a queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleQueue");

        // Create a new trustee to represent the "Everyone" user group.
        Trustee tr = new Trustee("Everyone");

        // Create a MessageQueueAccessControlEntry, granting the trustee the
        // right to receive messages from the queue.
        MessageQueueAccessControlEntry entry = new
            MessageQueueAccessControlEntry(
            tr, MessageQueueAccessRights.ReceiveMessage,
            AccessControlEntryType.Allow);

        // Apply the MessageQueueAccessControlEntry to the queue.
        queue.SetPermissions(entry);

        // </snippet24>
    }

    public void SetPermissions_StringAccessrightsAccesscontrolentrytype()
    {
        // <snippet25>

        // Connect to a queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleQueue");

        // Grant all users in the "Everyone" user group the right to receive
        // messages from the queue.
        queue.SetPermissions("Everyone", MessageQueueAccessRights.ReceiveMessage,
            AccessControlEntryType.Allow);

        // </snippet25>
    }

    public void SetPermissions_Accesscontrollist()
    {
        // <snippet26>

        // Connect to a queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleQueue");

        // Create an AccessControlList.
        AccessControlList list = new AccessControlList();

        // Create a new trustee to represent the "Everyone" user group.
        Trustee tr = new Trustee("Everyone");

        // Create an AccessControlEntry, granting the trustee read access to
        // the queue.
        AccessControlEntry entry = new AccessControlEntry(
            tr, GenericAccessRights.Read,
            StandardAccessRights.Read,
            AccessControlEntryType.Allow);

        // Add the AccessControlEntry to the AccessControlList.
        list.Add(entry);

        // Apply the AccessControlList to the queue.
        queue.SetPermissions(list);

        // </snippet26>
    }

    public void ResetPermissions()
    {
        // <snippet27>

        // Connect to a queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleQueue");

        // Reset the queue's permission list to its default values.
        queue.ResetPermissions();

        // </snippet27>
    }

    public void Refresh()
    {
        // <snippet28>

        // Connect to a queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleQueue");

        // Refresh the queue's property values to obtain its current state.
        queue.Refresh();

        // </snippet28>
    }

    public void Purge()
    {
        // <snippet29>

        // Connect to a queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleQueue");

        // Delete all messages from the queue.
        queue.Purge();

        // </snippet29>
    }
}

// </snippet0>

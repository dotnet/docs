// <snippet0>
#using <System.dll>
#using <System.Messaging.dll>

using namespace System;
using namespace System::Messaging;

namespace MessagePropertyFilterExample
{
    public ref class Order
    {
    private:
        int orderIdValue;
        DateTime orderTimeValue;

    public:

        property int OrderId 
        {
            int get()
            {
	            return orderIdValue;
            }

            void set(int value)
            {
	            orderIdValue = value;
            }
        }

        property DateTime OrderTime 
        {
	        DateTime get()
	        {
		        return orderTimeValue;
	        }

	        void set(DateTime value)
	        {
		        orderTimeValue = value;
	        }

        }
    };

    public ref class OrderProcessor
    {
    public:

        // Creates a new queue->
        static void CreateQueue(String^ queuePath, 
            bool transactional)
        {
            if (!MessageQueue::Exists(queuePath))
            {
                MessageQueue::Create(queuePath, transactional);
            }
            else
            {
                Console::WriteLine("{0} already exists.", queuePath);
            }
        }

        // Sends an Order to a queue->
        void SendMessage()
        {    
            // Create a new order and set values.
            Order^ sentOrder = gcnew Order;
            sentOrder->OrderId = 3;
            sentOrder->OrderTime = DateTime::Now;
            
            // Connect to a queue on the local computer.
            MessageQueue^ queue = 
                gcnew MessageQueue(".\\orderQueue");
            
            // Create the new order.
            Message^ orderMessage = gcnew Message(sentOrder);
            
            // Label the message.
            orderMessage->Label = "Order Message";
            
            // Send the order to the queue->
            queue->Send(orderMessage);
        }

        // Receives a message containing an order.
        void ReceiveMessage()
        {     
            // Connect to the a queue on the local computer.
            MessageQueue^ queue = 
                gcnew MessageQueue(".\\orderQueue");
            
            // Set the formatter to indicate 
            // the message body contains an order.
	        array <Type^> ^targetTypes = gcnew array<Type^>(1);
            targetTypes[0] = Order::typeid;
            queue->Formatter = 
                gcnew XmlMessageFormatter(targetTypes);
            
            // Declare the message.
            Message^ orderMessage;
            
            // <snippet1>
            // Set the queue's MessageReadPropertyFilter property 
            // to enable the message's AcknowledgeType property.
            queue->MessageReadPropertyFilter->
                AcknowledgeType = true;
            
            // Peek at the message. Time out after ten seconds 
            // in case the message was not delivered.
            orderMessage = queue->Peek(TimeSpan::FromSeconds(10.0));
            
            // Display the value of the message's 
            // AcknowledgeType property.
            Console::WriteLine("Message.AcknowledgeType: {0}", 
                orderMessage->AcknowledgeType);
            
            // </snippet1>
            // <snippet2>
            // Set the queue's MessageReadPropertyFilter property 
            // to enable the message's AdministrationQueue property.
            queue->MessageReadPropertyFilter->
                AdministrationQueue = true;
            
            // Peek at the message. Time out after ten seconds 
            // in case the message was not delivered.
            orderMessage = queue->Peek(TimeSpan::FromSeconds(10.0));
            
            // Display the value of the message's 
            // AdministrationQueue property.
            Console::WriteLine("Message.AdministrationQueue: {0}", 
                orderMessage->AdministrationQueue);
            
            // </snippet2>
            // <snippet3>
            // Set the queue's MessageReadPropertyFilter property 
            // to enable the message's AppSpecific property.
            queue->MessageReadPropertyFilter->AppSpecific = true;
            
            // Peek at the message. Time out after ten seconds 
            // in case the message was not delivered.
            orderMessage = queue->Peek(TimeSpan::FromSeconds(10.0));
            
            // Display the value of the message's 
            // AppSpecific property.
            Console::WriteLine("Message.AppSpecific: {0}", 
                orderMessage->AppSpecific);
            
            // </snippet3>
            // <snippet4>
            // Set the queue's MessageReadPropertyFilter property 
            // to enable the message's ArrivedTime property.
            queue->MessageReadPropertyFilter->ArrivedTime = true;
            
            // Peek at the message. Time out after ten seconds 
            // in case the message was not delivered.
            orderMessage = queue->Peek(TimeSpan::FromSeconds(10.0));
            
            // Display the value of the message's 
            // ArrivedTime property.
            Console::WriteLine("Message.ArrivedTime: {0}", 
                orderMessage->ArrivedTime);
            
            // </snippet4>
            // <snippet5>
            // Set the queue's MessageReadPropertyFilter property 
            // to enable the message's AttachSenderId property.
            queue->MessageReadPropertyFilter->AttachSenderId = true;
            
            // Peek at the message. Time out after ten seconds 
            // in case the message was not delivered.
            orderMessage = queue->Peek(TimeSpan::FromSeconds(10.0));
            
            // Display the value of the message's 
            // AttachSenderId property.
            Console::WriteLine("Message.AttachSenderId: {0}", 
                orderMessage->AttachSenderId);
            
            // </snippet5>
            // <snippet6>
            // Set the queue's MessageReadPropertyFilter property 
            // to enable the message's Authenticated property.
            queue->MessageReadPropertyFilter->Authenticated = true;
            
            // Peek at the message. Time out after ten seconds 
            // in case the message was not delivered.
            orderMessage = queue->Peek(TimeSpan::FromSeconds(10.0));
            
            // Display the value of the message's 
            // Authenticated property.
            Console::WriteLine("Message.Authenticated: {0}", 
                orderMessage->Authenticated);
            
            // </snippet6>
            // <snippet7>
            // Set the queue's MessageReadPropertyFilter property 
            // to enable the message's 
            // AuthenticationProviderName property.
            queue->MessageReadPropertyFilter->
                AuthenticationProviderName = true;
            
            // Peek at the message. Time out after ten seconds 
            // in case the message was not delivered.
            orderMessage = queue->Peek(TimeSpan::FromSeconds(10.0));
            
            // Display the value of the message's 
            // AuthenticationProviderName property.
            Console::WriteLine(
                "Message.AuthenticationProviderName: {0}", 
                orderMessage->AuthenticationProviderName);
            
            // </snippet7>
            // <snippet8>
            // Set the queue's MessageReadPropertyFilter property 
            // to enable the message's 
            // AuthenticationProviderType property.
            queue->MessageReadPropertyFilter->
                AuthenticationProviderType = true;
            
            // Peek at the message. Time out after ten seconds 
            // in case the message was not delivered.
            orderMessage = queue->Peek(TimeSpan::FromSeconds(10.0));
            
            // Display the value of the message's 
            // AuthenticationProviderType property.
            Console::WriteLine(
                "Message.AuthenticationProviderType: {0}", 
                orderMessage->AuthenticationProviderType);
            
            // </snippet8>
            // <snippet9>
            // Set the queue's MessageReadPropertyFilter property 
            // to enable the message's Body property.
            queue->MessageReadPropertyFilter->Body = true;
            
            // Peek at the message. Time out after ten seconds 
            // in case the message was not delivered.
            orderMessage = queue->Peek(TimeSpan::FromSeconds(10.0));
            
            // Display the value of the message's Body property.
            Console::WriteLine("Message.Body: {0}", 
                orderMessage->Body);
            
            // </snippet9>
            // <snippet10>
            // Set the queue's MessageReadPropertyFilter property 
            // to enable the message's ConnectorType property.
            queue->MessageReadPropertyFilter->ConnectorType = true;
            
            // Peek at the message. Time out after ten seconds 
            // in case the message was not delivered.
            orderMessage = queue->Peek(TimeSpan::FromSeconds(10.0));
            
            // Display the value of the message's 
            // ConnectorType property.
            Console::WriteLine("Message.ConnectorType: {0}", 
                orderMessage->ConnectorType);
            
            // </snippet10>
            // <snippet11>
            // Set the filter's DefaultBodySize 
            // property to 2048 bytes.
            queue->MessageReadPropertyFilter->
                DefaultBodySize = 2048;
            
            // Display the new value of the filter's 
            // DefaultBodySize property.
            Console::WriteLine(
                "MessageReadPropertyFilter.DefaultBodySize: {0}", 
                queue->MessageReadPropertyFilter->DefaultBodySize);
            
            // </snippet11>
            // <snippet12>
            // Set the filter's DefaultExtensionSize
            // property to 1024 bytes.
            queue->MessageReadPropertyFilter->
                DefaultExtensionSize = 1024;
            
            // Display the new value of the filter's 
            // DefaultExtensionSize property.
            Console::WriteLine(
                "MessageReadPropertyFilter."
                "DefaultExtensionSize: {0}", 
                queue->MessageReadPropertyFilter->
                DefaultExtensionSize);
            
            // </snippet12>
            // <snippet13>
            // Set the filter's DefaultLabelSize 
            // property to 1024 bytes.
            queue->MessageReadPropertyFilter->
                DefaultLabelSize = 1024;
            
            // Display the new value of the filter's 
            // DefaultLabelSize property.
            Console::WriteLine(
                "MessageReadPropertyFilter.DefaultLabelSize: {0}", 
                queue->MessageReadPropertyFilter->DefaultLabelSize);
            
            // </snippet13>
            // <snippet14>
            // Set the queue's MessageReadPropertyFilter property 
            // to enable the message's DestinationQueue property.
            queue->MessageReadPropertyFilter->
                DestinationQueue = true;
            
            // Peek at the message. Time out after ten seconds 
            // in case the message was not delivered.
            orderMessage = queue->Peek(TimeSpan::FromSeconds(10.0));
            
            // Display the value of the message's 
            // Destinationqueue->QueueName property.
            Console::WriteLine(
                "Message.Destinationqueue->QueueName: {0}", 
                orderMessage->DestinationQueue->QueueName);
            
            // </snippet14>
            // <snippet15>
            // Set the queue's MessageReadPropertyFilter property 
            // to enable the message's 
            // DestinationSymmetricKey property.
            queue->MessageReadPropertyFilter->
                DestinationSymmetricKey = true;
            
            // Peek at the message. Time out after ten seconds 
            // in case the message was not delivered.
            orderMessage = queue->Peek(TimeSpan::FromSeconds(10.0));
            
            // Display the value of the message's 
            // DestinationSymmetricKey property.
            Console::WriteLine(
                "Message.DestinationSymmetricKey: {0}", 
                orderMessage->DestinationSymmetricKey);
            
            // </snippet15>
            // <snippet16>
            // Set the queue's MessageReadPropertyFilter property 
            // to enable the message's DigitalSignature property.
            queue->MessageReadPropertyFilter->
                DigitalSignature = true;
            
            // Peek at the message. Time out after ten seconds 
            // in case the message was not delivered.
            orderMessage = queue->Peek(TimeSpan::FromSeconds(10.0));
            
            // Display the value of the message's 
            // DigitalSignature property.
            Console::WriteLine("Message.DigitalSignature: {0}", 
                orderMessage->DigitalSignature);
            
            // </snippet16>
            // <snippet17>
            // Set the queue's MessageReadPropertyFilter property 
            // to enable the message's EncryptionAlgorithm property.
            queue->MessageReadPropertyFilter->
                EncryptionAlgorithm = true;
            
            // Peek at the message. Time out after ten seconds 
            // in case the message was not delivered.
            orderMessage = queue->Peek(TimeSpan::FromSeconds(10.0));
            
            // Display the value of the message's 
            // EncryptionAlgorithm property.
            Console::WriteLine("Message.EncryptionAlgorithm: {0}", 
                orderMessage->EncryptionAlgorithm);
            
            // </snippet17>
            // <snippet18>
            // Set the queue's MessageReadPropertyFilter property 
            // to enable the message's Extension property.
            queue->MessageReadPropertyFilter->Extension = true;
            
            // Peek at the message. Time out after ten seconds 
            // in case the message was not delivered.
            orderMessage = queue->Peek(TimeSpan::FromSeconds(10.0));
            
            // Display the value of the message's Extension property.
            Console::WriteLine("Message.Extension: {0}", 
                orderMessage->Extension);
            
            // </snippet18>
            // <snippet19>
            // Set the queue's MessageReadPropertyFilter property 
            // to enable the message's HashAlgorithm property.
            queue->MessageReadPropertyFilter->HashAlgorithm = true;
            
            // Peek at the message. Time out after ten seconds 
            // in case the message was not delivered.
            orderMessage = queue->Peek(TimeSpan::FromSeconds(10.0));
            
            // Display the value of the message's 
            // HashAlgorithm property.
            Console::WriteLine("Message.HashAlgorithm: {0}", 
                orderMessage->HashAlgorithm);
            
            // </snippet19>
            // <snippet20>
            // Set the queue's MessageReadPropertyFilter property 
            // to enable the message's Id property.
            queue->MessageReadPropertyFilter->Id = true;
            
            // Peek at the message. Time out after ten seconds 
            // in case the message was not delivered.
            orderMessage = queue->Peek(TimeSpan::FromSeconds(10.0));
            
            // Display the value of the message's Id property.
            Console::WriteLine("Message.Id: {0}", orderMessage->Id);
            
            // </snippet20>
            // <snippet21>
            // Set the queue's MessageReadPropertyFilter property 
            // to enable the message's Label property.
            queue->MessageReadPropertyFilter->Label = true;
            
            // Peek at the message. Time out after ten seconds 
            // in case the message was not delivered.
            orderMessage = queue->Peek(TimeSpan::FromSeconds(10.0));
            
            // Display the value of the message's Label property.
            Console::WriteLine("Message.Label: {0}", 
                orderMessage->Label);
            
            // </snippet21>
            // <snippet22>
            // Set the queue's MessageReadPropertyFilter property 
            // to enable the message's MessageType property.
            queue->MessageReadPropertyFilter->MessageType = true;
            
            // Peek at the message. Time out after ten seconds 
            // in case the message was not delivered.
            orderMessage = queue->Peek(TimeSpan::FromSeconds(10.0));
            
            // Display the value of the message's 
            // MessageType property.
            Console::WriteLine("Message.MessageType: {0}", 
                orderMessage->MessageType);
            
            // </snippet22>
            // <snippet23>
            // Set the queue's MessageReadPropertyFilter property 
            // to enable the message's Recoverable property.
            queue->MessageReadPropertyFilter->Recoverable = true;
            
            // Peek at the message. Time out after ten seconds 
            // in case the message was not delivered.
            orderMessage = queue->Peek(TimeSpan::FromSeconds(10.0));
            
            // Display the value of the message's 
            // Recoverable property.
            Console::WriteLine("Message.Recoverable: {0}", 
                orderMessage->Recoverable);
            
            // </snippet23>
            // <snippet24>
            // Set the queue's MessageReadPropertyFilter property 
            // to enable the message's ResponseQueue property.
            queue->MessageReadPropertyFilter->ResponseQueue = true;
            
            // Peek at the message. Time out after ten seconds 
            // in case the message was not delivered.
            orderMessage = queue->Peek(TimeSpan::FromSeconds(10.0));
            
            // Display the value of the message's 
            // Responsequeue->QueueName property.
            if (orderMessage->ResponseQueue != nullptr)
            {
                Console::WriteLine(
                    "Message.Responsequeue->QueueName: {0}", 
                    orderMessage->ResponseQueue->QueueName);
            }
            
            // </snippet24>
            // <snippet25>
            // Set the queue's MessageReadPropertyFilter property 
            // to enable the message's SenderCertificate property.
            queue->MessageReadPropertyFilter->
                SenderCertificate = true;
            
            // Peek at the message. Time out after ten seconds 
            // in case the message was not delivered.
            orderMessage = queue->Peek(TimeSpan::FromSeconds(10.0));
            
            // Display the value of the message's 
            // SenderCertificate property.
            Console::WriteLine("Message.SenderCertificate: {0}", 
                orderMessage->SenderCertificate);
            
            // </snippet25>
            // <snippet26>
            // Set the queue's MessageReadPropertyFilter property 
            // to enable the message's SenderId property.
            queue->MessageReadPropertyFilter->SenderId = true;
            
            // Peek at the message. Time out after ten seconds 
            // in case the message was not delivered.
            orderMessage = queue->Peek(TimeSpan::FromSeconds(10.0));
            
            // Display the value of the message's SenderId property.
            Console::WriteLine("Message.SenderId: {0}", 
                orderMessage->SenderId);
            
            // </snippet26>
            // <snippet27>
            // Set the queue's MessageReadPropertyFilter property 
            // to enable the message's SenderVersion property.
            queue->MessageReadPropertyFilter->SenderVersion = true;
            
            // Peek at the message. Time out after ten seconds 
            // in case the message was not delivered.
            orderMessage = queue->Peek(TimeSpan::FromSeconds(10.0));
            
            // Display the value of the message's 
            // SenderVersion property.
            Console::WriteLine("Message.SenderVersion: {0}", 
                orderMessage->SenderVersion);
            
            // </snippet27>
            // <snippet28>
            // Set the queue's MessageReadPropertyFilter property 
            // to enable the message's SentTime property.
            queue->MessageReadPropertyFilter->SentTime = true;
            
            // Peek at the message. Time out after ten seconds 
            // in case the message was not delivered.
            orderMessage = queue->Peek(TimeSpan::FromSeconds(10.0));
            
            // Display the value of the message's SentTime property.
            Console::WriteLine("Message.SentTime: {0}", 
                orderMessage->SentTime);
            
            // </snippet28>
            // <snippet29>
            // Set the queue's MessageReadPropertyFilter property 
            // to enable the message's SourceMachine property.
            queue->MessageReadPropertyFilter->SourceMachine = true;
            
            // Peek at the message. Time out after ten seconds 
            // in case the message was not delivered.
            orderMessage = queue->Peek(TimeSpan::FromSeconds(10.0));
            
            // Display the value of the message's 
            // SourceMachine property.
            Console::WriteLine("Message.SourceMachine: {0}", 
                orderMessage->SourceMachine);
            
            // </snippet29>
            // <snippet30>
            // Set the queue's MessageReadPropertyFilter property 
            // to enable the message's TimeToBeReceived property.
            queue->MessageReadPropertyFilter->
                TimeToBeReceived = true;
            
            // Peek at the message. Time out after ten seconds 
            // in case the message was not delivered.
            orderMessage = queue->Peek(TimeSpan::FromSeconds(10.0));
            
            // Display the value of the message's 
            // TimeToBeReceived property.
            Console::WriteLine("Message.TimeToBeReceived: {0}", 
                orderMessage->TimeToBeReceived);
            
            // </snippet30>
            // <snippet31>
            // Set the queue's MessageReadPropertyFilter property 
            // to enable the message's TimeToReachQueue property.
            queue->MessageReadPropertyFilter->
                TimeToReachQueue = true;
            
            // Peek at the message. Time out after ten seconds 
            // in case the message was not delivered.
            orderMessage = queue->Peek(TimeSpan::FromSeconds(10.0));
            
            // Display the value of the message's 
            // TimeToReachQueue property.
            Console::WriteLine("Message.TimeToReachQueue: {0}", 
                orderMessage->TimeToReachQueue);
            
            // </snippet31>
            // <snippet32>
            // Set the queue's MessageReadPropertyFilter property 
            // to enable the message's UseAuthentication property.
            queue->MessageReadPropertyFilter->
                UseAuthentication = true;
            
            // Peek at the message. Time out after ten seconds 
            // in case the message was not delivered.
            orderMessage = queue->Peek(TimeSpan::FromSeconds(10.0));
            
            // Display the value of the message's 
            // UseAuthentication property.
            Console::WriteLine("Message.UseAuthentication: {0}", 
                orderMessage->UseAuthentication);
            
            // </snippet32>
            // <snippet33>
            // Set the queue's MessageReadPropertyFilter property 
            // to enable the message's UseDeadLetterQueue property.
            queue->MessageReadPropertyFilter->
                UseDeadLetterQueue = true;
            
            // Peek at the message. Time out after ten seconds 
            // in case the message was not delivered.
            orderMessage = queue->Peek(TimeSpan::FromSeconds(10.0));
            
            // Display the value of the message's 
            // UseDeadLetterQueue property.
            Console::WriteLine("Message.UseDeadLetterQueue: {0}", 
                orderMessage->UseDeadLetterQueue);
            
            // </snippet33>
            // <snippet34>
            // Set the queue's MessageReadPropertyFilter property 
            // to enable the message's UseEncryption property.
            queue->MessageReadPropertyFilter->UseEncryption = true;
            
            // Peek at the message. Time out after ten seconds 
            // in case the message was not delivered.
            orderMessage = queue->Peek(TimeSpan::FromSeconds(10.0));
            
            // Display the value of the message's 
            // UseEncryption property.
            Console::WriteLine("Message.UseEncryption: {0}", 
                orderMessage->UseEncryption);
            
            // </snippet34>
            // <snippet35>
            // Set the queue's MessageReadPropertyFilter property 
            // to enable the message's UseJournalQueue property.
            queue->MessageReadPropertyFilter->
                UseJournalQueue = true;
            
            // Peek at the message. Time out after ten seconds 
            // in case the message was not delivered.
            orderMessage = queue->Peek(TimeSpan::FromSeconds(10.0));
            
            // Display the value of the message's 
            // UseJournalQueue property.
            Console::WriteLine("Message.UseJournalQueue: {0}", 
                orderMessage->UseJournalQueue);
            
            // </snippet35>
            // <snippet36>
            // Set the queue's MessageReadPropertyFilter property 
            // to enable the message's UseTracing property.
            queue->MessageReadPropertyFilter->UseTracing = true;
            
            // Peek at the message. Time out after ten seconds 
            // in case the message was not delivered.
            orderMessage = queue->Peek(TimeSpan::FromSeconds(10.0));
            
            // Display the value of the message's 
            // UseTracing property.
            Console::WriteLine("Message.UseTracing: {0}", 
                orderMessage->UseTracing);
            
            // </snippet36>
            // <snippet37>
            // Set all of the queue's MessageReadPropertyFilter 
            // Boolean properties to false.
            queue->MessageReadPropertyFilter->ClearAll();
            
            // </snippet37>
            // <snippet38>
            // Set all of the queue's MessageReadPropertyFilter 
            // properties to their defaults.
            queue->MessageReadPropertyFilter->SetDefaults();
            
            // </snippet38>
            // <snippet39>
            // Set all of the queue's MessageReadPropertyFilter 
            // Boolean properties to true.
            queue->MessageReadPropertyFilter->SetAll();
            
            // </snippet39>
            // <snippet40>
            // Assign the queue a new MessageReadPropertyFilter.
            queue->MessageReadPropertyFilter = 
                gcnew MessagePropertyFilter;
            
            // </snippet40>
            // Receive the message. This will remove the message 
            // from the queue->
            orderMessage = 
                queue->Receive(TimeSpan::FromSeconds(10.0));
        }

        // Sends an order to a transactional queue->
        void SendMessageToTransQueue()
        {   
            // Create a new order and set values.
            Order^ sentOrder = gcnew Order;
            sentOrder->OrderId = 3;
            sentOrder->OrderTime = DateTime::Now;
            
            // Connect to a queue on the local computer.
            MessageQueue^ queue = 
                gcnew MessageQueue(".\\orderTransQueue");
            
            // Create the new order.
            Message^ orderMessage = gcnew Message(sentOrder);
            
            // Create a message queuing transaction->
            MessageQueueTransaction^ transaction = 
                gcnew MessageQueueTransaction;
            
            try
            {       
                // Begin a transaction->
                transaction->Begin();
                
                // Send the order to the queue->
                queue->Send(orderMessage, transaction);
                
                // Commit the transaction->
                transaction->Commit();
            }
            catch (MessageQueueException^ ex) 
            {   
                // Abort the transaction->
                transaction->Abort();
                
                // Propagate the exception.
                throw;
            }
            finally
            {           
                // Delete the transaction object.
                delete transaction;
            }
        }

        // Receives a message containing an order.
        void ReceiveMessageFromTransQueue()
        {     
            // Connect to the a queue on the local computer.
            MessageQueue^ queue = 
                gcnew MessageQueue(".\\orderTransQueue");
            
            // Set the formatter to indicate the 
            // message body contains an order.
	        array <Type^> ^targetTypes = gcnew array<Type^>(1);
            targetTypes[0] = Order::typeid;
            queue->Formatter = 
                gcnew XmlMessageFormatter(targetTypes);
            
            // Declare the message.
            Message^ orderMessage;
            
            // <snippet50>
            // Set the queue's MessageReadPropertyFilter property 
            // to enable the message's IsFirstInTransaction property.
            queue->MessageReadPropertyFilter->
                IsFirstInTransaction = true;
            
            // Peek at the message. Time out after ten seconds 
            // in case the message was not delivered.
            orderMessage = queue->Peek(TimeSpan::FromSeconds(10.0));
            
            // Display the value of the message's 
            // IsFirstInTransaction property.
            Console::WriteLine("Message.IsFirstInTransaction: {0}", 
                orderMessage->IsFirstInTransaction);
            
            // </snippet50>
            // <snippet51>
            // Set the queue's MessageReadPropertyFilter property 
            // to enable the message's IsLastInTransaction property.
            queue->MessageReadPropertyFilter->
                IsLastInTransaction = true;
            
            // Peek at the message. Time out after ten seconds 
            // in case the message was not delivered.
            orderMessage = queue->Peek(TimeSpan::FromSeconds(10.0));
            
            // Display the value of the message's 
            // IsLastInTransaction property.
            Console::WriteLine("Message.IsLastInTransaction: {0}", 
                orderMessage->IsLastInTransaction);
            
            // </snippet51>
            // <snippet52>
            // Set the queue's MessageReadPropertyFilter property 
            // to enable the message's TransactionId property.
            queue->MessageReadPropertyFilter->TransactionId = true;
            
            // Peek at the message. Time out after ten seconds 
            // in case the message was not delivered.
            orderMessage = queue->Peek(TimeSpan::FromSeconds(10.0));
            
            // Display the value of the message's 
            // TransactionId property.
            Console::WriteLine("Message.TransactionId: {0}", 
                orderMessage->TransactionId);
            
            // </snippet52>
            // <snippet53>
            // Set the queue's MessageReadPropertyFilter property to 
            // enable the message's TransactionStatusQueue property.
            queue->MessageReadPropertyFilter->
                TransactionStatusQueue = true;
            
            // Peek at the message. Time out after ten seconds 
            // in case the message was not delivered.
            orderMessage = queue->Peek(TimeSpan::FromSeconds(10.0));
            
            // Display the value of the message's 
            // TransactionStatusqueue->QueueName property.
            Console::WriteLine(
                "Message.TransactionStatusqueue->QueueName: {0}", 
                orderMessage->TransactionStatusQueue->QueueName);
            
            // </snippet53>
            // Create a message queuing transaction->
            MessageQueueTransaction^ transaction = 
                gcnew MessageQueueTransaction;
            
            try
            {        
                // Begin a transaction->
                transaction->Begin();
                
                // Receive the message. Time out after ten seconds 
                // in case the message was not delivered.
                orderMessage = queue->Receive(
                    TimeSpan::FromSeconds(10.0), transaction);
                
                // Commit the transaction->
                transaction->Commit();
            }
            catch (MessageQueueException^ ex) 
            {      
                // Abort the transaction->
                transaction->Abort();
                
                // Propagate the exception.
                throw;
            }
            finally
            {          
                // Delete the transaction object.
                delete transaction;
            }
        }
    };
}

int main()
{
    // Create a new instance of the class.
    MessagePropertyFilterExample::OrderProcessor^ processor = 
        gcnew MessagePropertyFilterExample::OrderProcessor;

    try
    { 
        // Create a non-transactional queue on the local computer.
        // Note that the queue might not be immediately accessible, 
        //and therefore this example might throw an exception of type
        // System.Messaging.MessageQueueException when trying to send
        // a message to the newly created queue->
        MessagePropertyFilterExample::
            OrderProcessor::CreateQueue(".\\orderQueue", false);
        
        // Send a message to a queue->
        processor->SendMessage();
        
        // Receive a message from a queue->
        processor->ReceiveMessage();
        
        // Create a transactional queue on the local computer.
        MessagePropertyFilterExample::
            OrderProcessor::CreateQueue(".\\orderTransQueue", true);
        
        // Send a message to a transactional queue->
        processor->SendMessageToTransQueue();
        
        // Receive a message from a transactional queue->
        processor->ReceiveMessageFromTransQueue();
    }
    catch (MessageQueueException^ ex) 
    {
        // Write the exception information to the console.
        Console::WriteLine(ex);
    }
}

// </snippet0>

//output:
//
//.\orderQueue already exists.
//Message.AcknowledgeType: None
//Message.AdministrationQueue:
//Message.AppSpecific: 0
//Message.ArrivedTime: 13.11.2004 14:42:30
//Message.AttachSenderId: True
//Message.Authenticated: False
//Message.AuthenticationProviderName:
//Message.AuthenticationProviderType: None
//Message.Body: Order
//Message.ConnectorType: 00000000-0000-0000-0000-000000000000
//MessageReadPropertyFilter.DefaultBodySize: 2048
//MessageReadPropertyFilter.DefaultExtensionSize: 1024
//MessageReadPropertyFilter.DefaultLabelSize: 1024
//Message.Destinationqueue->QueueName: orderqueue
//Message.DestinationSymmetricKey: System.Byte[]
//Message.DigitalSignature: System.Byte[]
//Message.EncryptionAlgorithm: None
//Message.Extension: System.Byte[]
//Message.HashAlgorithm: None
//Message.Id: f2c7b57e-da35-4596-8b30-3b2ce0dd3756\2058
//Message.Label: Order Message
//Message.MessageType: Normal
//Message.Recoverable: False
//Message.SenderCertificate: System.Byte[]
//Message.SenderId: System.Byte[]
//Message.SenderVersion: 16
//Message.SentTime: 13.11.2004 14:42:30
//Message.SourceMachine: ulkdev1
//Message.TimeToBeReceived: 49710.06:28:15
//Message.TimeToReachQueue: 4.00:00:00
//Message.UseAuthentication: False
//Message.UseDeadLetterQueue: False
//Message.UseEncryption: False
//Message.UseJournalQueue: False
//Message.UseTracing: False
//.\orderTransQueue already exists.
//Message.IsFirstInTransaction: True
//Message.IsLastInTransaction: True
//Message.TransactionId: f2c7b57e-da35-4596-8b30-3b2ce0dd3756\2059
//Message.TransactionStatusqueue->QueueName: private$\order_queue$
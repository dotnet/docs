

// <Snippet1>
#using <system.dll>
#using <system.messaging.dll>

using namespace System;
using namespace System::Messaging;
ref class MyNewQueue
{
public:

   // Creates public transactional queues and sends a 
   // message.
   void CreatePublicTransactionalQueues()
   {
      
      // Create and connect to a public message Queuing queue.
      if (  !MessageQueue::Exists( ".\\newPublicTransQueue1" ) )
      {
         
         // Create the queue if it does not exist.
         MessageQueue::Create( ".\\newPublicTransQueue1", true );
      }

      
      // Connect to the queue.
      MessageQueue^ myNewPublicQueue = gcnew MessageQueue( ".\\newPublicTransQueue1" );
      
      // Create a transaction.
      MessageQueueTransaction^ myTransaction = gcnew MessageQueueTransaction;
      
      // Begin the transaction.
      myTransaction->Begin();
      
      // Send the message.
      myNewPublicQueue->Send( "My Message Data.", myTransaction );
      
      // Commit the transaction.
      myTransaction->Commit();
      if (  !MessageQueue::Exists( ".\\newPublicTransQueue2" ) )
      {
         
         // Create (but do not connect to) second public queue
         MessageQueue::Create( ".\\newPublicTransQueue2", true );
      }

      return;
   }


   // Creates private queues and sends a message.
   void CreatePrivateTransactionalQueues()
   {
      
      // Create and connect to a private Message Queuing queue.
      if (  !MessageQueue::Exists( ".\\Private$\\newPrivTransQ1" ) )
      {
         
         // Create the queue if it does not exist.
         MessageQueue^ myNewPrivateQueue = MessageQueue::Create( ".\\Private$\\newPrivTransQ1", true );
      }

      
      // Connect to the queue.
      MessageQueue^ myNewPrivateQueue = gcnew MessageQueue( ".\\Private$\\newPrivTransQ1" );
      
      // Create a transaction.
      MessageQueueTransaction^ myTransaction = gcnew MessageQueueTransaction;
      
      // Begin the transaction.
      myTransaction->Begin();
      
      // Send the message.
      myNewPrivateQueue->Send( "My Message Data.", myTransaction );
      
      // Commit the transaction.
      myTransaction->Commit();
      
      // Create (but do not connect to) a second private queue.
      if (  !MessageQueue::Exists( ".\\Private$\\newPrivTransQ2" ) )
      {
         MessageQueue::Create( ".\\Private$\\newPrivTransQ2", true );
      }

      return;
   }

};


// Provides an entry point into the application.
// This example creates new transactional queues.
int main()
{
   
   // Create a new instance of the class.
   MyNewQueue^ myNewQueue = gcnew MyNewQueue;
   
   // Create transactional queues.
   myNewQueue->CreatePublicTransactionalQueues();
   myNewQueue->CreatePrivateTransactionalQueues();
   return 0;
}

// </Snippet1>



// <Snippet1>
#using <system.dll>
#using <system.messaging.dll.>

using namespace System;
using namespace System::Messaging;
ref class MyNewQueue
{
public:
   void SendMessage()
   {
      
      // Connect to a queue on the local computer.
      MessageQueue^ myQueue = gcnew MessageQueue( ".\\myQueue" );
      
      // Send a message to the queue.
      if ( myQueue->Transactional == true )
      {
         
         // Create a transaction.
         MessageQueueTransaction^ myTransaction = gcnew MessageQueueTransaction;
         
         // Begin the transaction.
         myTransaction->Begin();
         
         // Send the message.
         myQueue->Send( "My Message Data.", myTransaction );
         
         // Commit the transaction.
         myTransaction->Commit();
      }
      else
      {
         myQueue->Send( "My Message Data." );
      }

      return;
   }

};

int main()
{
   
   // Create a new instance of the class.
   MyNewQueue^ myNewQueue = gcnew MyNewQueue;
   
   // Send a message to a queue.
   myNewQueue->SendMessage();
   return 0;
}

// </Snippet1>

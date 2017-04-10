

// <Snippet1>
#using <system.dll>
#using <system.messaging.dll>

using namespace System;
using namespace System::Messaging;
ref class MyNewQueue
{
public:

   // Sends a message to a queue.
   void SendMessage()
   {
      // Connect to a queue on the local computer.
      MessageQueue^ myQueue = gcnew MessageQueue( ".\\myQueue" );

      // Send a message to the queue.
      myQueue->Send( "My message data1." );

      // Explicitly release resources.
      myQueue->Close();

      // Attempt to reaquire resources.
      myQueue->Send( "My message data2." );
      return;
   }

   // Receives a message from a queue.
   void ReceiveMessage()
   {
      // Connect to the a on the local computer.
      MessageQueue^ myQueue = gcnew MessageQueue( ".\\myQueue" );

      // Set the formatter to indicate body contains an Order.
      array<Type^>^p = gcnew array<Type^>(1);
      p[ 0 ] = String::typeid;
      myQueue->Formatter = gcnew XmlMessageFormatter( p );
      try
      {
         // Receive and format the message. 
         Message^ myMessage1 = myQueue->Receive();
         Message^ myMessage2 = myQueue->Receive();
      }
      catch ( MessageQueueException^ ) 
      {
         // Handle sources of any MessageQueueException.
      }
      finally
      {
         // Free resources.
         myQueue->Close();
      }

      return;
   }
};


// Provides an entry point into the application.
// This example closes a queue and frees its 
// resources.
int main()
{
   // Create a new instance of the class.
   MyNewQueue^ myNewQueue = gcnew MyNewQueue;

   // Send a message to a queue.
   myNewQueue->SendMessage();

   // Receive a message from a queue.
   myNewQueue->ReceiveMessage();
   return 0;
}
// </Snippet1>

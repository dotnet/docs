// <Snippet1>

#using <system.dll>
#using <system.messaging.dll>

using namespace System;
using namespace System::Messaging;

/// <summary>
/// Provides a container class for the example.
/// </summary>
ref class MyNewQueue
{
   //**************************************************
   // Sends a string message to a queue.
   //**************************************************
public:
   void SendMessage( MessagePriority priority, String^ messageBody )
   {
      // Connect to a queue on the local computer.
      MessageQueue^ myQueue = gcnew MessageQueue( ".\\myQueue" );

      // Create a new message.
      Message^ myMessage = gcnew Message;
      if ( priority > MessagePriority::Normal )
      {
         myMessage->Body = "High Priority: {0}",messageBody;
      }
      else
      {
         myMessage->Body = messageBody;
      }

      // Set the priority of the message.
      myMessage->Priority = priority;

      // Send the Order to the queue.
      myQueue->Send( myMessage );

      return;
   }

   //**************************************************
   // Receives a message.
   //**************************************************
   void ReceiveMessage()
   {
      // Connect to the a queue on the local computer.
      MessageQueue^ myQueue = gcnew MessageQueue( ".\\myQueue" );

      // Set the queue to read the priority. By default, it
      // is not read.
      myQueue->MessageReadPropertyFilter->Priority = true;

      // Set the formatter to indicate body contains a String^.
      array<Type^>^ p = gcnew array<Type^>(1);
      p[ 0 ] = String::typeid;
      myQueue->Formatter = gcnew XmlMessageFormatter( p );
      try
      {
         // Receive and format the message. 
         Message^ myMessage = myQueue->Receive();

         // Display message information.
         Console::WriteLine( "Priority: {0}",
            myMessage->Priority );
         Console::WriteLine( "Body: {0}",
            myMessage->Body );
      }
      catch ( MessageQueueException^ ) 
      {
         // Handle Message Queuing exceptions.
      }
      // Handle invalid serialization format.
      catch ( InvalidOperationException^ e ) 
      {
         Console::WriteLine( e->Message );
      }

      // Catch other exceptions as necessary.

      return;
   }
};

//**************************************************
// Provides an entry point into the application.
//		 
// This example sends and receives a message from
// a queue.
//**************************************************
int main()
{
   // Create a new instance of the class.
   MyNewQueue^ myNewQueue = gcnew MyNewQueue;

   // Send messages to a queue.
   myNewQueue->SendMessage( MessagePriority::Normal, "First Message Body." );
   myNewQueue->SendMessage( MessagePriority::Highest, "Second Message Body." );

   // Receive messages from a queue.
   myNewQueue->ReceiveMessage();
   myNewQueue->ReceiveMessage();

   return 0;
}
// </Snippet1>



// <Snippet1>
#using <system.dll>
#using <system.messaging.dll>

using namespace System;
using namespace System::Messaging;

// This class represents an object the following example 
// sends to a queue and receives from a queue.
ref class Order
{
public:
   int orderId;
   DateTime orderTime;
};


/// <summary>
/// Provides a container class for the example.
/// </summary>
ref class MyNewQueue
{
public:

   //*************************************************
   // Posts a notification when a message arrives in 
   // the queue S"monitoredQueue". Does not retrieve any 
   // message information when peeking the message.
   //*************************************************
   void NotifyArrived()
   {
      // Connect to a queue.
      MessageQueue^ myQueue = gcnew MessageQueue( ".\\monitoredQueue" );

      // Specify to retrieve no message information.
      myQueue->MessageReadPropertyFilter->ClearAll();

      // Wait for a message to arrive. 
      Message^ emptyMessage = myQueue->Peek();

      // Post a notification when a message arrives.
      Console::WriteLine( "A message has arrived in the queue." );
      return;
   }


   //*************************************************
   // Sends an Order to a queue.
   //*************************************************
   void SendMessage()
   {
      // Create a new order and set values.
      Order^ sentOrder = gcnew Order;
      sentOrder->orderId = 3;
      sentOrder->orderTime = DateTime::Now;

      // Connect to a queue on the local computer.
      MessageQueue^ myQueue = gcnew MessageQueue( ".\\myQueue" );

      // Send the Order to the queue.
      myQueue->Send( sentOrder );
      return;
   }

   //*************************************************
   // Peeks a message containing an Order.
   //*************************************************
   void PeekFirstMessage()
   {
      // Connect to a queue.
      MessageQueue^ myQueue = gcnew MessageQueue( ".\\myQueue" );

      // Set the formatter to indicate the body contains an Order.
      array<Type^>^p = gcnew array<Type^>(1);
      p[ 0 ] = Order::typeid;
      myQueue->Formatter = gcnew XmlMessageFormatter( p );
      try
      {
         // Peek and format the message. 
         Message^ myMessage = myQueue->Peek();
         Order^ myOrder = static_cast<Order^>(myMessage->Body);

         // Display message information.
         Console::WriteLine( "Order ID: {0}", myOrder->orderId );
         Console::WriteLine( "Sent: {0}", myOrder->orderTime );
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

//*************************************************
// Provides an entry point into the application.
//         
// This example posts a notification that a message
// has arrived in a queue. It sends a message 
// containing an other to a separate queue, and then
// peeks the first message in the queue.
//*************************************************
int main()
{
   // Create a new instance of the class.
   MyNewQueue^ myNewQueue = gcnew MyNewQueue;

   // Wait for a message to arrive in the queue.
   myNewQueue->NotifyArrived();

   // Send a message to a queue.
   myNewQueue->SendMessage();

   // Peek the first message in the queue.
   myNewQueue->PeekFirstMessage();
   return 0;
}
// </Snippet1>

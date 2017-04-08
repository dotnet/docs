

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
   // Receives a message containing an Order.
   //*************************************************
   void ReceiveMessage()
   {
      // Connect to the a queue on the local computer.
      MessageQueue^ myQueue = gcnew MessageQueue( ".\\myQueue" );

      // Set the formatter to indicate body contains an Order.
      array<Type^>^p = gcnew array<Type^>(1);
      p[ 0 ] = Order::typeid;
      myQueue->Formatter = gcnew XmlMessageFormatter( p );
      try
      {
         // Receive and format the message. 
         Message^ myMessage = myQueue->Receive();
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
// This example sends and receives a message from
// a queue.
//*************************************************
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

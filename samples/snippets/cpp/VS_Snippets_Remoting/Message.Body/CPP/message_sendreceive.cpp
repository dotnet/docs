

// <Snippet1>
#using <system.dll>
#using <system.messaging.dll>
#using <system.drawing.dll>

using namespace System;
using namespace System::Messaging;
using namespace System::Drawing;
using namespace System::IO;
ref class Order
{
public:
   int orderId;
   DateTime orderTime;
};

ref class MyNewQueue
{
public:
   static void CreateQueue( String^ queuePath )
   {
      try
      {
         if (  !MessageQueue::Exists( queuePath ) )
         {
            MessageQueue::Create( queuePath );
         }
         else
         {
            Console::WriteLine(  "{0} already exists.", queuePath );
         }
      }
      catch ( MessageQueueException^ e ) 
      {
         Console::WriteLine( e->Message );
      }

   }

   void SendMessage()
   {
      try
      {
         // Create a new order and set values.
         Order^ sentOrder = gcnew Order;
         sentOrder->orderId = 3;
         sentOrder->orderTime = DateTime::Now;

         // Connect to a queue on the local computer.
         MessageQueue^ myQueue = gcnew MessageQueue( ".\\myQueue" );

         // Create the new order.
         Message^ myMessage = gcnew Message( sentOrder );

         // Send the order to the queue.
         myQueue->Send( myMessage );
      }
      catch ( ArgumentException^ e ) 
      {
         Console::WriteLine( e->Message );
      }

      return;
   }

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
         Order^ myOrder = dynamic_cast<Order^>(myMessage->Body);

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

int main()
{
   // Create a new instance of the class.
   MyNewQueue^ myNewQueue = gcnew MyNewQueue;

   // Create a queue on the local computer.
   MyNewQueue::CreateQueue( ".\\myQueue" );

   // Send a message to a queue.
   myNewQueue->SendMessage();

   // Receive a message from a queue.
   myNewQueue->ReceiveMessage();
   return 0;
}
// </Snippet1>

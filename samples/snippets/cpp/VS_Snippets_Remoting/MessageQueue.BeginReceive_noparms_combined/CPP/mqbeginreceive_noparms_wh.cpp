// <Snippet2>
#using <system.dll>
#using <system.messaging.dll>

using namespace System;
using namespace System::Messaging;
using namespace System::Threading;

ref class MyNewQueue
{
public:

   // Provides an event handler for the ReceiveCompleted
   // event.
   static void MyReceiveCompleted( Object^ source, ReceiveCompletedEventArgs^ asyncResult )
   {
      try
      {
         // Connect to the queue.
         MessageQueue^ mq = dynamic_cast<MessageQueue^>(source);

         // End the asynchronous receive operation.
         mq->EndReceive( asyncResult->AsyncResult );

         // Process the message here.
         Console::WriteLine( "Message received." );
      }
      catch ( MessageQueueException^ ) 
      {
         // Handle sources of MessageQueueException.
      }
      // Handle other exceptions.
      return;
   }
};

// Provides an entry point into the application.
//         
// This example performs asynchronous receive
// operation processing.
int main()
{
   // Create an instance of MessageQueue. Set its formatter.
   MessageQueue^ myQueue = gcnew MessageQueue( ".\\myQueue" );
   array<Type^>^p = gcnew array<Type^>(1);
   p[ 0 ] = String::typeid;
   myQueue->Formatter = gcnew XmlMessageFormatter( p );

   // Add an event handler for the ReceiveCompleted event.
   myQueue->ReceiveCompleted += gcnew ReceiveCompletedEventHandler( MyNewQueue::MyReceiveCompleted );

   // Define wait handles for multiple operations.
   array<WaitHandle^>^waitHandleArray = gcnew array<WaitHandle^>(10);
   for ( int i = 0; i < 10; i++ )
   {
      // Begin asynchronous operations.
      waitHandleArray[ i ] = myQueue->BeginReceive()->AsyncWaitHandle;
   }

   // Specify to wait for all operations to return.
   WaitHandle::WaitAll( waitHandleArray );
   return 0;
}
// </Snippet2>

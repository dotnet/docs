// <Snippet1>
#using <system.dll>
#using <system.messaging.dll>

using namespace System;
using namespace System::Messaging;
using namespace System::Threading;

ref class MyNewQueue
{
public:

   // Define static class members.
   static ManualResetEvent^ signal = gcnew ManualResetEvent( false );
   static int count = 0;

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
         count += 1;
         if ( count == 10 )
         {
            signal->Set();
         }

         // Restart the asynchronous receive operation.
         mq->BeginReceive();
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

   // Begin the asynchronous receive operation.
   myQueue->BeginReceive();
   MyNewQueue::signal->WaitOne();

   // Do other work on the current thread.
   return 0;
}
// </Snippet1>

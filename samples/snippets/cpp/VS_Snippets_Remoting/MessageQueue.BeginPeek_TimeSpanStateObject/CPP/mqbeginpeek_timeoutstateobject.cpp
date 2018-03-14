

// <Snippet1>
#using <system.dll>
#using <system.messaging.dll>

using namespace System;
using namespace System::Messaging;
ref class MyNewQueue
{
public:

   // Represents a state object associated with each message.
   static int messageNumber = 0;

   // Provides an event handler for the PeekCompleted
   // event.
   //
   static void MyPeekCompleted( Object^ source, PeekCompletedEventArgs^ asyncResult )
   {
      try
      {
         // Connect to the queue.
         MessageQueue^ mq = dynamic_cast<MessageQueue^>(source);

         // End the asynchronous peek operation.
         Message^ m = mq->EndPeek( asyncResult->AsyncResult );

         // Display message information on the screen, 
         // including the message number (state object).
         Console::WriteLine( "Message: {0} {1}", asyncResult->AsyncResult->AsyncState, static_cast<String^>(m->Body) );

         // Restart the asynchronous peek operation, with the 
         // same time-out.
         mq->BeginPeek( TimeSpan(0,1,0), messageNumber++ );
      }
      catch ( MessageQueueException^ e ) 
      {
         if ( e->MessageQueueErrorCode == MessageQueueErrorCode::IOTimeout )
         {
            Console::WriteLine( e );
         }

         // Handle other sources of MessageQueueException.
      }

      // Handle other exceptions.
      return;
   }
};


// Provides an entry point into the application.
//         
// This example performs asynchronous peek operation
// processing.
int main()
{
   // Create an instance of MessageQueue. Set its formatter.
   MessageQueue^ myQueue = gcnew MessageQueue( ".\\myQueue" );
   array<Type^>^p = gcnew array<Type^>(1);
   p[ 0 ] = String::typeid;
   myQueue->Formatter = gcnew XmlMessageFormatter( p );

   // Add an event handler for the PeekCompleted event.
   myQueue->PeekCompleted += gcnew PeekCompletedEventHandler( MyNewQueue::MyPeekCompleted );

   // Begin the asynchronous peek operation with a timeout 
   // of one minute.
   myQueue->BeginPeek( TimeSpan(0,1,0), MyNewQueue::messageNumber++ );

   // Do other work on the current thread.
   return 0;
}
// </Snippet1>

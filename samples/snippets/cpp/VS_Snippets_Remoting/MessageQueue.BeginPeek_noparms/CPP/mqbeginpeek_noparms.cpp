

// <Snippet1>
#using <system.dll>
#using <system.messaging.dll>

using namespace System;
using namespace System::Messaging;

// This example performs asynchronous peek operation
// processing.
//*************************************************
ref class MyNewQueue
{
public:

   // Provides an event handler for the PeekCompleted
   // event.
   static void MyPeekCompleted( Object^ source, PeekCompletedEventArgs^ asyncResult )
   {
      // Connect to the queue.
      MessageQueue^ mq = dynamic_cast<MessageQueue^>(source);

      // End the asynchronous peek operation.
      Message^ m = mq->EndPeek( asyncResult->AsyncResult );

      // Display message information on the screen.
      Console::WriteLine( "Message: {0}", static_cast<String^>(m->Body) );

      // Restart the asynchronous peek operation.
      mq->BeginPeek();
      return;
   }
};

// Provides an entry point into the application.
//         
int main()
{
   // Create an instance of MessageQueue. Set its formatter.
   MessageQueue^ myQueue = gcnew MessageQueue( ".\\myQueue" );
   array<Type^>^p = gcnew array<Type^>(1);
   p[ 0 ] = String::typeid;
   myQueue->Formatter = gcnew XmlMessageFormatter( p );

   // Add an event handler for the PeekCompleted event.
   myQueue->PeekCompleted += gcnew PeekCompletedEventHandler( MyNewQueue::MyPeekCompleted );

   // Begin the asynchronous peek operation.
   myQueue->BeginPeek();

   // Do other work on the current thread.
   return 0;
}
// </Snippet1>

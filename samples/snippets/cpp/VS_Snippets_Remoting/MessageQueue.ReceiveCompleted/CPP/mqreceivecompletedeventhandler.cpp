

// <Snippet1>
#using <system.dll>
#using <system.messaging.dll>

using namespace System;
using namespace System::Messaging;
ref class MyNewQueue
{
public:

   //*************************************************
   // Provides an event handler for the ReceiveCompleted
   // event.
   //*************************************************
   static void MyReceiveCompleted( Object^ source, ReceiveCompletedEventArgs^ asyncResult )
   {
      // Connect to the queue.
      MessageQueue^ mq = dynamic_cast<MessageQueue^>(source);

      // End the asynchronous Receive operation.
      Message^ m = mq->EndReceive( asyncResult->AsyncResult );

      // Display message information on the screen.
      Console::WriteLine( "Message: {0}", m->Body );

      // Restart the asynchronous Receive operation.
      mq->BeginReceive();
      return;
   }
};


//*************************************************
// Provides an entry point into the application.
//         
// This example performs asynchronous receive operation
// processing.
//*************************************************
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

   // Do other work on the current thread.
   return 0;
}
// </Snippet1>



// <Snippet1>
#using <system.dll>
#using <system.messaging.dll>

using namespace System;
using namespace System::Messaging;
ref class MyNewQueue
{
public:

   // Requests exlusive read access to the queue. If
   // access is granted, receives a message from the 
   // queue.
   void GetExclusiveAccess()
   {
      try
      {
         
         // Request exclusive read access to the queue.
         MessageQueue^ myQueue = gcnew MessageQueue( ".\\myQueue",true );
         
         // Receive a message. This is where SharingViolation 
         // exceptions would be thrown.
         Message^ myMessage = myQueue->Receive();
      }
      catch ( MessageQueueException^ e ) 
      {
         
         // Handle request for denial of exclusive read access.
         if ( e->MessageQueueErrorCode == MessageQueueErrorCode::SharingViolation )
         {
            Console::WriteLine( "Denied exclusive read access" );
         }

         
         // Handle other sources of a MessageQueueException.
      }

      
      // Handle other exceptions as necessary.
      return;
   }

};


// Provides an entry point into the application.
// This example connects to a message queue, and
// requests exclusive read access to the queue.
int main()
{
   
   // Create a new instance of the class.
   MyNewQueue^ myNewQueue = gcnew MyNewQueue;
   
   // Output the count of Lowest priority messages.
   myNewQueue->GetExclusiveAccess();
   return 0;
}

// </Snippet1>

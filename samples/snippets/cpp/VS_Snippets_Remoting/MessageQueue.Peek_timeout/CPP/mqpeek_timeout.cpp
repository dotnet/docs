

// <Snippet1>
#using <system.dll>
#using <system.messaging.dll>

using namespace System;
using namespace System::Messaging;
ref class MyNewQueue
{
public:

   //*************************************************
   // Determines whether a queue is empty. The Peek()
   // method throws an exception if there is no message
   // in the queue. This method handles that exception 
   // by returning true to the calling method.
   //*************************************************
   bool IsQueueEmpty()
   {
      bool isQueueEmpty = false;
      
      // Connect to a queue.
      MessageQueue^ myQueue = gcnew MessageQueue( ".\\myQueue" );
      try
      {
         
         // Set Peek to return immediately.
         myQueue->Peek( TimeSpan(0) );
         
         // If an IOTime->Item[Out] was* not thrown, there is a message 
         // in the queue.
         isQueueEmpty = false;
      }
      catch ( MessageQueueException^ e ) 
      {
         if ( e->MessageQueueErrorCode == MessageQueueErrorCode::IOTimeout )
         {
            
            // No message was in the queue.
            isQueueEmpty = true;
         }

         
         // Handle other sources of MessageQueueException.
      }

      
      // Handle other exceptions as necessary.
      // Return true if there are no messages in the queue.
      return isQueueEmpty;
   }

};


//*************************************************
// Provides an entry point into the application.
//         
// This example determines whether a queue is empty.
//*************************************************
int main()
{
   
   // Create a new instance of the class.
   MyNewQueue^ myNewQueue = gcnew MyNewQueue;
   
   // Determine whether a queue is empty.
   bool isQueueEmpty = myNewQueue->IsQueueEmpty();
   return 0;
}

// </Snippet1>

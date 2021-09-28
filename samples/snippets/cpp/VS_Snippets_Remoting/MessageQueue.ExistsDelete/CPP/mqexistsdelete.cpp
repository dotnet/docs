

// <Snippet1>
#using <system.dll>
#using <system.messaging.dll>

using namespace System;
using namespace System::Messaging;
int main()
{
   
   // Determine whether the queue exists.
   if ( MessageQueue::Exists( ".\\myQueue" ) )
   {
      try
      {
         
         // Delete the queue.
         MessageQueue::Delete( ".\\myQueue" );
      }
      catch ( MessageQueueException^ e ) 
      {
         if ( e->MessageQueueErrorCode == MessageQueueErrorCode::AccessDenied )
         {
            Console::WriteLine( "Access is denied. Queue might be a system queue." );
         }
         
         // Handle other sources of MessageQueueException.
      }

   }

   return 0;
}

// </Snippet1>

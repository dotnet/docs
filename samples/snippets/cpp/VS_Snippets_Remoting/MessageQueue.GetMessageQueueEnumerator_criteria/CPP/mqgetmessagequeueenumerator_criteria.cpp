

// <Snippet1>
#using <system.dll>
#using <system.messaging.dll>

using namespace System;
using namespace System::Messaging;
ref class MyNewQueue
{
public:

   // Iterates through message queues and displays the
   // path of each queue that was created in the last
   // day and that exists on the computer "MyComputer". 
   void ListPublicQueuesByCriteria()
   {
      UInt32 numberQueues = 0;
      
      // Specify the criteria to filter by.
      MessageQueueCriteria^ myCriteria = gcnew MessageQueueCriteria;
      myCriteria->MachineName = "MyComputer";
      myCriteria->CreatedAfter = DateTime::Now.Subtract( TimeSpan(1,0,0,0) );
      
      // Get a cursor into the queues on the network.
      MessageQueueEnumerator^ myQueueEnumerator = MessageQueue::GetMessageQueueEnumerator( myCriteria );
      
      // Move to the next queue and read its path.
      while ( myQueueEnumerator->MoveNext() )
      {
         
         // Increase the count if priority is Lowest.
         Console::WriteLine( myQueueEnumerator->Current->Path );
         numberQueues++;
      }

      
      // Handle no queues matching the criteria.
      if ( numberQueues == 0 )
      {
         Console::WriteLine( "No public queues match criteria." );
      }

      return;
   }

};

int main()
{
   
   // Create a new instance of the class.
   MyNewQueue^ myNewQueue = gcnew MyNewQueue;
   
   // Output the count of Lowest priority messages.
   myNewQueue->ListPublicQueuesByCriteria();
   return 0;
}

// </Snippet1>

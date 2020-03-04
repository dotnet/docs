

// <Snippet1>
#using <System.dll>
#using <System.Messaging.dll>

using namespace System;
using namespace System::Messaging;

//**************************************************
// Iterates through message queues and examines the
// path for each queue. Also displays the number of
// public queues on the network.
//**************************************************
void ListPublicQueues()
{
   
   // Holds the count of private queues.
   int numberQueues = 0;
   
   // Get a cursor into the queues on the network.
   MessageQueueEnumerator^ myQueueEnumerator = MessageQueue::GetMessageQueueEnumerator();
   
   // Move to the next queue and read its path.
   while ( myQueueEnumerator->MoveNext() )
   {
      
      // Increase the count if priority is Lowest.
      Console::WriteLine( myQueueEnumerator->Current->Path );
      numberQueues++;
   }

   
   // Display final count.
   Console::WriteLine( "Number of public queues: {0}", numberQueues );
   return;
}


//**************************************************
// Provides an entry point into the application.
//   
// This example uses a cursor to step through the
// message queues and list the public queues on the
// network.
//**************************************************
int main()
{
   
   // Output the count of Lowest priority messages.
   ListPublicQueues();
}

// </Snippet1>



// <Snippet1>
#using <system.dll>
#using <system.messaging.dll>

using namespace System;
using namespace System::Messaging;
ref class MyNewQueue
{
public:
   void CountLowestPriority()
   {
      
      // Holds the count of Lowest priority messages.
      UInt32 numberItems = 0;
      
      // Connect to a queue.
      MessageQueue^ myQueue = gcnew MessageQueue( ".\\myQueue" );
      
      // Get a cursor into the messages in the queue.
      MessageEnumerator^ myEnumerator = myQueue->GetMessageEnumerator();
      
      // Specify that the messages's priority should be read.
      myQueue->MessageReadPropertyFilter->Priority = true;
      
      // Move to the next message and examine its priority.
      while ( myEnumerator->MoveNext() )
      {
         
         // Increase the count if priority is Lowest.
         if ( myEnumerator->Current->Priority == MessagePriority::Lowest )
                  numberItems++;
      }

      
      // Display final count.
      Console::WriteLine( "Lowest priority messages: {0}", numberItems );
      return;
   }

};

int main()
{
   
   // Create a new instance of the class.
   MyNewQueue^ myNewQueue = gcnew MyNewQueue;
   
   // Output the count of Lowest priority messages.
   myNewQueue->CountLowestPriority();
   return 0;
}

// </Snippet1>

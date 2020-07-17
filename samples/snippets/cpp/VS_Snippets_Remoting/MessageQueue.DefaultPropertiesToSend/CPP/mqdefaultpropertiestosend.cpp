

// <Snippet1>
#using <system.dll>
#using <system.messaging.dll>

using namespace System;
using namespace System::Messaging;
ref class MyNewQueue
{
public:

   // Associates selected message property values
   // with high priority messages.
   void SendHighPriorityMessages()
   {
      
      // Connect to a message queue.
      MessageQueue^ myQueue = gcnew MessageQueue( ".\\myQueue" );
      
      // Associate selected default property values with high
      // priority messages.
      myQueue->DefaultPropertiesToSend->Priority = MessagePriority::High;
      myQueue->DefaultPropertiesToSend->Label = "High Priority Message";
      myQueue->DefaultPropertiesToSend->Recoverable = true;
      myQueue->DefaultPropertiesToSend->TimeToReachQueue = TimeSpan(0,0,30);
      
      // Send messages using these defaults.
      myQueue->Send( "High priority message data 1." );
      myQueue->Send( "High priority message data 2." );
      myQueue->Send( "High priority message data 3." );
      return;
   }


   // Associates selected message property values
   // with normal priority messages.
   void SendNormalPriorityMessages()
   {
      
      // Connect to a message queue.
      MessageQueue^ myQueue = gcnew MessageQueue( ".\\myQueue" );
      
      // Associate selected default property values with normal
      // priority messages.
      myQueue->DefaultPropertiesToSend->Priority = MessagePriority::Normal;
      myQueue->DefaultPropertiesToSend->Label = "Normal Priority Message";
      myQueue->DefaultPropertiesToSend->Recoverable = false;
      myQueue->DefaultPropertiesToSend->TimeToReachQueue = TimeSpan(0,2,0);
      
      // Send messages using these defaults.
      myQueue->Send( "Normal priority message data 1." );
      myQueue->Send( "Normal priority message data 2." );
      myQueue->Send( "Normal priority message data 3." );
      return;
   }

};


// Provides an entry point into the application.
// This example specifies different types of default
// properties for messages.
int main()
{
   
   // Create a new instance of the class.
   MyNewQueue^ myNewQueue = gcnew MyNewQueue;
   
   // Send normal and high priority messages.
   myNewQueue->SendNormalPriorityMessages();
   myNewQueue->SendHighPriorityMessages();
   return 0;
}

// </Snippet1>

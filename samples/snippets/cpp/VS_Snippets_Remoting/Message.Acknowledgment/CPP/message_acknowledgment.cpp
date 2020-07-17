

// <Snippet1>
#using <system.dll>
#using <system.messaging.dll>

using namespace System;
using namespace System::Messaging;
ref class MyNewQueue
{
public:
   static void CreateQueue( String^ queuePath )
   {
      try
      {
         if (  !MessageQueue::Exists( queuePath ) )
         {
            MessageQueue::Create( queuePath );
         }
         else
         {
            Console::WriteLine(  "{0} already exists.", queuePath );
         }
      }
      catch ( MessageQueueException^ e ) 
      {
         Console::WriteLine( e->Message );
      }

   }

   void SendMessage()
   {
      // Connect to a queue on the local computer.
      MessageQueue^ myQueue = gcnew MessageQueue( ".\\myQueue" );

      // Create a new message.
      Message^ myMessage = gcnew Message( "Original Message" );
      myMessage->AdministrationQueue = gcnew MessageQueue( ".\\myAdministrationQueue" );
      myMessage->AcknowledgeType = (AcknowledgeTypes)(AcknowledgeTypes::PositiveReceive | AcknowledgeTypes::PositiveArrival);

      // Send the Order to the queue.
      myQueue->Send( myMessage );
      return;
   }

   String^ ReceiveMessage()
   {
      // Connect to the a queue on the local computer.
      MessageQueue^ myQueue = gcnew MessageQueue( ".\\myQueue" );
      myQueue->MessageReadPropertyFilter->CorrelationId = true;
      array<Type^>^p = gcnew array<Type^>(1);
      p[ 0 ] = String::typeid;
      myQueue->Formatter = gcnew XmlMessageFormatter( p );
      String^ returnString = nullptr;
      try
      {
         // Receive and format the message. 
         Message^ myMessage = myQueue->Receive();

         // Display message information.
         Console::WriteLine( "____________________________________________" );
         Console::WriteLine( "Original message information--" );
         Console::WriteLine( "Body: {0}", myMessage->Body );
         Console::WriteLine( "Id: {0}", myMessage->Id );
         Console::WriteLine( "____________________________________________" );
         returnString = myMessage->Id;
      }
      catch ( MessageQueueException^ ) 
      {
         // Handle Message Queuing exceptions.
      }
      // Handle invalid serialization format.
      catch ( InvalidOperationException^ e ) 
      {
         Console::WriteLine( e->Message );
      }

      // Catch other exceptions as necessary.
      return returnString;
   }

   void ReceiveAcknowledgment( String^ messageId, String^ queuePath )
   {
      bool found = false;
      MessageQueue^ queue = gcnew MessageQueue( queuePath );
      queue->MessageReadPropertyFilter->CorrelationId = true;
      queue->MessageReadPropertyFilter->Acknowledgment = true;
      try
      {
         while ( queue->PeekByCorrelationId( messageId ) != nullptr )
         {
            Message^ myAcknowledgmentMessage = queue->ReceiveByCorrelationId( messageId );

            // Output acknowledgment message information. The correlation Id is identical
            // to the id of the original message.
            Console::WriteLine( "Acknowledgment Message Information--" );
            Console::WriteLine( "Correlation Id: {0}", myAcknowledgmentMessage->CorrelationId );
            Console::WriteLine( "Id: {0}", myAcknowledgmentMessage->Id );
            Console::WriteLine( "Acknowledgment Type: {0}", myAcknowledgmentMessage->Acknowledgment );
            Console::WriteLine( "____________________________________________" );
            found = true;
         }
      }
      catch ( InvalidOperationException^ e ) 
      {
         // This exception would be thrown if there is no (further) acknowledgment message
         // with the specified correlation Id. Only output a message if there are no messages;
         // not if the loop has found at least one.
         if ( found == false )
         {
            Console::WriteLine( e->Message );
         }

         // Handle other causes of invalid operation exception.
      }

   }

};

int main()
{
   // Create a new instance of the class.
   MyNewQueue^ myNewQueue = gcnew MyNewQueue;

   // Create new queues.
   MyNewQueue::CreateQueue( ".\\myQueue" );
   MyNewQueue::CreateQueue( ".\\myAdministrationQueue" );

   // Send messages to a queue.
   myNewQueue->SendMessage();

   // Receive messages from a queue.
   String^ messageId = myNewQueue->ReceiveMessage();

   // Receive acknowledgment message.
   if ( messageId != nullptr )
   {
      myNewQueue->ReceiveAcknowledgment( messageId, ".\\myAdministrationQueue" );
   }

   return 0;
}
// </Snippet1>

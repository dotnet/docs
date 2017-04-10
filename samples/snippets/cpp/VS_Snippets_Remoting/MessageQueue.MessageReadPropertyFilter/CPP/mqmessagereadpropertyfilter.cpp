

// <Snippet1>
#using <system.dll>
#using <system.messaging.dll>

using namespace System;
using namespace System::Messaging;
ref class MyNewQueue
{
public:

   //*************************************************
   // Retrieves the default properties for a Message.
   //*************************************************
   void RetrieveDefaultProperties()
   {
      // Connect to a message queue.
      MessageQueue^ myQueue = gcnew MessageQueue( ".\\myQueue" );

      // Specify to retrieve the default properties only.
      myQueue->MessageReadPropertyFilter->SetDefaults();

      // Set the formatter for the Message.
      array<Type^>^p = gcnew array<Type^>(1);
      p[ 0 ] = String::typeid;
      myQueue->Formatter = gcnew XmlMessageFormatter( p );

      // Receive the first message in the queue.
      Message^ myMessage = myQueue->Receive();

      // Display selected properties.
      Console::WriteLine( "Label: {0}", myMessage->Label );
      Console::WriteLine( "Body: {0}", static_cast<String^>(myMessage->Body) );
      return;
   }


   //*************************************************
   // Retrieves all properties for a Message.
   //*************************************************
   void RetrieveAllProperties()
   {
      // Connect to a message queue.
      MessageQueue^ myQueue = gcnew MessageQueue( ".\\myQueue" );

      // Specify to retrieve all properties.
      myQueue->MessageReadPropertyFilter->SetAll();

      // Set the formatter for the Message.
      array<Type^>^p = gcnew array<Type^>(1);
      p[ 0 ] = String::typeid;
      myQueue->Formatter = gcnew XmlMessageFormatter( p );

      // Receive the first message in the queue.
      Message^ myMessage = myQueue->Receive();

      // Display selected properties.
      Console::WriteLine( "Encryption algorithm: {0}", myMessage->EncryptionAlgorithm.ToString() );
      Console::WriteLine( "Body: {0}", myMessage->Body );
      return;
   }

   //*************************************************
   // Retrieves application-specific properties for a
   // Message.
   //*************************************************
   void RetrieveSelectedProperties()
   {
      // Connect to a message queue.
      MessageQueue^ myQueue = gcnew MessageQueue( ".\\myQueue" );

      // Specify to retrieve selected properties.
      MessagePropertyFilter^ myFilter = gcnew MessagePropertyFilter;
      myFilter->ClearAll();

      // The following list is a random subset of available properties.
      myFilter->Body = true;
      myFilter->Label = true;
      myFilter->MessageType = true;
      myFilter->Priority = true;
      myQueue->MessageReadPropertyFilter = myFilter;

      // Set the formatter for the Message.
      array<Type^>^p = gcnew array<Type^>(1);
      p[ 0 ] = String::typeid;
      myQueue->Formatter = gcnew XmlMessageFormatter( p );

      // Receive the first message in the queue.
      Message^ myMessage = myQueue->Receive();

      // Display selected properties.
      Console::WriteLine( "Message type: {0}", myMessage->MessageType.ToString() );
      Console::WriteLine( "Priority: {0}", myMessage->Priority.ToString() );
      return;
   }
};


//*************************************************
// Provides an entry point into the application.
//         
// This example retrieves specific groups of Message
// properties.
//*************************************************
int main()
{
   // Create a new instance of the class.
   MyNewQueue^ myNewQueue = gcnew MyNewQueue;

   // Retrieve specific sets of Message properties.
   myNewQueue->RetrieveDefaultProperties();
   myNewQueue->RetrieveAllProperties();
   myNewQueue->RetrieveSelectedProperties();
   return 0;
}
// </Snippet1>

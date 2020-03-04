

// <Snippet1>
#using <system.dll>
#using <system.messaging.dll>
#using <system.drawing.dll>

using namespace System;
using namespace System::Messaging;
using namespace System::Drawing;
using namespace System::IO;

/// <summary>
/// Provides a container class for the example.
/// </summary>
ref class MyNewQueue
{
public:

   //*************************************************
   // Creates a new queue.
   //*************************************************
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


   //*************************************************
   // Sends an image to a queue, using the BinaryMessageFormatter.
   //*************************************************
   void SendMessage()
   {
      try
      {
         
         // Create a new bitmap.
         // The file must be in the \bin\debug or \bin\retail folder, or
         // you must give a full path to its location.
         Image^ myImage = Bitmap::FromFile( "SentImage::bmp" );
         
         // Connect to a queue on the local computer.
         MessageQueue^ myQueue = gcnew MessageQueue( ".\\myQueue" );
         Message^ myMessage = gcnew Message( myImage,gcnew BinaryMessageFormatter );
         
         // Send the image to the queue.
         myQueue->Send( myMessage );
      }
      catch ( ArgumentException^ e ) 
      {
         Console::WriteLine( e->Message );
      }

      return;
   }


   //*************************************************
   // Receives a message containing an image.
   //*************************************************
   void ReceiveMessage()
   {
      try
      {
         
         // Connect to the a queue on the local computer.
         MessageQueue^ myQueue = gcnew MessageQueue( ".\\myQueue" );
         
         // Set the formatter to indicate body contains an Order.
         myQueue->Formatter = gcnew BinaryMessageFormatter;
         
         // Receive and format the message. 
         Message^ myMessage = myQueue->Receive();
         Bitmap^ myImage = static_cast<Bitmap^>(myMessage->Body);
         
         // This will be saved in the \bin\debug or \bin\retail folder.
         myImage->Save( "ReceivedImage::bmp", System::Drawing::Imaging::ImageFormat::Bmp );
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
      catch ( IOException^ e ) 
      {
         
         // Handle file access exceptions.
      }

      
      // Catch other exceptions as necessary.
      return;
   }

};


//*************************************************
// Provides an entry point into the application.
//         
// This example sends and receives a message from
// a queue.
//*************************************************
int main()
{
   
   // Create a new instance of the class.
   MyNewQueue^ myNewQueue = gcnew MyNewQueue;
   
   // Create a queue on the local computer.
   MyNewQueue::CreateQueue( ".\\myQueue" );
   
   // Send a message to a queue.
   myNewQueue->SendMessage();
   
   // Receive a message from a queue.
   myNewQueue->ReceiveMessage();
   return 0;
}

// </Snippet1>



// <Snippet1>
#using <System.dll>
#using <System.Messaging.dll>

using namespace System;
using namespace System::Messaging;

// placeholder; see complete definition elsewhere in this section
public ref class Order
{
public:
   void ShipItems(){}

};


// Creates the queue if it does not already exist.
void EnsureQueueExists( String^ path )
{
   if (  !MessageQueue::Exists( path ) )
   {
      MessageQueue::Create( path );
   }
}

int main()
{
   Console::WriteLine( "Processing Orders" );
   String^ queuePath = ".\\orders";
   EnsureQueueExists( queuePath );
   MessageQueue^ queue = gcnew MessageQueue( queuePath );
   array<String^>^temp0 = {"Order"};
   (dynamic_cast<XmlMessageFormatter^>(queue->Formatter))->TargetTypeNames = temp0;
   while ( true )
   {
      Order^ newOrder = dynamic_cast<Order^>(queue->Receive()->Body);
      newOrder->ShipItems();
   }
}

// </Snippet1>

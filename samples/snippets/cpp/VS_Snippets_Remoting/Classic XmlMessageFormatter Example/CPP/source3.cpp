

// <Snippet3>
#using <System.dll>
#using <System.Messaging.dll>

using namespace System;
using namespace System::Messaging;

// placeholder; see complete definition elsewhere in this section
public ref class Order
{
public:
   int itemId;
   int quantity;
   String^ address;
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
   String^ queuePath = ".\\orders";
   EnsureQueueExists( queuePath );
   MessageQueue^ queue = gcnew MessageQueue( queuePath );
   Order^ orderRequest = gcnew Order;
   orderRequest->itemId = 1025;
   orderRequest->quantity = 5;
   orderRequest->address = "One Microsoft Way";
   queue->Send( orderRequest );
   
   // This line uses a new method you define on the Order class:
   // orderRequest.PrintReceipt();
}

// </Snippet3>



// <Snippet1>
#using <system.dll>
#using <system.messaging.dll>

using namespace System;
using namespace System::Messaging;
using namespace System::Collections;
ref class MyNewQueue
{
public:

   // Gets a list of queues with a specified category.
   // Sends a broadcast message to all queues in that
   // category.
   void GetQueuesByCategory()
   {
      
      // Get a list of queues with the specified category.
      array<MessageQueue^>^QueueList = MessageQueue::GetPublicQueuesByCategory( Guid(" {00000000-0000-0000-0000-000000000001}") );
      
      // Send a broadcast message to each queue in the array.
      IEnumerator^ myEnum = QueueList->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         MessageQueue^ queueItem = safe_cast<MessageQueue^>(myEnum->Current);
         queueItem->Send( "Broadcast message." );
      }

      return;
   }


   // Gets a list of queues with a specified label.
   // Sends a broadcast message to all queues with that
   // label.
   void GetQueuesByLabel()
   {
      
      // Get a list of queues with the specified label.
      array<MessageQueue^>^QueueList = MessageQueue::GetPublicQueuesByLabel( "My Label" );
      
      // Send a broadcast message to each queue in the array.
      IEnumerator^ myEnum = QueueList->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         MessageQueue^ queueItem = safe_cast<MessageQueue^>(myEnum->Current);
         queueItem->Send( "Broadcast message." );
      }

      return;
   }


   // Gets a list of queues on a specified computer. 
   // Displays the list on screen.
   void GetQueuesByComputer()
   {
      
      // Get a list of queues on the specified computer.
      array<MessageQueue^>^QueueList = MessageQueue::GetPublicQueuesByMachine( "MyComputer" );
      
      // Display the paths of the queues in the list.
      IEnumerator^ myEnum = QueueList->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         MessageQueue^ queueItem = safe_cast<MessageQueue^>(myEnum->Current);
         Console::WriteLine( queueItem->Path );
      }

      return;
   }


   // Gets a list of all public queues.
   void GetAllPublicQueues()
   {
      
      // Get a list of public queues.
      array<MessageQueue^>^QueueList = MessageQueue::GetPublicQueues();
      return;
   }


   // Gets a list of all public queues that match 
   // specified criteria. Displays the list on 
   // screen.
   void GetPublicQueuesByCriteria()
   {
      
      // Define criteria to filter the queues.
      MessageQueueCriteria^ myCriteria = gcnew MessageQueueCriteria;
      myCriteria->CreatedAfter = DateTime::Now.Subtract( TimeSpan(1,0,0,0) );
      myCriteria->ModifiedBefore = DateTime::Now;
      myCriteria->MachineName = ".";
      myCriteria->Label = "My Queue";
      
      // Get a list of queues with that criteria.
      array<MessageQueue^>^QueueList = MessageQueue::GetPublicQueues( myCriteria );
      
      // Display the paths of the queues in the list.
      IEnumerator^ myEnum = QueueList->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         MessageQueue^ queueItem = safe_cast<MessageQueue^>(myEnum->Current);
         Console::WriteLine( queueItem->Path );
      }

      return;
   }


   // Gets a list of private queues on the local 
   // computer. Displays the list on screen.
   void GetPrivateQueues()
   {
      
      // Get a list of queues with the specified category.
      array<MessageQueue^>^QueueList = MessageQueue::GetPrivateQueuesByMachine( "." );
      
      // Display the paths of the queues in the list.
      IEnumerator^ myEnum = QueueList->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         MessageQueue^ queueItem = safe_cast<MessageQueue^>(myEnum->Current);
         Console::WriteLine( queueItem->Path );
      }

      return;
   }

};


// Provides an entry point into the application.
// This example gets lists of queues by a variety
// of criteria.
int main()
{
   
   // Create a new instance of the class.
   MyNewQueue^ myNewQueue = gcnew MyNewQueue;
   
   // Send normal and high priority messages.
   myNewQueue->GetQueuesByCategory();
   myNewQueue->GetQueuesByLabel();
   myNewQueue->GetQueuesByComputer();
   myNewQueue->GetAllPublicQueues();
   myNewQueue->GetPublicQueuesByCriteria();
   myNewQueue->GetPrivateQueues();
   return 0;
}

// </Snippet1>



// <Snippet1>
#using <system.dll>
#using <system.messaging.dll>

using namespace System;
using namespace System::Messaging;
ref class MyNewQueue
{
public:

   // References public queues.
   void SendPublic()
   {
      MessageQueue^ myQueue = gcnew MessageQueue( ".\\myQueue" );
      myQueue->Send( "Public queue by path name." );
      return;
   }


   // References private queues.
   void SendPrivate()
   {
      MessageQueue^ myQueue = gcnew MessageQueue( ".\\Private$\\myQueue" );
      myQueue->Send( "Private queue by path name." );
      return;
   }


   // References queues by label.
   void SendByLabel()
   {
      MessageQueue^ myQueue = gcnew MessageQueue( "Label:TheLabel" );
      myQueue->Send( "Queue by label." );
      return;
   }


   // References queues by format name.
   void SendByFormatName()
   {
      MessageQueue^ myQueue = gcnew MessageQueue( "FormatName:Public=5A5F7535-AE9A-41d4 -935C-845C2AFF7112" );
      myQueue->Send( "Queue by format name." );
      return;
   }


   // References computer journal queues.
   void MonitorComputerJournal()
   {
      MessageQueue^ computerJournal = gcnew MessageQueue( ".\\Journal$" );
      while ( true )
      {
         Message^ journalMessage = computerJournal->Receive();
         
         // Process the journal message.
      }
   }


   // References queue journal queues.
   void MonitorQueueJournal()
   {
      MessageQueue^ queueJournal = gcnew MessageQueue( ".\\myQueue\\Journal$" );
      while ( true )
      {
         Message^ journalMessage = queueJournal->Receive();
         
         // Process the journal message.
      }
   }


   // References dead-letter queues.
   void MonitorDeadLetter()
   {
      MessageQueue^ deadLetter = gcnew MessageQueue( ".\\DeadLetter$" );
      while ( true )
      {
         Message^ deadMessage = deadLetter->Receive();
         
         // Process the dead-letter message.
      }
   }


   // References transactional dead-letter queues.
   void MonitorTransactionalDeadLetter()
   {
      MessageQueue^ TxDeadLetter = gcnew MessageQueue( ".\\XactDeadLetter$" );
      while ( true )
      {
         Message^ txDeadLetter = TxDeadLetter->Receive();
         
         // Process the transactional dead-letter message.
      }
   }

};


//*************************************************
// Provides an entry point into the application.
//         
// This example demonstrates several ways to set
// a queue's path.
//*************************************************
int main()
{
   
   // Create a new instance of the class.
   MyNewQueue^ myNewQueue = gcnew MyNewQueue;
   myNewQueue->SendPublic();
   myNewQueue->SendPrivate();
   myNewQueue->SendByLabel();
   myNewQueue->SendByFormatName();
   myNewQueue->MonitorComputerJournal();
   myNewQueue->MonitorQueueJournal();
   myNewQueue->MonitorDeadLetter();
   myNewQueue->MonitorTransactionalDeadLetter();
   return 0;
}

// </Snippet1>

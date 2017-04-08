
//<snippet1>
using namespace System;
using namespace System::Threading;
ref class MyMainClass
{
public:
   static void MyReadThreadProc()
   {
      while ( true )
      {
         
         //The value will not be read until the writer has written
         // at least once since the last read.
         myResetEvent->WaitOne();
         Console::WriteLine( " {0} reading value: {1}", Thread::CurrentThread->Name, number );
      }
   }


   //Initially not signaled.
   static AutoResetEvent^ myResetEvent = gcnew AutoResetEvent( false );
   static int number;
   literal int numIterations = 100;
};

int main()
{
   
   //Create and start the reader thread.
   Thread^ myReaderThread = gcnew Thread( gcnew ThreadStart( MyMainClass::MyReadThreadProc ) );
   myReaderThread->Name = "ReaderThread";
   myReaderThread->Start();
   for ( int i = 1; i <= MyMainClass::numIterations; i++ )
   {
      Console::WriteLine( "Writer thread writing value: {0}", i );
      MyMainClass::number = i;
      
      //Signal that a value has been written.
      MyMainClass::myResetEvent->Set();
      
      //Give the Reader thread an opportunity to act.
      Thread::Sleep( 1 );

   }
   
   //Terminate the reader thread.
   myReaderThread->Abort();
}

//</snippet1>


//<Snippet1>
using namespace System;
using namespace System::Threading;
ref class ThreadWork
{
public:
   static void DoWork()
   {
      Console::WriteLine( "Working thread..." );
   }

};

int main()
{
   ThreadStart^ myThreadDelegate = gcnew ThreadStart( ThreadWork::DoWork );
   Thread^ myThread = gcnew Thread( myThreadDelegate );
   myThread->Start();
   Thread::Sleep( 0 );
   Console::WriteLine( "In main. Attempting to restart myThread." );
   try
   {
      myThread->Start();
   }
   catch ( ThreadStateException^ e ) 
   {
      Console::WriteLine( "Caught: {0}", e->Message );
   }

}

//</Snippet1>


//<Snippet1>
using namespace System;
using namespace System::Threading;

public ref class ThreadWork
{
public:
   static void DoWork()
   {
      for ( int i = 0; i < 3; i++ )
      {
         Console::WriteLine( "Working thread..." );
         Thread::Sleep( 100 );
      }
   }
};

int main()
{
   ThreadStart^ myThreadDelegate = gcnew ThreadStart(&ThreadWork::DoWork);
   Thread^ thread1 = gcnew Thread( myThreadDelegate );
   thread1->Start();
   for ( int i = 0; i < 3; i++ )
   {
      Console::WriteLine( "In main." );
      Thread::Sleep( 100 );
   }
}
// The example displays output like the following:
//       In main.
//       Working thread...
//       In main.
//       Working thread...
//       In main.
//       Working thread...
//</Snippet1>

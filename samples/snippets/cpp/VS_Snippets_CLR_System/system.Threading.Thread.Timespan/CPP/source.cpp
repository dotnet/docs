
// <Snippet1>
using namespace System;
using namespace System::Threading;

static TimeSpan waitTime = TimeSpan(0,0,1);

ref class Test
{
public:
   static void Work()
   {
      Thread::Sleep( waitTime );
   }

};

int main()
{
   Thread^ newThread = gcnew Thread( gcnew ThreadStart( Test::Work ) );
   newThread->Start();
   if ( newThread->Join( waitTime + waitTime ) )
   {
      Console::WriteLine( "New thread terminated." );
   }
   else
   {
      Console::WriteLine( "Join timed out." );
   }
}
// The example displays the following output:
//        New thread terminated.
// </Snippet1>

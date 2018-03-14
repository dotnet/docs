
// <Snippet1>
using namespace System;
using namespace System::Threading;
ref class WaitOne
{
private:
   WaitOne(){}


public:
   static void WorkMethod( Object^ stateInfo )
   {
      Console::WriteLine( "Work starting." );
      
      // Simulate time spent working.
      Thread::Sleep( (gcnew Random)->Next( 100, 2000 ) );
      
      // Signal that work is finished.
      Console::WriteLine( "Work ending." );
      dynamic_cast<AutoResetEvent^>(stateInfo)->Set();
   }

};

int main()
{
   Console::WriteLine( "Main starting." );
   AutoResetEvent^ autoEvent = gcnew AutoResetEvent( false );
   ThreadPool::QueueUserWorkItem( gcnew WaitCallback( &WaitOne::WorkMethod ), autoEvent );
   
   // Wait for work method to signal.
   if ( autoEvent->WaitOne( 1000 ) )
   {
      Console::WriteLine( "Work method signaled." );
   }
   else
   {
      Console::WriteLine( "Timed out waiting for work "
      "method to signal." );
   }

   Console::WriteLine( "Main ending." );
}

// </Snippet1>

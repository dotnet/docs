
// <Snippet1>
using namespace System;
using namespace System::Threading;
int main()
{
   
   // Check whether the thread has previously been named to
   // avoid a possible InvalidOperationException.
   if ( Thread::CurrentThread->Name == nullptr )
   {
      Thread::CurrentThread->Name =  "MainThread";
   }
   else
   {
      Console::WriteLine( "Unable to name a previously "
      "named thread." );
   }
}

// </Snippet1>

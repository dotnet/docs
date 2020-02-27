
// <Snippet1>
using namespace System;
using namespace System::Threading;
int main()
{
   int minWorker;
   int minIOC;
   
   // Get the current settings.
   ThreadPool::GetMinThreads( minWorker, minIOC );
   
   // Change the minimum number of worker threads to four, but
   // keep the old setting for minimum asynchronous I/O
   // completion threads.
   if ( ThreadPool::SetMinThreads( 4, minIOC ) )
   {
      
      // The minimum number of threads was set successfully.
   }
   else
   {
      
      // The minimum number of threads was not changed.
   }
}

// </Snippet1>

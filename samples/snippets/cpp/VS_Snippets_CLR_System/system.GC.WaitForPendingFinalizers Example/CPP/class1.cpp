
//<snippet1>
using namespace System;
ref class MyFinalizeObject
{
private:

   // Make this number very large to cause the finalizer to
   // do more work.
   literal int maxIterations = 10000;
   ~MyFinalizeObject()
   {
      Console::WriteLine( "Finalizing a MyFinalizeObject" );
      
      // Do some work.
      for ( int i = 0; i < maxIterations; i++ )
      {
         
         // This method performs no operation on i, but prevents
         // the JIT compiler from optimizing away the code inside
         // the loop.
         GC::KeepAlive( i );

      }
   }

};


// You can increase this number to fill up more memory.
const int numMfos = 1000;

// You can increase this number to cause more
// post-finalization work to be done.
const int maxIterations = 100;
int main()
{
   MyFinalizeObject^ mfo = nullptr;
   
   // Create and release a large number of objects
   // that require finalization.
   for ( int j = 0; j < numMfos; j++ )
   {
      mfo = gcnew MyFinalizeObject;

   }
   
   //Release the last object created in the loop.
   mfo = nullptr;
   
   //Force garbage collection.
   GC::Collect();
   
   // Wait for all finalizers to complete before continuing.
   // Without this call to GC::WaitForPendingFinalizers,
   // the worker loop below might execute at the same time
   // as the finalizers.
   // With this call, the worker loop executes only after
   // all finalizers have been called.
   GC::WaitForPendingFinalizers();
   
   // Worker loop to perform post-finalization code.
   for ( int i = 0; i < maxIterations; i++ )
   {
      Console::WriteLine( "Doing some post-finalize work" );

   }
}

//</snippet1>

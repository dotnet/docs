
// <Snippet1>
using namespace System;

const int maxGarbage = 1000;

void MakeSomeGarbage()
{
   Version^ vt;
   for ( int i = 0; i < maxGarbage; i++ ) {
      // Create objects and release them to fill up memory with unused objects.
      vt = gcnew Version;
   }
}

void main()
{
   // Put some objects in memory.
   MakeSomeGarbage();
   Console::WriteLine("Memory used before collection:       {0:N0}", 
                      GC::GetTotalMemory( false ) );
   
   // Collect all generations of memory.
   GC::Collect();
   Console::WriteLine("Memory used after full collection:   {0:N0}", 
                      GC::GetTotalMemory( true ) );
}
// The output from the example resembles the following:
//       Memory used before collection:       79,392
//       Memory used after full collection:   52,640
// </Snippet1>

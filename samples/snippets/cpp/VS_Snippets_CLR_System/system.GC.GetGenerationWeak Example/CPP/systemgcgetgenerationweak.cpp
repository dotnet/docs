
//<snippet1>
using namespace System;
ref class MyGCCollectClass
{
private:
   static const long maxGarbage = 1000;

public:
   void MakeSomeGarbage()
   {
      Version^ vt;
      for ( int i = 0; i < maxGarbage; i++ )
      {
         
         // Create objects and release them to fill up memory
         // with unused objects.
         vt = gcnew Version;

      }
   }

};

int main()
{
   
   // Create a strong reference to an Object.
   MyGCCollectClass^ myGCCol = gcnew MyGCCollectClass;
   
   // Put some objects in memory.
   myGCCol->MakeSomeGarbage();
   
   // Get the generation of managed memory where myGCCol is stored.
   Console::WriteLine( "The object is in generation: {0}", GC::GetGeneration( myGCCol ) );
   
   // Perform a full garbage collection.
   // Because there is a strong reference to myGCCol, it will
   // not be garbage collected.
   GC::Collect();
   
   // Get the generation of managed memory where myGCCol is stored.
   Console::WriteLine( "The object is in generation: {0}", GC::GetGeneration( myGCCol ) );
   
   // Create a WeakReference to myGCCol.
   WeakReference^ wkref = gcnew WeakReference( myGCCol );
   
   // Remove the strong reference to myGCCol.
   myGCCol = nullptr;
   
   // Get the generation of managed memory where wkref is stored.
   Console::WriteLine( "The WeakReference to the object is in generation: {0}", GC::GetGeneration( wkref ) );
   
   // Perform another full garbage collection.
   // A WeakReference will not survive a garbage collection.
   GC::Collect();
   
   // Try to get the generation of managed memory where wkref is stored.
   // Because it has been collected, an exception will be thrown.
   try
   {
      Console::WriteLine( "The WeakReference to the object is in generation: {0}", GC::GetGeneration( wkref ) );
      Console::Read();
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "The WeakReference to the object has been garbage collected: ' {0}'", e );
   }

}

//</snippet1>

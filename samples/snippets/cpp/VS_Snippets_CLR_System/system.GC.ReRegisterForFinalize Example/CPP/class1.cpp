
//<snippet1>
using namespace System;
ref class MyFinalizeObject
{
public:
   static MyFinalizeObject^ currentInstance = nullptr;

private:
   bool hasFinalized;

public:
   MyFinalizeObject()
   {
      hasFinalized = false;
   }

   ~MyFinalizeObject()
   {
      if ( hasFinalized == false )
      {
         Console::WriteLine( "First finalization" );
         
         // Put this object back into a root by creating
         // a reference to it.
         MyFinalizeObject::currentInstance = this;
         
         // Indicate that this instance has finalized once.
         hasFinalized = true;
         
         // Place a reference to this object back in the
         // finalization queue.
         GC::ReRegisterForFinalize( this );
      }
      else
      {
         Console::WriteLine( "Second finalization" );
      }
   }

};

int main()
{
   
   // Create a MyFinalizeObject.
   MyFinalizeObject^ mfo = gcnew MyFinalizeObject;
   
   // Release the reference to mfo.
   mfo = nullptr;
   
   // Force a garbage collection.
   GC::Collect();
   
   // At this point mfo will have gone through the first Finalize.
   // There should now be a reference to mfo in the static
   // MyFinalizeObject::currentInstance field.  Setting this value
   // to 0 and forcing another garbage collection will now
   // cause the object to Finalize permanently.
   MyFinalizeObject::currentInstance = nullptr;
   GC::Collect();
}

//</snippet1>

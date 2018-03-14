// REDMOND\glennha - Revised for v2.0 syntax.
//<snippet1>
#using <System.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;

// The following example demonstrates how to create a class that 
// implements the IDisposable interface and the IDisposable.Dispose
// method with finalization to clean up unmanaged resources. 
//
public ref class MyResource: public IDisposable
{
private:

   // Pointer to an external unmanaged resource.
   IntPtr handle;

   // A managed resource this class uses.
   Component^ component;

   // Track whether Dispose has been called.
   bool disposed;

public:
   // The class constructor.
   MyResource( IntPtr handle, Component^ component )
   {
      this->handle = handle;
      this->component = component;
      disposed = false;
   }

   // This method is called if the user explicitly disposes of the
   // object (by calling the Dispose method in other managed languages, 
   // or the destructor in C++). The compiler emits as a call to 
   // GC::SuppressFinalize( this ) for you, so there is no need to 
   // call it here.
   ~MyResource() 
   {
      // Dispose of managed resources.
      component->~Component();

      // Call C++ finalizer to clean up unmanaged resources.
      this->!MyResource();

      // Mark the class as disposed. This flag allows you to throw an
      // exception if a disposed object is accessed.
      disposed = true;
   }

   // Use interop to call the method necessary to clean up the 
   // unmanaged resource.
   //
   [System::Runtime::InteropServices::DllImport("Kernel32")]
   static Boolean CloseHandle( IntPtr handle );

   // The C++ finalizer destructor ensures that unmanaged resources get
   // released if the user releases the object without explicitly 
   // disposing of it.
   //
   !MyResource()
   {      
      // Call the appropriate methods to clean up unmanaged 
      // resources here. If disposing is false when Dispose(bool,
      // disposing) is called, only the following code is executed.
      CloseHandle( handle );
      handle = IntPtr::Zero;
   }

};

void main()
{
   // Insert code here to create and use the MyResource object.
   MyResource^ mr = gcnew MyResource((IntPtr) 42, (Component^) gcnew Button());
   mr->~MyResource();
}
//</snippet1>

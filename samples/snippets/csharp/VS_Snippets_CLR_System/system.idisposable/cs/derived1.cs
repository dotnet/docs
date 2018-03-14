// <Snippet4>
using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.InteropServices;

class DerivedClass : BaseClass
{
   // Flag: Has Dispose already been called?
   bool disposed = false;
   // Instantiate a SafeHandle instance.
   SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

   // Protected implementation of Dispose pattern.
   protected override void Dispose(bool disposing)
   {
      if (disposed)
         return; 
      
      if (disposing) {
         handle.Dispose();
         // Free any other managed objects here.
         //
      }
      
      // Free any unmanaged objects here.
      //

      disposed = true;
      // Call base class implementation.
      base.Dispose(disposing);
   }
}
// </Snippet4>

class BaseClass : IDisposable
{
   // Flag: Has Dispose already been called?
   bool disposed = false;
   
   // Public implementation of Dispose pattern callable by consumers.
   public void Dispose()
   { 
      Dispose(true);
      GC.SuppressFinalize(this);           
   }
   
   // Protected implementation of Dispose pattern.
   protected virtual void Dispose(bool disposing)
   {
      if (disposed)
         return; 
      
      if (disposing) {
         // Free any other managed objects here.
         //
      }
      
      // Free any unmanaged objects here.
      //
      disposed = true;
   }
}
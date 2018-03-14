//<Snippet1>
using System;  

namespace UsageLibrary
{
   public class  TypeB : IDisposable
   {
      // Assume this type has some unmanaged resources.
      TypeA aFieldOfADisposableType = new TypeA();
      private bool disposed = false;

      protected virtual void Dispose(bool disposing) 
      {
         if (!disposed) 
         {
            // Dispose of resources held by this instance.

            // Violates rule: DisposableFieldsShouldBeDisposed.
            // Should call aFieldOfADisposableType.Dispose();

            disposed = true;
             // Suppress finalization of this disposed instance.
             if (disposing)
             {
                 GC.SuppressFinalize(this);
             }
         }
      }

      public void Dispose()
      {
         if (!disposed)
         {
            // Dispose of resources held by this instance.
            Dispose(true);
         }
      }

      // Disposable types implement a finalizer.
      ~TypeB()
      {
         Dispose(false);
      }
   }
}
//</Snippet1>
namespace UsageLibrary
{
    public class TypeA
    {
    }
}

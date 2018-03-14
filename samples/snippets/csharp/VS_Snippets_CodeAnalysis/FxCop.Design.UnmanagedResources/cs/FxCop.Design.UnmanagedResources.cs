//<Snippet1>
using System;

namespace DesignLibrary
{
    public class UnmanagedResources : IDisposable
    {
        IntPtr unmanagedResource;
        bool disposed = false;

        public UnmanagedResources() 
        {
            // Allocate the unmanaged resource ...
        }

        public void Dispose() 
        {
            Dispose(true);
            GC.SuppressFinalize(this); 
        }

        protected virtual void Dispose(bool disposing)
        {
            if(!disposed)
            {
                if(disposing)
                {
                    // Release managed resources.
                }

                // Free the unmanaged resource ...

                unmanagedResource = IntPtr.Zero;

                disposed = true;
            }
        }

        ~UnmanagedResources()
        {
            Dispose(false);
        }
    }
}
//</Snippet1>

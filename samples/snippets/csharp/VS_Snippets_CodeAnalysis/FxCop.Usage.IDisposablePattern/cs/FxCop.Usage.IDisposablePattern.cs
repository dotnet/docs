//<Snippet1>
using System;  

namespace UsageLibrary
{
    public class  TypeA :IDisposable
    {
     
        protected virtual void Dispose(bool disposing) 
        {
            if (disposing) 
            {
                // Dispose managed resources
            }

            // Free native resources
        }

        public void Dispose()
        {

                Dispose(true);

                GC.SuppressFinalize(this);

        }

        // Disposable types implement a finalizer.
        ~TypeA()
        {
            Dispose(false);
        }
    }
}
//</Snippet1>

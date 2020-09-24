using System;

namespace ca2215
{
    public class TypeA : IDisposable
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

    public class TypeB : TypeA
    {
        protected override void Dispose(bool disposing)
        {
            if (!disposing)
            {
                base.Dispose(false);
            }
        }
    }
}

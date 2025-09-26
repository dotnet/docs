using System;
using System.IO;

namespace ca1816
{
    //<snippet1>
    public class MyStreamClass : IDisposable
    {
        private MemoryStream? _stream = new();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(true);  // Violates rule
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _stream?.Dispose();
                _stream = null;
            }
        }
    }
    //</snippet1>
}

namespace ca1816_2
{
    //<snippet2>
    public class MyStreamClass : IDisposable
    {
        private MemoryStream? _stream = new();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _stream?.Dispose();
                _stream = null;
            }
        }
    }
    //</snippet2>
}

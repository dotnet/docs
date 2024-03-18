// <Snippet3>
using System;
using System.IO;
using System.Runtime.InteropServices;

class BaseClass1 : IDisposable
{
    // Flag: Has Dispose already been called?
    bool disposed = false;
    // Instantiate a FileStream instance.
    FileStream fs = new FileStream("test.txt", FileMode.OpenOrCreate);

    // Public implementation of Dispose pattern callable by consumers.
    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    // Protected implementation of Dispose pattern.
    protected virtual void Dispose(bool disposing)
    {
        if (disposed)
            return;

        if (disposing)
        {
            fs.Dispose();
            // Free any other managed objects here.
            //
        }

        disposed = true;
    }
}
// </Snippet3>

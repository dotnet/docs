// <Snippet4>
using System;
using System.IO;
using System.Runtime.InteropServices;

class MyDerivedClass : MyBaseClass
{
    // Flag: Has Dispose already been called?
    bool disposed = false;
    // Instantiate a FileStream instance.
    FileStream fs = new FileStream("test.txt", FileMode.OpenOrCreate);

    // Protected implementation of Dispose pattern.
    protected override void Dispose(bool disposing)
    {
        if (disposed)
            return;

        if (disposing)
        {
            fs.Dispose();
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

class MyBaseClass : IDisposable
{
    // Flag: Has Dispose already been called?
    bool disposed = false;

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
            // Free any other managed objects here.
            //
        }

        // Free any unmanaged objects here.
        //
        disposed = true;
    }
}

// <Snippet6>
using System;

class DerivedClass : BaseClass
{
    // To detect redundant calls
    bool _disposed = false;

    ~DerivedClass() => Dispose(false);

    // Protected implementation of Dispose pattern.
    protected override void Dispose(bool disposing)
    {
        if (_disposed)
        {
            return;
        }

        if (disposing)
        {
            // TODO: dispose managed state (managed objects).
        }

        // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
        // TODO: set large fields to null.
        _disposed = true;

        // Call the base class implementation.
        base.Dispose(disposing);
    }
}
// </Snippet6>

class BaseClass : IDisposable
{
    // Flag: Has Dispose already been called?
    bool _disposed = false;

    ~BaseClass() => Dispose(false);

    // Public implementation of Dispose pattern callable by consumers.
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    // Protected implementation of Dispose pattern.
    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
        {
            return;
        }

        if (disposing)
        {
            // Free any other managed objects here.
        }

        // Free any unmanaged objects here.
        _disposed = true;
    }
}
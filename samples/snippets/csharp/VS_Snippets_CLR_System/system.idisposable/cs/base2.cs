using System;

class BaseClassWithFinalizer : IDisposable
{
    // To detect redundant calls
    private bool _disposed = false;

    ~BaseClassWithFinalizer() => Dispose(false);

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
        	// Dispose managed objects that implement IDisposable.
	        // Assign null to managed objects that consume large amounts of memory or consume scarce resources.
        }

        // Free unmanaged resources (unmanaged objects).

        _disposed = true;
    }
}

class DerivedClassWithFinalizer : BaseClassWithFinalizer
{
    // To detect redundant calls
    bool _disposed = false;

    ~DerivedClassWithFinalizer() => this.Dispose(false);

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

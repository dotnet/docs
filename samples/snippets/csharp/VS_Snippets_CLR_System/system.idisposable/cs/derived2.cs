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
            // Dispose managed objects that implement IDisposable.
	        // Assign null to managed objects that consume large amounts of memory or consume scarce resources.
        }

        // Free unmanaged resources (unmanaged objects).
        _disposed = true;

        // Call the base class implementation.
        base.Dispose(disposing);
    }
}

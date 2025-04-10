using System.IO;

public class DisposableDerived : DisposableBase
{
    // To detect redundant calls
    private bool _isDisposed;

    // Instantiate a disposable object owned by this class.
    private Stream? _managedResource = new MemoryStream();

    // Protected implementation of Dispose pattern.
    protected override void Dispose(bool disposing)
    {
        if (!_isDisposed)
        {
            _isDisposed = true;

            if (disposing)
            {
                _managedResource?.Dispose();
                _managedResource = null;
            }
        }

        // Call base class implementation.
        base.Dispose(disposing);
    }
}

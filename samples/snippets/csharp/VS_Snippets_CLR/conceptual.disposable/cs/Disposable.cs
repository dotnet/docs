using System;

public class Disposable : IDisposable
{
    // <SnippetDispose>
    public void Dispose()
    {
        // Dispose of unmanaged resources.
        Dispose(true);
        // Suppress finalization.
        GC.SuppressFinalize(this);
    }
    // </SnippetDispose>

    // <SnippetDisposeBool>
    protected virtual void Dispose(bool disposing)
    {
    }
    // </SnippetDisposeBool>
}

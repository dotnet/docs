using System;
using System.IO;
using System.Threading.Tasks;

namespace Samples
{
    public class CustomDisposable : IDisposable, IAsyncDisposable
    {
        bool _disposed;

        IDisposable _disposableResource = new MemoryStream();
        IAsyncDisposable _asyncDisposableResource = new MemoryStream();

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public async ValueTask DisposeAsync()
        {
            await DisposeAsyncCore();

            Dispose(disposing: false);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;

                if (disposing)
                {
                    _disposableResource?.Dispose();
                    (_asyncDisposableResource as IDisposable)?.Dispose();
                }

                _disposableResource = null;
                _asyncDisposableResource = null;
            }
        }

        protected virtual async ValueTask DisposeAsyncCore()
        {
            if (!_disposed)
            {
                _disposed = true;

                if (_asyncDisposableResource is not null)
                {
                    await _asyncDisposableResource.DisposeAsync().ConfigureAwait(false);
                }

                if (_disposableResource is IAsyncDisposable disposable)
                {
                    await disposable.DisposeAsync().ConfigureAwait(false);
                }
                else
                {
                    _disposableResource.Dispose();
                }

                _asyncDisposableResource = null;
                _disposableResource = null;
            }
        }
    }
}

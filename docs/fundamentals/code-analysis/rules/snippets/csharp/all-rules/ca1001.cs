using System;
using System.IO;

namespace ca1001
{
    //<snippet1>
    // This class violates the rule.
    public class NoDisposeMethod
    {
        FileStream _newFile;

        public NoDisposeMethod()
        {
            _newFile = new FileStream(@"c:\temp.txt", FileMode.Open);
        }
    }

    // This class satisfies the rule.
    public class HasDisposeMethod : IDisposable
    {
        FileStream _newFile;

        public HasDisposeMethod()
        {
            _newFile = new FileStream(@"c:\temp.txt", FileMode.Open);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Dispose managed resources.
                _newFile.Close();
            }
            // Free native resources.
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
    //</snippet1>
}

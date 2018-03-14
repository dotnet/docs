// <Snippet1>
using System;
using System.Threading;

class LockHeld
{
    static void Main()
    {
        ReaderWriterLock rwLock = new ReaderWriterLock();

        rwLock.AcquireWriterLock(Timeout.Infinite);
        rwLock.AcquireReaderLock(Timeout.Infinite);

        if(rwLock.IsReaderLockHeld)
        {
            Console.WriteLine("Reader lock held.");
            rwLock.ReleaseReaderLock();
        }
        else if(rwLock.IsWriterLockHeld)
        {
            Console.WriteLine("Writer lock held.");
            rwLock.ReleaseWriterLock();
        }
        else
        {
            Console.WriteLine("No locks held.");
        }

        if(rwLock.IsReaderLockHeld)
        {
            Console.WriteLine("Reader lock held.");
            rwLock.ReleaseReaderLock();
        }
        else if(rwLock.IsWriterLockHeld)
        {
            Console.WriteLine("Writer lock held.");
            rwLock.ReleaseWriterLock();
        }
        else
        {
            Console.WriteLine("No locks held.");
        }
    }
}
// </Snippet1>
//<Snippet1>
using System;
using System.Threading;
using System.Collections.Generic;

public class SynchronizedCache 
{
    //<Snippet2>
    private ReaderWriterLockSlim cacheLock = new ReaderWriterLockSlim();
    private Dictionary<int, string> innerCache = new Dictionary<int, string>();
    //</Snippet2>

    //<Snippet3>
    public string Read(int key)
    {
        cacheLock.EnterReadLock();
        try
        {
            return innerCache[key];
        }
        finally
        {
            cacheLock.ExitReadLock();
        }
    }
    //</Snippet3>

    //<Snippet4>
    public void Add(int key, string value)
    {
        cacheLock.EnterWriteLock();
        try
        {
            innerCache.Add(key, value);
        }
        finally
        {
            cacheLock.ExitWriteLock();
        }
    }
    //</Snippet4>

    //<Snippet5>
    public bool AddWithTimeout(int key, string value, int timeout)
    {
        if (cacheLock.TryEnterWriteLock(timeout))
        {
            try
            {
                innerCache.Add(key, value);
            }
            finally
            {
                cacheLock.ExitWriteLock();
            }
            return true;
        }
        else
        {
            return false;
        }
    }
    //</Snippet5>

    //<Snippet6>
    public AddOrUpdateStatus AddOrUpdate(int key, string value)
    {
        cacheLock.EnterUpgradeableReadLock();
        try
        {
            string result = null;
            if (innerCache.TryGetValue(key, out result))
            {
                if (result == value)
                {
                    return AddOrUpdateStatus.Unchanged;
                }
                else
                {
                    cacheLock.EnterWriteLock();
                    try
                    {
                        innerCache[key] = value;
                    }
                    finally
                    {
                        cacheLock.ExitWriteLock();
                    }
                    return AddOrUpdateStatus.Updated;
                }
            }
            else
            {
                cacheLock.EnterWriteLock();
                try
                {
                    innerCache.Add(key, value);
                }
                finally
                {
                    cacheLock.ExitWriteLock();
                }
                return AddOrUpdateStatus.Added;
            }
        }
        finally
        {
            cacheLock.ExitUpgradeableReadLock();
        }
    }
    //</Snippet6>

    //<Snippet7>
    public void Delete(int key)
    {
        cacheLock.EnterWriteLock();
        try
        {
            innerCache.Remove(key);
        }
        finally
        {
            cacheLock.ExitWriteLock();
        }
    }
    //</Snippet7>

    //<Snippet10>
    public enum AddOrUpdateStatus
    {
        Added,
        Updated,
        Unchanged
    };
    //</Snippet10>

    ~SynchronizedCache()
    {
       if (cacheLock != null) cacheLock.Dispose();
    }
}
//</Snippet1>



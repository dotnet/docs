using System;
using System.Threading;

class Example
{
    private static object lockObject = new object();

    public static void Main()
    {
        T1();
        T2();
        T3();
    }

    public static void T1()
    {
        //<Snippet2>
        bool acquiredLock = false;

        try
        {
            Monitor.Enter(lockObject, ref acquiredLock);

            // Code that accesses resources that are protected by the lock.

        }
        finally
        {
            if (acquiredLock)
            {
                Monitor.Exit(lockObject);
            }
        }
        //</Snippet2>

    }

    public static void T2()
    {
        //<Snippet3>
        bool acquiredLock = false;

        try
        {
            Monitor.TryEnter(lockObject, ref acquiredLock);
            if (acquiredLock)
            {

                // Code that accesses resources that are protected by the lock.

            }
            else
            {
            
                // Code to deal with the fact that the lock was not acquired.

            }
        }
        finally
        {
            if (acquiredLock)
            {
                Monitor.Exit(lockObject);
            }
        }
        //</Snippet3>

    }

    public static void T3()
    {

        //<Snippet4>
        bool acquiredLock = false;

        try
        {
            Monitor.TryEnter(lockObject, 500, ref acquiredLock);
            if (acquiredLock)
            {

                // Code that accesses resources that are protected by the lock.

            }
            else
            {
            
                // Code to deal with the fact that the lock was not acquired.

            }
        }
        finally
        {
            if (acquiredLock)
            {
                Monitor.Exit(lockObject);
            }
        }
        //</Snippet4>

    }
}



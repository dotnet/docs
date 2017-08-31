using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace csrefKeywordsFixedLock
{

    //class Point { public int x = 0, y = 0; }

    class FixedTest
    {
        //<snippet1>
        unsafe static void TestMethod()
        {
            
            // Assume that the following class exists.
            //class Point 
            //{ 
            //    public int x;
            //    public int y; 
            //}

            // Variable pt is a managed variable, subject to garbage collection.
            Point pt = new Point();

            // Using fixed allows the address of pt members to be taken,
            // and "pins" pt so that it is not relocated.
            
            fixed (int* p = &pt.x)
            {
                *p = 1;
            }        
           
        }
        //</snippet1> 



        //<snippet2>
        static unsafe void Test2()
        {
            Point point = new Point();
            double[] arr = { 0, 1.5, 2.3, 3.4, 4.0, 5.9 };
            string str = "Hello World";

            // The following two assignments are equivalent. Each assigns the address
            // of the first element in array arr to pointer p.

            // You can initialize a pointer by using an array.
            fixed (double* p = arr) { /*...*/ }

            // You can initialize a pointer by using the address of a variable. 
            fixed (double* p = &arr[0]) { /*...*/ }

            // The following assignment initializes p by using a string.
            fixed (char* p = str) { /*...*/ }

            // The following assignment is not valid, because str[0] is a char, 
            // which is a value, not a variable.
            //fixed (char* p = &str[0]) { /*...*/ } 


            // You can initialize a pointer by using the address of a variable, such
            // as point.x or arr[5].
            //<snippet3>
            fixed (int* p1 = &point.x)
            {
                fixed (double* p2 = &arr[5])
                {
                    // Do something with p1 and p2.
                }
            }
            //</snippet3>
        }
        //</snippet2>

    }

    //<snippet4>
    class Point
    { 
        public int x, y; 
    }

    class FixedTest2 
    {
        // Unsafe method: takes a pointer to an int.
        unsafe static void SquarePtrParam (int* p) 
        {
            *p *= *p;
        }

        unsafe static void Main() 
        {
            Point pt = new Point();
            pt.x = 5;
            pt.y = 6;
            // Pin pt in place:
            fixed (int* p = &pt.x) 
            {
                SquarePtrParam (p);
            }
            // pt now unpinned.
            Console.WriteLine ("{0} {1}", pt.x, pt.y);
        }
    }
    /*
    Output:
    25 6
     */

    //</snippet4>

    //<snippet5>
    //using System.Threading;

    class ThreadTest
    {
        public void RunMe()
        {
            Console.WriteLine("RunMe called");
        }

        static void Main()
        {
            ThreadTest b = new ThreadTest();
            Thread t = new Thread(b.RunMe);
            t.Start();
        }
    }
    // Output: RunMe called

    //</snippet5>

    //<snippet6>
    // using System.Threading;

    class Account
    {
        private Object thisLock = new Object();
        int balance;

        Random r = new Random();

        public Account(int initial)
        {
            balance = initial;
        }

        int Withdraw(int amount)
        {

            // This condition never is true unless the lock statement
            // is commented out.
            if (balance < 0)
            {
                throw new Exception("Negative Balance");
            }

            // Comment out the next line to see the effect of leaving out 
            // the lock keyword.
            lock (thisLock)
            {
                if (balance >= amount)
                {
                    Console.WriteLine("Balance before Withdrawal :  " + balance);
                    Console.WriteLine("Amount to Withdraw        : -" + amount);
                    balance = balance - amount;
                    Console.WriteLine("Balance after Withdrawal  :  " + balance);
                    return amount;
                }
                else
                {
                    return 0; // transaction rejected
                }
            }
        }

        public void DoTransactions()
        {
            for (int i = 0; i < 100; i++)
            {
                Withdraw(r.Next(1, 100));
            }
        }
    }

    class Test
    {
        static void Main()
        {
            Thread[] threads = new Thread[10];
            Account acc = new Account(1000);
            for (int i = 0; i < 10; i++)
            {
                Thread t = new Thread(new ThreadStart(acc.DoTransactions));
                threads[i] = t;
            }
            for (int i = 0; i < 10; i++)
            {
                threads[i].Start();
            }
        }
    }

    //</snippet6>
}
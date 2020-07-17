//<Snippet1>
using System;
using System.Reflection;
using System.Runtime.ExceptionServices;

class Example
{
    static void Main()
    {
        AppDomain.CurrentDomain.FirstChanceException += FirstChanceHandler;

        // Create a set of application domains, with a Worker object in each one.
        // Each Worker object creates the next application domain.
        AppDomain ad = AppDomain.CreateDomain("AD0");
        Worker w = (Worker) ad.CreateInstanceAndUnwrap(
                                typeof(Worker).Assembly.FullName, "Worker");
        w.Initialize(0, 3);

        Console.WriteLine("\r\nThe last application domain throws an exception and catches it:");
        Console.WriteLine();
        w.TestException(true);

        try
        {
            Console.WriteLine(
                "\r\nThe last application domain throws an exception and does not catch it:");
            Console.WriteLine();
            w.TestException(false);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("ArgumentException caught in {0}: {1}",
                AppDomain.CurrentDomain.FriendlyName, ex.Message);
        }
    }

    static void FirstChanceHandler(object source, FirstChanceExceptionEventArgs e)
    {
        Console.WriteLine("FirstChanceException event raised in {0}: {1}",
            AppDomain.CurrentDomain.FriendlyName, e.Exception.Message);
    }
}

public class Worker : MarshalByRefObject
{
    private AppDomain ad = null;
    private Worker w = null;

    public void Initialize(int count, int max)
    {
        // Handle the FirstChanceException event in all application domains except
        // AD1.
        if (count != 1)
        {
            AppDomain.CurrentDomain.FirstChanceException += FirstChanceHandler;
        }

        // Create another application domain, until the maximum is reached.
        // Field w remains null in the last application domain, as a signal
        // to TestException().
        if (count < max)
        {
            int next = count + 1;
            ad = AppDomain.CreateDomain("AD" + next);
            w = (Worker) ad.CreateInstanceAndUnwrap(
                             typeof(Worker).Assembly.FullName, "Worker");
            w.Initialize(next, max);
        }
    }

    public void TestException(bool handled)
    {
        // As long as there is another application domain, call TestException() on
        // its Worker object. When the last application domain is reached, throw a
        // handled or unhandled exception.
        if (w != null)
        {
            w.TestException(handled);
        }
        else if (handled)
        {
            try
            {
                throw new ArgumentException("Thrown in " + AppDomain.CurrentDomain.FriendlyName);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("ArgumentException caught in {0}: {1}",
                    AppDomain.CurrentDomain.FriendlyName, ex.Message);
            }
        }
        else
        {
            throw new ArgumentException("Thrown in " + AppDomain.CurrentDomain.FriendlyName);
        }
    }

    static void FirstChanceHandler(object source, FirstChanceExceptionEventArgs e)
    {
        Console.WriteLine("FirstChanceException event raised in {0}: {1}",
            AppDomain.CurrentDomain.FriendlyName, e.Exception.Message);
    }
}

/* This example produces output similar to the following:

The last application domain throws an exception and catches it:

FirstChanceException event raised in AD3: Thrown in AD3
ArgumentException caught in AD3: Thrown in AD3

The last application domain throws an exception and does not catch it:

FirstChanceException event raised in AD3: Thrown in AD3
FirstChanceException event raised in AD2: Thrown in AD3
FirstChanceException event raised in AD0: Thrown in AD3
FirstChanceException event raised in Example.exe: Thrown in AD3
ArgumentException caught in Example.exe: Thrown in AD3
 */
//</Snippet1>

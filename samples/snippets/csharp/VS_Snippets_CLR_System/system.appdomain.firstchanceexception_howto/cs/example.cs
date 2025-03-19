//<Snippet1>
using System;
using System.Reflection;
using System.Runtime.ExceptionServices;

class Example
{
    static void Main()
    {
        // To receive first chance notifications of exceptions in
        // an application domain, handle the FirstChanceException
        // event in that application domain.
        //<Snippet2>
        AppDomain ad = AppDomain.CreateDomain("AD1");
        ad.FirstChanceException += FirstChanceHandler;
        //</Snippet2>

        // Create a worker object in the application domain.
        //<Snippet4>
        Worker w = (Worker) ad.CreateInstanceAndUnwrap(
                                typeof(Worker).Assembly.FullName, "Worker");
        //</Snippet4>

        //<Snippet6>
        // The worker throws an exception and catches it.
        w.Thrower(true);

        try
        {
            // The worker throws an exception and doesn't catch it.
            w.Thrower(false);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"ArgumentException caught in {AppDomain.CurrentDomain.FriendlyName}: {ex.Message}");
        }
        //</Snippet6>
    }

    //<Snippet3>
    static void FirstChanceHandler(object source, FirstChanceExceptionEventArgs e)
    {
        Console.WriteLine($"FirstChanceException event raised in {AppDomain.CurrentDomain.FriendlyName}: {e.Exception.Message}");
    }
    //</Snippet3>
}

public class Worker : MarshalByRefObject
{
    public void Thrower(bool catchException)
    {
        //<Snippet5>
        if (catchException)
        {
            try
            {
                throw new ArgumentException("Thrown in " + AppDomain.CurrentDomain.FriendlyName);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"ArgumentException caught in {AppDomain.CurrentDomain.FriendlyName}: {ex.Message}");
            }
        }
        else
        {
            throw new ArgumentException("Thrown in " + AppDomain.CurrentDomain.FriendlyName);
        }
        //</Snippet5>
    }
}

/* This example produces output similar to the following:

FirstChanceException event raised in AD1: Thrown in AD1
ArgumentException caught in AD1: Thrown in AD1
FirstChanceException event raised in AD1: Thrown in AD1
ArgumentException caught in Example.exe: Thrown in AD1
 */
//</Snippet1>

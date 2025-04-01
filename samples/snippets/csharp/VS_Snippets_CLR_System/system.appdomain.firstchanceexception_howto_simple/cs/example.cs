//<Snippet1>
//<Snippet2>
using System;
using System.Runtime.ExceptionServices;

class Example
{
    static void Main()
    {
        AppDomain.CurrentDomain.FirstChanceException +=
            (object source, FirstChanceExceptionEventArgs e) =>
            {
                Console.WriteLine($"FirstChanceException event raised in {AppDomain.CurrentDomain.FriendlyName}: {e.Exception.Message}");
            };
        //</Snippet2>

        //<Snippet3>
        try
        {
            throw new ArgumentException("Thrown in " + AppDomain.CurrentDomain.FriendlyName);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"ArgumentException caught in {AppDomain.CurrentDomain.FriendlyName}: {ex.Message}");
        }
        //</Snippet3>

        //<Snippet4>
        throw new ArgumentException("Thrown in " + AppDomain.CurrentDomain.FriendlyName);
    }
}
//</Snippet4>

//<Snippet5>
/* This example produces output similar to the following:

FirstChanceException event raised in Example.exe: Thrown in Example.exe
ArgumentException caught in Example.exe: Thrown in Example.exe
FirstChanceException event raised in Example.exe: Thrown in Example.exe

Unhandled Exception: System.ArgumentException: Thrown in Example.exe
   at Example.Main()
 */
//</Snippet5>
//</Snippet1>

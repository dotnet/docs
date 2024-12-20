using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateExamples;
class NamedDelegate
{
    static NamedDelegate obj = new NamedDelegate();

    //<NamedDelegate>
    // Declare a delegate.
    delegate void WorkCallback(int x);

    // Define a named method.
    void DoWork(int k) { /* ... */ }

    // Instantiate the delegate using the method as a parameter.
    WorkCallback d = obj.DoWork;
    //</NamedDelegate>
}

class AnonymousDelegate
{
    static AnonymousDelegate obj = new AnonymousDelegate();

    //<SnippetAnonymousMethod>
    // Declare a delegate.
    delegate void WorkCallback(int x);

    // Instantiate the delegate using an anonymous method.
    WorkCallback d = (int k) => { /* ... */ };
    //</SnippetAnonymousMethod>
}

//<DeclareAndUse>
// Declare a delegate
delegate void MultiplyCallback(int i, double j);

class MathClass
{
    static void Main()
    {
        MathClass m = new MathClass();

        // Delegate instantiation using "MultiplyNumbers"
        MultiplyCallback d = m.MultiplyNumbers;

        // Invoke the delegate object.
        Console.WriteLine("Invoking the delegate using 'MultiplyNumbers':");
        for (int i = 1; i <= 5; i++)
        {
            d(i, 2);
        }

        // Keep the console window open in debug mode.
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }

    // Declare the associated method.
    void MultiplyNumbers(int m, double n)
    {
        Console.Write(m * n + " ");
    }
}
/* Output:
    Invoking the delegate using 'MultiplyNumbers':
    2 4 6 8 10
*/
//</DeclareAndUse>

//<AnotherSample>
// Declare a delegate
delegate void Callback();

class SampleClass
{
    public void InstanceMethod()
    {
        Console.WriteLine("A message from the instance method.");
    }

    static public void StaticMethod()
    {
        Console.WriteLine("A message from the static method.");
    }
}

class TestSampleClass
{
    static void Main()
    {
        var sc = new SampleClass();

        // Map the delegate to the instance method:
        Callback d = sc.InstanceMethod;
        d();

        // Map to the static method:
        d = SampleClass.StaticMethod;
        d();
    }
}
/* Output:
    A message from the instance method.
    A message from the static method.
*/
//</AnotherSample>

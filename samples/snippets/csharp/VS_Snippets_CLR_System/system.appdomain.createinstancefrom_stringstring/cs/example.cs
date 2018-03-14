//<Snippet1>
using System;

public interface ITest
{
    void Test(string greeting);
}

public class MarshallableExample : MarshalByRefObject, ITest
{
    static void Main()
    {
        // Construct a path to the current assembly.
        string assemblyPath = Environment.CurrentDirectory + "\\" +
            typeof(MarshallableExample).Assembly.GetName().Name + ".exe";

        AppDomain ad = AppDomain.CreateDomain("MyDomain");
 
        System.Runtime.Remoting.ObjectHandle oh = 
            ad.CreateInstanceFrom(assemblyPath, "MarshallableExample");

        object obj = oh.Unwrap();


        // Three ways to use the newly created object, depending on how
        // much is known about the type: Late bound, early bound through 
        // a mutually known interface, or early binding of a known type.
        //
        obj.GetType().InvokeMember("Test", 
            System.Reflection.BindingFlags.InvokeMethod, 
            Type.DefaultBinder, obj, new object[] { "Hello" });

        ITest it = (ITest) obj;
        it.Test("Hi");

        MarshallableExample ex = (MarshallableExample) obj;
        ex.Test("Goodbye");
    }

    public void Test(string greeting)
    {
        Console.WriteLine("{0} from '{1}'!", greeting,
            AppDomain.CurrentDomain.FriendlyName);
    }
}

/* This example produces the following output:

Hello from 'MyDomain'!
Hi from 'MyDomain'!
Goodbye from 'MyDomain'!
 */
//</Snippet1>

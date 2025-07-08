using System;

namespace DelegateExamples;
public class UsingDelegates
{
    //<DeclareDelegate>
    public delegate void Callback(string message);
    //</DeclareDelegate>

    //<DelegateMethod>
    // Create a method for a delegate.
    public static void DelegateMethod(string message)
    {
        Console.WriteLine(message);
    }
    //</DelegateMethod>

    public static void Examples()
    {
        //<UseDelegate>
        // Instantiate the delegate.
        Callback handler = DelegateMethod;

        // Call the delegate.
        handler("Hello World");
        //</UseDelegate>

        //<DelegateArgument>
        MethodWithCallback(1, 2, handler);
        //</DelegateArgument>

        //<UseInstanceDelegates>
        var obj = new MethodClass();
        Callback d1 = obj.Method1;
        Callback d2 = obj.Method2;
        Callback d3 = DelegateMethod;

        //Both types of assignment are valid.
        Callback allMethodsDelegate = d1 + d2;
        allMethodsDelegate += d3;
        //</UseInstanceDelegates>

        //<RemoveAddDelegates>
        //remove Method1
        allMethodsDelegate -= d1;

        // copy AllMethodsDelegate while removing d2
        Callback oneMethodDelegate = (allMethodsDelegate - d2)!;
        //</RemoveAddDelegates>

        //<GetInvocationList>
        int invocationCount = d1.GetInvocationList().GetLength(0);
        //</GetInvocationList>
    }

    //<DelegateParameter>
    public static void MethodWithCallback(int param1, int param2, Callback callback)
    {
        callback("The number is: " + (param1 + param2).ToString());
    }
    //</DelegateParameter>
}

//<InstanceMethods>
public class MethodClass
{
    public void Method1(string message) { }
    public void Method2(string message) { }
}
//</InstanceMethods>


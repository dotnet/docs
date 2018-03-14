//<Snippet1>
using System;
using System.Reflection;
using System.Reflection.Emit;
using Microsoft.VisualBasic;

public class Test
{
    // Declare a delegate that will be used to execute the completed
    // dynamic method. 
    private delegate int HelloInvoker(string msg, int ret);

    public static void Main()
    {
        // Create an array that specifies the types of the parameters
        // of the dynamic method. This method has a string parameter
        // and an int parameter.
        Type[] helloArgs = {typeof(string), typeof(int)};

        // Create a dynamic method with the name "Hello", a return type
        // of int, and two parameters whose types are specified by the
        // array helloArgs. Create the method in the module that
        // defines the Test class.
        DynamicMethod hello = new DynamicMethod("Hello", 
            typeof(int), 
            helloArgs, 
            typeof(Test).Module);

        // <Snippet2>
        // Create an array that specifies the parameter types of the
        // overload of Console.WriteLine to be used in Hello.
        Type[] writeStringArgs = {typeof(string)};
        // Get the overload of Console.WriteLine that has one
        // String parameter.
        MethodInfo writeString = 
            typeof(Console).GetMethod("WriteLine", writeStringArgs);

        // Get an ILGenerator and emit a body for the dynamic method.
        ILGenerator il = hello.GetILGenerator();
        // Load the first argument, which is a string, onto the stack.
        il.Emit(OpCodes.Ldarg_0);
        // Call the overload of Console.WriteLine that prints a string.
        il.EmitCall(OpCodes.Call, writeString, null);
        // The Hello method returns the value of the second argument;
        // to do this, load the onto the stack and return.
        il.Emit(OpCodes.Ldarg_1);
        il.Emit(OpCodes.Ret);
        // </Snippet2>

        // <Snippet3>
        // Create a delegate that represents the dynamic method. This
        // action completes the method, and any further attempts to
        // change the method will cause an exception.
        HelloInvoker hi = 
            (HelloInvoker) hello.CreateDelegate(typeof(HelloInvoker));
        // </Snippet3>

        // Use the delegate to execute the dynamic method. Save and
        // print the return value.
        int retval = hi("\r\nHello, World!", 42);
        Console.WriteLine("Executing delegate hi(\"Hello, World!\", 42) returned {0}",
            retval);

        // Do it again, with different arguments.
        retval = hi("\r\nHi, Mom!", 5280);
        Console.WriteLine("Executing delegate hi(\"Hi, Mom!\", 5280) returned {0}",
            retval);
        
        // <Snippet4>
        // Create an array of arguments to use with the Invoke method.
        object[] invokeArgs = {"\r\nHello, World!", 42};
        // Invoke the dynamic method using the arguments. This is much
        // slower than using the delegate, because you must create an
        // array to contain the arguments, and ValueType arguments
        // must be boxed.
        object objRet = hello.Invoke(null, invokeArgs);
        Console.WriteLine("hello.Invoke returned {0}", objRet);
        // </Snippet4>
    }
}
//</Snippet1>
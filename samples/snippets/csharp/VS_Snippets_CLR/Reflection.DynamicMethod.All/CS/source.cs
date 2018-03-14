// REDMOND\glennha
// <Snippet1>
using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Globalization;

public class Test
{
    // Declare a delegate type that can be used to execute the completed
    // dynamic method. 
    private delegate int HelloDelegate(string msg, int ret);

    public static void Main()
    {
        // Create an array that specifies the types of the parameters
        // of the dynamic method. This dynamic method has a String
        // parameter and an Integer parameter.
        Type[] helloArgs = {typeof(string), typeof(int)};

        // Create a dynamic method with the name "Hello", a return type
        // of Integer, and two parameters whose types are specified by
        // the array helloArgs. Create the method in the module that
        // defines the String class.
        DynamicMethod hello = new DynamicMethod("Hello", 
            typeof(int), 
            helloArgs, 
            typeof(string).Module);

        // <Snippet2>
        // Create an array that specifies the parameter types of the
        // overload of Console.WriteLine to be used in Hello.
        Type[] writeStringArgs = {typeof(string)};
        // Get the overload of Console.WriteLine that has one
        // String parameter.
        MethodInfo writeString = typeof(Console).GetMethod("WriteLine", 
            writeStringArgs);

        // Get an ILGenerator and emit a body for the dynamic method,
        // using a stream size larger than the IL that will be
        // emitted.
        ILGenerator il = hello.GetILGenerator(256);
        // Load the first argument, which is a string, onto the stack.
        il.Emit(OpCodes.Ldarg_0);
        // Call the overload of Console.WriteLine that prints a string.
        il.EmitCall(OpCodes.Call, writeString, null);
        // The Hello method returns the value of the second argument;
        // to do this, load the onto the stack and return.
        il.Emit(OpCodes.Ldarg_1);
        il.Emit(OpCodes.Ret);
        // </Snippet2>

        // <Snippet33>
        // Add parameter information to the dynamic method. (This is not
        // necessary, but can be useful for debugging.) For each parameter,
        // identified by position, supply the parameter attributes and a 
        // parameter name.
        hello.DefineParameter(1, ParameterAttributes.In, "message");
        hello.DefineParameter(2, ParameterAttributes.In, "valueToReturn");
        // </Snippet33>

        // <Snippet3>
        // Create a delegate that represents the dynamic method. This
        // action completes the method. Any further attempts to
        // change the method are ignored.
        HelloDelegate hi = 
            (HelloDelegate) hello.CreateDelegate(typeof(HelloDelegate));

        // Use the delegate to execute the dynamic method.
        Console.WriteLine("\r\nUse the delegate to execute the dynamic method:");
        int retval = hi("\r\nHello, World!", 42);
        Console.WriteLine("Invoking delegate hi(\"Hello, World!\", 42) returned: " + retval);

        // Execute it again, with different arguments.
        retval = hi("\r\nHi, Mom!", 5280);
        Console.WriteLine("Invoking delegate hi(\"Hi, Mom!\", 5280) returned: " + retval);
        // </Snippet3>

        // <Snippet4>
        Console.WriteLine("\r\nUse the Invoke method to execute the dynamic method:");
        // Create an array of arguments to use with the Invoke method.
        object[] invokeArgs = {"\r\nHello, World!", 42};
        // Invoke the dynamic method using the arguments. This is much
        // slower than using the delegate, because you must create an
        // array to contain the arguments, and value-type arguments
        // must be boxed.
        object objRet = hello.Invoke(null, BindingFlags.ExactBinding, null, invokeArgs, new CultureInfo("en-us"));
        Console.WriteLine("hello.Invoke returned: " + objRet);
        // </Snippet4>

        Console.WriteLine("\r\n ----- Display information about the dynamic method -----");
        // <Snippet21>
        // Display MethodAttributes for the dynamic method, set when 
        // the dynamic method was created.
        Console.WriteLine("\r\nMethod Attributes: {0}", hello.Attributes);
        // </Snippet21>

        // <Snippet22>
        // Display the calling convention of the dynamic method, set when the 
        // dynamic method was created.
        Console.WriteLine("\r\nCalling convention: {0}", hello.CallingConvention);
        // </Snippet22>

        // <Snippet23>
        // Display the declaring type, which is always null for dynamic
        // methods.
        if (hello.DeclaringType == null)
        {
            Console.WriteLine("\r\nDeclaringType is always null for dynamic methods.");
        }
        else
        {
            Console.WriteLine("DeclaringType: {0}", hello.DeclaringType);
        }
        // </Snippet23>

        // <Snippet24>
        // Display the default value for InitLocals.
        if (hello.InitLocals)
        {
            Console.Write("\r\nThis method contains verifiable code.");
        }
        else
        {
            Console.Write("\r\nThis method contains unverifiable code.");
        }
        Console.WriteLine(" (InitLocals = {0})", hello.InitLocals);
        // </Snippet24>

        // <Snippet26>
        // Display the module specified when the dynamic method was created.
        Console.WriteLine("\r\nModule: {0}", hello.Module);
        // </Snippet26>

        // <Snippet27>
        // Display the name specified when the dynamic method was created.
        // Note that the name can be blank.
        Console.WriteLine("\r\nName: {0}", hello.Name);
        // </Snippet27>

        // <Snippet28>
        // For dynamic methods, the reflected type is always null.
        if (hello.ReflectedType == null)
        {
            Console.WriteLine("\r\nReflectedType is null.");
        }
        else
        {
            Console.WriteLine("\r\nReflectedType: {0}", hello.ReflectedType);
        }
        // </Snippet28>

        // <Snippet29>
        if (hello.ReturnParameter == null)
        {
            Console.WriteLine("\r\nMethod has no return parameter.");
        }
        else
        {
            Console.WriteLine("\r\nReturn parameter: {0}", hello.ReturnParameter);
        }
        // </Snippet29>

        // <Snippet30>
        // If the method has no return type, ReturnType is System.Void.
        Console.WriteLine("\r\nReturn type: {0}", hello.ReturnType);
        // </Snippet30>

        // <Snippet31>
        // ReturnTypeCustomAttributes returns an ICustomeAttributeProvider
        // that can be used to enumerate the custom attributes of the
        // return value. At present, there is no way to set such custom
        // attributes, so the list is empty.
        if (hello.ReturnType == typeof(void))
        {
            Console.WriteLine("The method has no return type.");
        }
        else
        {
            ICustomAttributeProvider caProvider = hello.ReturnTypeCustomAttributes;
            object[] returnAttributes = caProvider.GetCustomAttributes(true);
            if (returnAttributes.Length == 0)
            {
                Console.WriteLine("\r\nThe return type has no custom attributes.");
            }
            else
            {
                Console.WriteLine("\r\nThe return type has the following custom attributes:");
                foreach( object attr in returnAttributes )
                {
                    Console.WriteLine("\t{0}", attr.ToString());
                }
            }
        }
        // </Snippet31>

        // <Snippet32>
        Console.WriteLine("\r\nToString: {0}", hello.ToString());
        // </Snippet32>

        // <Snippet34>
        // Display parameter information.
        ParameterInfo[] parameters = hello.GetParameters();
        Console.WriteLine("\r\nParameters: name, type, ParameterAttributes");
        foreach( ParameterInfo p in parameters )
        {
            Console.WriteLine("\t{0}, {1}, {2}", 
                p.Name, p.ParameterType, p.Attributes);
        }
        // </Snippet34>
    }
}

/* This code example produces the following output:

Use the delegate to execute the dynamic method:

Hello, World!
Invoking delegate hi("Hello, World!", 42) returned: 42

Hi, Mom!
Invoking delegate hi("Hi, Mom!", 5280) returned: 5280

Use the Invoke method to execute the dynamic method:

Hello, World!
hello.Invoke returned: 42

 ----- Display information about the dynamic method -----

Method Attributes: PrivateScope, Public, Static

Calling convention: Standard

DeclaringType is always null for dynamic methods.

This method contains verifiable code. (InitLocals = True)

Module: CommonLanguageRuntimeLibrary

Name: Hello

ReflectedType is null.

Method has no return parameter.

Return type: System.Int32

The return type has no custom attributes.

ToString: Int32 Hello(System.String, Int32)

Parameters: name, type, ParameterAttributes
        message, System.String, In
        valueToReturn, System.Int32, In
 */
// </Snippet1>




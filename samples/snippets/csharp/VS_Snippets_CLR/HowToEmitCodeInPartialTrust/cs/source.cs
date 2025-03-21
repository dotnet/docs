//<Snippet1>
using System;
using System.Reflection.Emit;
using System.Reflection;
using System.Security;
using System.Security.Permissions;
using System.Security.Policy;
using System.Collections;
using System.Diagnostics;

// This code example works properly only if it is run from a fully
// trusted location, such as your local computer.

// Delegates used to execute the dynamic methods.
//
public delegate void Test(Worker w);
public delegate void Test1();
public delegate char Test2(String instance);

// The Worker class must inherit MarshalByRefObject so that its public
// methods can be invoked across application domain boundaries.
//
//<Snippet10>
public class Worker : MarshalByRefObject
{
//</Snippet10>
    private void PrivateMethod()
    {
        Console.WriteLine("Worker.PrivateMethod()");
    }

    //<Snippet11>
    public void SimpleEmitDemo()
    {
        //<Snippet15>
        DynamicMethod meth = new DynamicMethod("", null, null);
        ILGenerator il = meth.GetILGenerator();
        il.EmitWriteLine("Hello, World!");
        il.Emit(OpCodes.Ret);
        //</Snippet15>

        Test1 t1 = (Test1) meth.CreateDelegate(typeof(Test1));
        t1();
    }
    //</Snippet11>

    // This overload of AccessPrivateMethod emits a dynamic method and
    // specifies whether to skip JIT visiblity checks. It creates a
    // delegate for the method and invokes the delegate. The dynamic
    // method calls a private method of the Worker class.
    public void AccessPrivateMethod(bool restrictedSkipVisibility)
    {
        // Create an unnamed dynamic method that has no return type,
        // takes one parameter of type Worker, and optionally skips JIT
        // visiblity checks.
        DynamicMethod meth = new DynamicMethod(
            "",
            null,
            new Type[] { typeof(Worker) },
            restrictedSkipVisibility);

        // Get a MethodInfo for the private method.
        MethodInfo pvtMeth = typeof(Worker).GetMethod("PrivateMethod",
            BindingFlags.NonPublic | BindingFlags.Instance);

        // Get an ILGenerator and emit a body for the dynamic method.
        ILGenerator il = meth.GetILGenerator();

        // Load the first argument, which is the target instance, onto the
        // execution stack, call the private method, and return.
        il.Emit(OpCodes.Ldarg_0);
        il.EmitCall(OpCodes.Call, pvtMeth, null);
        il.Emit(OpCodes.Ret);

        // Create a delegate that represents the dynamic method, and
        // invoke it.
        try
        {
            Test t = (Test) meth.CreateDelegate(typeof(Test));
            try
            {
                t(this);
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} was thrown when the delegate was invoked.",
                    ex.GetType().Name);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("{0} was thrown when the delegate was compiled.",
                ex.GetType().Name);
        }
    }

    // This overload of AccessPrivateMethod emits a dynamic method that takes
    // a string and returns the first character, using a private field of the
    // String class. The dynamic method skips JIT visiblity checks.
    public void AccessPrivateMethod()
    {
        //<Snippet16>
        DynamicMethod meth = new DynamicMethod("",
                                               typeof(char),
                                               new Type[] { typeof(String) },
                                               true);
        //</Snippet16>

        // Get a MethodInfo for the 'get' accessor of the private property.
        PropertyInfo pi = typeof(System.String).GetProperty(
            "FirstChar",
            BindingFlags.NonPublic | BindingFlags.Instance);
        MethodInfo pvtMeth = pi.GetGetMethod(true);

        // Get an ILGenerator and emit a body for the dynamic method.
        ILGenerator il = meth.GetILGenerator();

        // Load the first argument, which is the target string, onto the
        // execution stack, call the 'get' accessor to put the result onto
        // the execution stack, and return.
        il.Emit(OpCodes.Ldarg_0);
        il.EmitCall(OpCodes.Call, pvtMeth, null);
        il.Emit(OpCodes.Ret);

        // Create a delegate that represents the dynamic method, and
        // invoke it.
        try
        {
            Test2 t = (Test2) meth.CreateDelegate(typeof(Test2));
            char first = t("Hello, World!");
            Console.WriteLine($"{first} is the first character.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("{0} was thrown when the delegate was compiled.",
                ex.GetType().Name);
        }
    }

    // The entry point for the code example.
    static void Main()
    {
        // Get the display name of the executing assembly, to use when
        // creating objects to run code in application domains.
        //<Snippet14>
        String asmName = typeof(Worker).Assembly.FullName;
        //</Snippet14>

        // Create the permission set to grant to other assemblies. In this
        // case they are the permissions found in the Internet zone.
        //<Snippet2>
        Evidence ev = new Evidence();
        ev.AddHostEvidence(new Zone(SecurityZone.Internet));
        PermissionSet pset = new NamedPermissionSet("Internet", SecurityManager.GetStandardSandbox(ev));
        //</Snippet2>

        // For simplicity, set up the application domain to use the
        // current path as the application folder, so the same executable
        // can be used in both trusted and untrusted scenarios. Normally
        // you would not do this with real untrusted code.
        //<Snippet3>
        AppDomainSetup adSetup = new AppDomainSetup();
        adSetup.ApplicationBase = ".";
        //</Snippet3>

        // Create an application domain in which all code that executes is
        // granted the permissions of an application run from the Internet.
        //<Snippet5>
        AppDomain ad = AppDomain.CreateDomain("Sandbox", ev, adSetup, pset, null);
        //</Snippet5>

        // Create an instance of the Worker class in the partially trusted
        // domain. Note: If you build this code example in Visual Studio,
        // you must change the name of the class to include the default
        // namespace, which is the project name. For example, if the project
        // is "AnonymouslyHosted", the class is "AnonymouslyHosted.Worker".
        //<Snippet12>
        Worker w = (Worker) ad.CreateInstanceAndUnwrap(asmName, "Worker");
        //</Snippet12>

        // Emit a simple dynamic method that prints "Hello, World!"
        //<Snippet13>
        w.SimpleEmitDemo();
        //</Snippet13>

        // Emit and invoke a dynamic method that calls a private method
        // of Worker, with JIT visibility checks enforced. The call fails
        // when the delegate is invoked.
        w.AccessPrivateMethod(false);

        // Emit and invoke a dynamic method that calls a private method
        // of Worker, skipping JIT visibility checks. The call fails when
        // the method is invoked.
        w.AccessPrivateMethod(true);

        // Unload the application domain. Add RestrictedMemberAccess to the
        // grant set, and use it to create an application domain in which
        // partially trusted code can call private members, as long as the
        // trust level of those members is equal to or lower than the trust
        // level of the partially trusted code.
        AppDomain.Unload(ad);
        //<Snippet7>
        pset.SetPermission(
            new ReflectionPermission(
                ReflectionPermissionFlag.RestrictedMemberAccess));
        //</Snippet7>
        //<Snippet8>
        ad = AppDomain.CreateDomain("Sandbox2", ev, adSetup, pset, null);
        //</Snippet8>

        // Create an instance of the Worker class in the partially trusted
        // domain.
        w = (Worker) ad.CreateInstanceAndUnwrap(asmName, "Worker");

        // Again, emit and invoke a dynamic method that calls a private method
        // of Worker, skipping JIT visibility checks. This time compilation
        // succeeds because of the grant for RestrictedMemberAccess.
        w.AccessPrivateMethod(true);

        // Finally, emit and invoke a dynamic method that calls an internal
        // method of the String class. The call fails, because the trust level
        // of the assembly that contains String is higher than the trust level
        // of the assembly that emits the dynamic method.
        w.AccessPrivateMethod();
    }
}

/* This code example produces the following output:

Hello, World!
MethodAccessException was thrown when the delegate was invoked.
MethodAccessException was thrown when the delegate was invoked.
Worker.PrivateMethod()
MethodAccessException was thrown when the delegate was compiled.
 */
//</Snippet1>
//<Snippet1>
// New example (user feedback bug 23592) GlennHa 1/4/06
using System;
using System.Reflection;
using System.Reflection.Emit;

public class Example
{
    // The type used for this code example is the System.Timers.Timer 
    // class. The Timer object is stored in a variable of type object,
    // and all code that accesses the Timer does so late-bound. This
    // is because the scenario in which you might use the AddEVentHander
    // method is when you load the type after the program is already
    // compiled, when it is not possible to use the C# += syntax to
    // hook up the event. (Note that there is no "using" statement
    // for the System.Timers namespace.)
    //
    private static object timer;

    public static void Main()
    {
        // Get the assembly that contains the Timer type (Sytem.dll). 
        // The following code uses the fact that System.dll has the
        // same public key as mscorlib.dll to construct a string
        // representing the full assembly name. 
        string fullName = "";
        foreach (Assembly assem in AppDomain.CurrentDomain.GetAssemblies())
        {
            if (assem.GetName().Name == "mscorlib")
            {
                fullName = assem.FullName;
            }
        }
        Assembly sys = Assembly.Load("System" + fullName.Substring(fullName.IndexOf(",")));

        // Get a Type object representing the Timer type.
        Type t = sys.GetType("System.Timers.Timer");

        // Create an instance of the Timer type.
        timer = Activator.CreateInstance(t);

        // Use reflection to get the Elapsed event.
        EventInfo eInfo = t.GetEvent("Elapsed");

        // In order to create a method to handle the Elapsed event,
        // it is necessary to know the signature of the delegate 
        // used to raise the event. Reflection.Emit can then be
        // used to construct a dynamic class with a static method
        // that has the correct signature.
 
        // Get the event handler type of the Elapsed event. This is
        // a delegate type, so it has an Invoke method that has
        // the same signature as the delegate. The following code
        // creates an array of Type objects that represent the 
        // parameter types of the Invoke method.
        //
        Type handlerType = eInfo.EventHandlerType;
        MethodInfo invokeMethod = handlerType.GetMethod("Invoke");
        ParameterInfo[] parms = invokeMethod.GetParameters();
        Type[] parmTypes = new Type[parms.Length];
        for (int i = 0; i < parms.Length; i++)
        {
            parmTypes[i] = parms[i].ParameterType;
        }

        // Use Reflection.Emit to create a dynamic assembly that
        // will be run but not saved. An assembly must have at 
        // least one module, which in this case contains a single
        // type. The only purpose of this type is to contain the 
        // event handler method. (In the .NET Framework version 
        // 2.0 you can use dynamic methods, which are simpler 
        // because there is no need to create an assembly, module,
        // or type.)
        AssemblyName aName = new AssemblyName();
        aName.Name = "DynamicTypes";
        AssemblyBuilder ab = AppDomain.CurrentDomain.DefineDynamicAssembly(aName, AssemblyBuilderAccess.Run);
        ModuleBuilder mb = ab.DefineDynamicModule(aName.Name);
        TypeBuilder tb = mb.DefineType("Handler", TypeAttributes.Class | TypeAttributes.Public);

        // Create the method that will handle the event. The name
        // is not important. The method is static, because there is
        // no reason to create an instance of the dynamic type.
        //
        // The parameter types and return type of the method are
        // the same as those of the delegate's Invoke method, 
        // captured earlier.
        MethodBuilder handler = tb.DefineMethod("DynamicHandler", 
            MethodAttributes.Public | MethodAttributes.Static, 
            invokeMethod.ReturnType, parmTypes);

        // Generate code to handle the event. In this case, the 
        // handler simply prints a text string to the console.
        //
        ILGenerator il = handler.GetILGenerator();
        il.EmitWriteLine("Timer's Elapsed event is raised.");
        il.Emit(OpCodes.Ret);

        // CreateType must be called before the Handler type can
        // be used. In order to create the delegate that will
        // handle the event, a MethodInfo from the finished type
        // is required.
        Type finished = tb.CreateType();
        MethodInfo eventHandler = finished.GetMethod("DynamicHandler");

        // Use the MethodInfo to create a delegate of the correct 
        // type, and call the AddEventHandler method to hook up 
        // the event.
        Delegate d = Delegate.CreateDelegate(handlerType, eventHandler);
        eInfo.AddEventHandler(timer, d);

        // Late-bound calls to the Interval and Enabled property 
        // are required to enable the timer with a one-second
        // interval.
        t.InvokeMember("Interval", BindingFlags.SetProperty, null, timer, new Object[] { 1000 });
        t.InvokeMember("Enabled", BindingFlags.SetProperty, null, timer, new Object[] { true });

        Console.WriteLine("Press the Enter key to end the program.");
        Console.ReadLine();
    }
}
/* This code example produces output similar to the following:

Press the Enter key to end the program.
Timer's Elapsed event is raised.
Timer's Elapsed event is raised.
Timer's Elapsed event is raised.
 */
//</Snippet1>

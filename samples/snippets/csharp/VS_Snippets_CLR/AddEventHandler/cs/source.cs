using System;
using System.Reflection;
using System.Reflection.Emit;

public class Example
{
    private static object timer;

    public static void Main()
    {
        // Get the Timer type.
        Type t = typeof(System.Timers.Timer);
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
        // event handler method. (You can use also dynamic methods, 
        // which are simpler because there is no need to create an 
        // assembly, module, or type.)
        //
        AssemblyName aName = new AssemblyName();
        aName.Name = "DynamicTypes";
        AssemblyBuilder ab = AssemblyBuilder.DefineDynamicAssembly(aName, AssemblyBuilderAccess.Run);
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
/* This example produces output similar to the following:

Press the Enter key to end the program.
Timer's Elapsed event is raised.
Timer's Elapsed event is raised.
Timer's Elapsed event is raised.
*/

// <Snippet1>
// The following example uses instances of classes in 
// the System.Reflection namespace to discover an event argument type.
using System;
using System.Reflection;

public delegate void MyDelegate(int i);
public class MainClass 
{
    public event MyDelegate ev;

    public static void Main() 
    {
        Type delegateType = typeof(MainClass).GetEvent("ev").EventHandlerType;
        MethodInfo invoke = delegateType.GetMethod("Invoke");
        ParameterInfo[] pars = invoke.GetParameters();
        foreach (ParameterInfo p in pars) 
        {
            Console.WriteLine(p.ParameterType);
        }
    }
}
// The example displays the following output:
//       System.Int32
// </Snippet1>